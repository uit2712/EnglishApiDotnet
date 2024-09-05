using Core.Constants;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Core.Features.Group.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Core.UnitTests;

public class CachedGroupRepositoryTests
{
    protected Mock<GroupRepositoryInterface> GetMockRepo()
    {
        var repo = new Mock<GroupRepositoryInterface>();

        return repo;
    }

    protected CachedGroupRepositoryInterface GetCachedRepo()
    {
        var repo = new CachedGroupRepository(GetMockRepo().Object, MockCache());

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

        var mockRepo = new Mock<CachedGroupRepositoryInterface>();
        mockRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetGroupResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id"),
        }));
        var expectedResult = await mockRepo.Object.Get(id);

        var actualRepo = GetCachedRepo();
        var actualResult = await actualRepo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(actualResult.Success, expectedResult.Success);
        Assert.Equal(actualResult.Message, expectedResult.Message);
    }
}