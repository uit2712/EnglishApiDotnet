using Core.Constants;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Moq.EntityFrameworkCore;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Core.EnglishContext;
using Core.Features.Group.Repositories;

namespace english_api_dotnet.UnitTests;

public class GroupRepositoryTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async void Get_Invalid_Id(int id)
    {
        var data = new List<GroupEntity>
        {
            new GroupEntity { Id=1, Name = "Group 1" },
            new GroupEntity { Id=2, Name = "Group 2" },
        };

        var mockContext = new Mock<IEnglishContext>();
        mockContext.Setup(c => c.Groups).ReturnsDbSet(data);

        var repo = new GroupRepository(mockContext.Object);

        var expectedResult = new GetGroupResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id")
        };
        var actualResult = await repo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void Get_Success(int id)
    {
        var data = new List<GroupEntity>
        {
            new GroupEntity { Id=1, Name = "Group 1" },
            new GroupEntity { Id=2, Name = "Group 2" },
        };

        var mockContext = new Mock<IEnglishContext>();
        mockContext.Setup(c => c.Groups).ReturnsDbSet(data);

        var repo = new GroupRepository(mockContext.Object);

        var expectedResult = new GetGroupResult
        {
            Success = true,
            Data = data.FirstOrDefault(item => item.Id == id)
        };
        var actualResult = await repo.Get(id);

        Assert.True(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }
}