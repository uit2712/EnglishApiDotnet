using Core.Constants;
using Moq.EntityFrameworkCore;
using Moq;
using Xunit;
using Core.EnglishContext;
using Core.Features.Topic.Entities;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Repositories;
using Core.Features.Topic.Models;
using Core.Helpers;

namespace Core.UnitTests;

public class TopicRepositoryTests
{
    private string _itemName = "topic";
    private IEnumerable<TopicEntity> _data = new List<TopicEntity>
    {
        new TopicEntity { Id=1, Name="Topic 1", GroupId=1 },
        new TopicEntity { Id=2, Name="Topic 2", GroupId=1 },
        new TopicEntity { Id=3, Name="Topic 3", GroupId=2 },
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
    public async Task Get_Invalid_Id(int id)
    {
        var mockRepo = new Mock<TopicRepositoryInterface>();
        mockRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetTopicResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id")
        }));
        var expectedResult = await mockRepo.Object.Get(id);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task Get_Success(int id)
    {
        var mockRepo = new Mock<TopicRepositoryInterface>();
        mockRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetTopicResult
        {
            Success = true,
            Data = _data.FirstOrDefault(item => item.Id == id),
            Message = string.Format(SuccessMessage.FOUND_ITEM, _itemName)
        }));
        var expectedResult = await mockRepo.Object.Get(id);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.Get(id);

        Assert.True(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }

    [Theory]
    [InlineData(99)]
    [InlineData(100)]
    public async Task Get_Failed_Not_Found_Any_Item(int id)
    {
        var mockRepo = new Mock<TopicRepositoryInterface>();
        mockRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetTopicResult
        {
            Data = _data.FirstOrDefault(item => item.Id == id),
            Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, _itemName),
        }));
        var expectedResult = await mockRepo.Object.Get(id);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.Get(id);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task GetByGroupId_InvalidId(int groupId)
    {
        var mockRepo = new Mock<TopicRepositoryInterface>();
        mockRepo.Setup(c => c.GetByGroupId(groupId)).Returns(Task.FromResult(new GetListTopicsResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "groupId")
        }));
        var expectedResult = await mockRepo.Object.GetByGroupId(groupId);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.GetByGroupId(groupId);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public async Task GetByGroupId_NotFoundItem(int groupId)
    {
        var mockRepo = new Mock<TopicRepositoryInterface>();
        mockRepo.Setup(c => c.GetByGroupId(groupId)).Returns(Task.FromResult(new GetListTopicsResult
        {
            Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, _itemName)
        }));
        var expectedResult = await mockRepo.Object.GetByGroupId(groupId);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.GetByGroupId(groupId);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task GetByGroupId_Success(int groupId)
    {
        var mockRepo = new Mock<TopicRepositoryInterface>();
        mockRepo.Setup(c => c.GetByGroupId(groupId)).Returns(Task.FromResult(new GetListTopicsResult
        {
            Success = true,
            Message = string.Format(SuccessMessage.FOUND_LIST_ITEMS, _itemName),
            Data = _data.Where(item => item.GroupId == groupId),
        }));
        var expectedResult = await mockRepo.Object.GetByGroupId(groupId);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.GetByGroupId(groupId);

        Assert.True(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(JsonHelper.Encode(expectedResult.Data), JsonHelper.Encode(actualResult.Data));
    }
}