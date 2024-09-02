using Core.Constants;
using Core.Features.Topic.Entities;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Core.Helpers;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.Features.Topic.Repositories;

public class CachedTopicRepository : CachedTopicRepositoryInterface
{
    private TopicRepositoryInterface _db;
    private IDistributedCache _cache;
    private string GROUP_CACHE = "Topics";

    public CachedTopicRepository(TopicRepositoryInterface db, IDistributedCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<GetListTopicsResult> GetAll()
    {
        var result = new GetListTopicsResult();
        var keyCache = this.GetAllKeyCache();
        var cachedData = await _cache.GetAsync(keyCache);

        IEnumerable<int> listIds = new List<int>();
        if (cachedData != null)
        {
            var listIdsFromCache = CacheHelper.Decode<List<int>>(cachedData);
            if (null != listIdsFromCache && listIdsFromCache.Count() > 0) {
                listIds = listIdsFromCache;
            }
        }

        if (listIds.Count() > 0)
        {
            var getTopicResults = await Task.WhenAll(listIds.Select(id => this.Get(id)));

            result.Success = true;
            result.Message = "Get all topics from cache succes";
            result.Data = getTopicResults.Where(item => item.isHasData()).Select(item => item.Data).ToList();

            return result;
        }

        result = await _db.GetAll();
        if (result.isHasData() && result.Data?.Count() > 0) {
            listIds = result.Data.Select(item => item.Id);
            await _cache.SetAsync(keyCache, CacheHelper.Encode(listIds));
            await Task.WhenAll(result.Data.Select(item => _cache.SetAsync(GetIdKeyCache(item.Id), CacheHelper.Encode(item))));
        } 

        return result;
    }

    private string GetAllKeyCache() {
        return String.Format("{0}:ALL", GROUP_CACHE);
    }

    public async Task<GetTopicResult> Get(long id)
    {
        var result = new GetTopicResult();
        if (id <= 0) {
            result.Message = String.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        var keyCache = this.GetIdKeyCache(id);
        var cachedData = await _cache.GetAsync(keyCache);

        if (cachedData != null)
        {
            var data = CacheHelper.Decode<TopicEntity>(cachedData);
            result.Success = true;
            result.Message = "Get Topic by id from cache succes";
            result.Data = data;

            return result;
        }

        result = await this._db.Get(id);
        if (result.Success) {
            await this._cache.SetAsync(keyCache, CacheHelper.Encode(result.Data));
        }

        return result;
    }

    private string GetIdKeyCache(long id) {
        return String.Format("{0}:{1}", GROUP_CACHE, id);
    }
}