using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Core.Helpers;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.Features.Vocabulary.Repositories;

public class CachedVocabularyRepository : CachedVocabularyRepositoryInterface
{
    private VocabularyRepositoryInterface _db;
    private IDistributedCache _cache;
    private string GROUP_CACHE = "Vocabularies";

    public CachedVocabularyRepository(VocabularyRepositoryInterface db, IDistributedCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<GetListVocabulariesResult> GetAll()
    {
        var result = new GetListVocabulariesResult();
        var keyCache = this.GetAllKeyCache();
        var cachedData = await _cache.GetAsync(keyCache);

        if (cachedData != null)
        {
            var data = CacheHelper.Decode<IEnumerable<VocabularyEntity>>(cachedData);
            result.Success = true;
            result.Message = "Get all vocabularies from cache succes";
            result.Data = data;

            return result;
        }

        result = await this._db.GetAll();
        if (result.Success) {
            await this._cache.SetAsync(keyCache, CacheHelper.Encode(result.Data));
        }

        return result;
    }

    private string GetAllKeyCache() {
        return String.Format("{0}:ALL", GROUP_CACHE);
    }
}