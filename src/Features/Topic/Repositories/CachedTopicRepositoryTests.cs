using Core.Constants;
using Core.EnglishContext;
using Core.Features.Topic.Entities;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Core.Features.Topic.Repositories;
using Core.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Core.UnitTests;

public class CachedTopicRepositoryTests
{
    private string _itemName = "topic";
    private IEnumerable<TopicEntity> _data = new List<TopicEntity>
    {
        new TopicEntity { Id=1, Name="Topic 1", GroupId=1 },
        new TopicEntity { Id=2, Name="Topic 2", GroupId=1 },
    };

    protected Mock<IEnglishContext> GetMockContext()
    {
        var mockContext = new Mock<IEnglishContext>();
        mockContext.Setup(c => c.Topics).ReturnsDbSet(_data);

        return mockContext;
    }

    protected TopicRepositoryInterface GetRepo(IEnglishContext context)
    {
        var repo = new TopicRepository(context);

        return repo;
    }

    protected Mock<TopicRepositoryInterface> GetMockRepo()
    {
        var repo = new Mock<TopicRepositoryInterface>();

        return repo;
    }

    protected CachedTopicRepositoryInterface GetCachedRepo(TopicRepositoryInterface db, IDistributedCache cache)
    {
        var repo = new CachedTopicRepository(db, cache);

        return repo;
    }

    public IDistributedCache GetCache()
    {
        var opts = Options.Create(new MemoryDistributedCacheOptions());
        return new MemoryDistributedCache(opts);
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(0)]
    public async void Get_Invalid_Id(int id)
    {
        var cache = GetCache();

        var mockCachedRepo = new Mock<CachedTopicRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetTopicResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id"),
        }));
        var expectedResult = await mockCachedRepo.Object.Get(id);

        var actualRepo = GetCachedRepo(GetMockRepo().Object, cache);
        var actualResult = await actualRepo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(actualResult.Success, expectedResult.Success);
        Assert.Equal(actualResult.Message, expectedResult.Message);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public async void Get_Not_Found_Item(int id)
    {
        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);

        var cache = GetCache();

        var mockCachedRepo = new Mock<CachedTopicRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetTopicResult
        {
            Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, _itemName),
        }));
        var expectedResult = await mockCachedRepo.Object.Get(id);

        var actualRepo = GetCachedRepo(repo, cache);
        var actualResult = await actualRepo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(actualResult.Success, expectedResult.Success);
        Assert.Equal(actualResult.Message, expectedResult.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void Get_Success(int id)
    {
        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);

        var cache = GetCache();

        var mockCachedRepo = new Mock<CachedTopicRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetTopicResult
        {
            Success = true,
            Data = _data.FirstOrDefault(item => item.Id == id),
            Message = string.Format(SuccessMessage.FOUND_ITEM, _itemName),
        }));
        var expectedResult = await mockCachedRepo.Object.Get(id);

        var actualRepo = GetCachedRepo(repo, cache);
        var actualResult = await actualRepo.Get(id);
        var actualCacheResult = await cache.GetAsync(actualRepo.GetIdKeyCache(id));
        var actualDecodedCacheResult = CacheHelper.Decode<TopicEntity>(actualCacheResult);

        Assert.True(actualResult.Success);
        Assert.Equal(actualResult.Success, expectedResult.Success);
        Assert.Equal(actualResult.Message, expectedResult.Message);
        Assert.Equal(JsonHelper.Encode(actualResult.Data), JsonHelper.Encode(expectedResult.Data));
        Assert.Equal(JsonHelper.Encode(actualResult.Data), JsonHelper.Encode(actualDecodedCacheResult));
    }
}