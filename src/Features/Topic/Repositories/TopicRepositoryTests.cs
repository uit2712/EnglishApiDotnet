using Core.Constants;
using Moq.EntityFrameworkCore;
using Moq;
using Xunit;
using Core.EnglishContext;
using Core.Features.Topic.Entities;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Repositories;
using Core.Features.Topic.Models;

namespace Core.UnitTests;

public class TopicRepositoryTests
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

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async void Get_Invalid_Id(int id)
    {
        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);

        var expectedResult = new GetTopicResult
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
        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);

        var expectedResult = new GetTopicResult
        {
            Success = true,
            Data = _data.FirstOrDefault(item => item.Id == id),
            Message = string.Format(SuccessMessage.FOUND_ITEM, _itemName)
        };
        var actualResult = await repo.Get(id);

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
        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);

        var expectedResult = new GetTopicResult
        {
            Data = _data.FirstOrDefault(item => item.Id == id),
            Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, _itemName),
        };
        var actualResult = await repo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }
}