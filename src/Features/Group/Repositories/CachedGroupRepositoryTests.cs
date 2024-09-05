using Core.Constants;
using Core.EnglishContext;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Core.Features.Group.Repositories;
using Core.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Core.UnitTests;

public class CachedGroupRepositoryTests
{
    private IEnumerable<GroupEntity> data = new List<GroupEntity>
    {
        new GroupEntity { Id=1, Name = "Group 1" },
        new GroupEntity { Id=2, Name = "Group 2" },
    };

    protected Mock<IEnglishContext> MockContext()
    {
        var mockContext = new Mock<IEnglishContext>();
        mockContext.Setup(c => c.Groups).ReturnsDbSet(data);

        return mockContext;
    }

    protected GroupRepositoryInterface GetRepo(IEnglishContext context)
    {
        var repo = new GroupRepository(context);

        return repo;
    }

    protected Mock<GroupRepositoryInterface> GetMockRepo()
    {
        var repo = new Mock<GroupRepositoryInterface>();

        return repo;
    }

    protected CachedGroupRepositoryInterface GetCachedRepo(GroupRepositoryInterface db, IDistributedCache cache)
    {
        var repo = new CachedGroupRepository(db, cache);

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

        var mockCachedRepo = new Mock<CachedGroupRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetGroupResult
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
        var mockContext = MockContext();
        var repo = GetRepo(mockContext.Object);

        var cache = GetCache();

        var mockCachedRepo = new Mock<CachedGroupRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetGroupResult
        {
            Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, "group"),
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
        var mockContext = MockContext();
        var repo = GetRepo(mockContext.Object);

        var cache = GetCache();

        var mockCachedRepo = new Mock<CachedGroupRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetGroupResult
        {
            Success = true,
            Data = data.FirstOrDefault(item => item.Id == id),
            Message = string.Format(SuccessMessage.FOUND_ITEM, "group"),
        }));
        var expectedResult = await mockCachedRepo.Object.Get(id);

        var actualRepo = GetCachedRepo(repo, cache);
        var actualResult = await actualRepo.Get(id);
        var actualCacheResult = await cache.GetAsync(actualRepo.GetIdKeyCache(id));
        var actualDecodedCacheResult = CacheHelper.Decode<GroupEntity>(actualCacheResult);

        Assert.True(actualResult.Success);
        Assert.Equal(actualResult.Success, expectedResult.Success);
        Assert.Equal(actualResult.Message, expectedResult.Message);
        Assert.Equal(JsonHelper.Encode(actualResult.Data), JsonHelper.Encode(expectedResult.Data));
        Assert.Equal(JsonHelper.Encode(actualResult.Data), JsonHelper.Encode(actualDecodedCacheResult));
    }
}