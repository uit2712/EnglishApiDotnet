using Core.Constants;
using Core.Features.Group.Entities;
using Core.Features.Group.Models;
using Moq.EntityFrameworkCore;
using Moq;
using Xunit;
using Core.EnglishContext;
using Core.Features.Group.Repositories;
using Core.Features.Group.InterfaceAdapters;

namespace Core.UnitTests;

public class GroupRepositoryTests
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

    protected GroupRepositoryInterface MockRepo()
    {
        var repo = new GroupRepository(MockContext().Object);

        return repo;
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async void Get_Invalid_Id(int id)
    {
        var mockRepo = MockRepo();

        var expectedResult = new GetGroupResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id")
        };
        var actualResult = await mockRepo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void Get_Success(int id)
    {
        var mockRepo = MockRepo();

        var expectedResult = new GetGroupResult
        {
            Success = true,
            Data = data.FirstOrDefault(item => item.Id == id),
            Message = string.Format(SuccessMessage.FOUND_ITEM, "group")
        };
        var actualResult = await mockRepo.Get(id);

        Assert.True(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public async void Get_Failed_Not_Found_Any_Item(int id)
    {
        var mockRepo = MockRepo();

        var expectedResult = new GetGroupResult
        {
            Data = data.FirstOrDefault(item => item.Id == id)
        };
        var actualResult = await mockRepo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }
}