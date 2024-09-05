using Core.Constants;
using Core.Features.Group.Entities;
using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Models;
using Moq.EntityFrameworkCore;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;

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

        var options = new Mock<DbContextOptions<Core.EnglishContext.EnglishContext>>();
        var mockContext = new Mock<Core.EnglishContext.EnglishContext>();
        mockContext.Setup(c => c.Set<GroupEntity>()).ReturnsDbSet(data);

        var mockRepo = new Mock<GroupRepositoryInterface>(mockContext.Object);

        var expectedResult = new GetGroupResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id")
        };
        var actualResult = await mockRepo.Object.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
    }
}