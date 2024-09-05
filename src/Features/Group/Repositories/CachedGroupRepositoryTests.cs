using Core.Constants;
using Core.EnglishContext;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Core.Features.Group.Repositories;
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

    public IDistributedCache MockCache()
    {
        var opts = Options.Create(new MemoryDistributedCacheOptions());
        return new MemoryDistributedCache(opts);
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(0)]
    public async void Get_Invalid_Id(int id)
    {
        var mockCache = MockCache();

        var mockCachedRepo = new Mock<CachedGroupRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetGroupResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id"),
        }));
        var expectedResult = await mockCachedRepo.Object.Get(id);

        var actualRepo = GetCachedRepo(GetMockRepo().Object, mockCache);
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

        var mockCache = MockCache();

        var mockCachedRepo = new Mock<CachedGroupRepositoryInterface>();
        mockCachedRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetGroupResult
        {
            Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, "group"),
        }));
        var expectedResult = await mockCachedRepo.Object.Get(id);

        var actualRepo = GetCachedRepo(repo, mockCache);
        var actualResult = await actualRepo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(actualResult.Success, expectedResult.Success);
        Assert.Equal(actualResult.Message, expectedResult.Message);
    }
}