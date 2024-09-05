using Core.Constants;
using Moq.EntityFrameworkCore;
using Moq;
using Xunit;
using Core.EnglishContext;
using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Repositories;
using Core.Features.Vocabulary.Models;
using Core.Helpers;

namespace Core.UnitTests;

public class VocabularyRepositoryTests
{
    private string _itemName = "vocabulary";
    private IEnumerable<VocabularyEntity> _data = new List<VocabularyEntity>
    {
        new VocabularyEntity { Id=1, Name="Vocabulary 1", Pronunciation="Pronunciation 1", Meaning="Meaning 1", TopicId=1 },
        new VocabularyEntity { Id=2, Name="Vocabulary 2", Pronunciation="Pronunciation 2", Meaning="Meaning 2", TopicId=1 },
        new VocabularyEntity { Id=3, Name="Vocabulary 3", Pronunciation="Pronunciation 3", Meaning="Meaning 3", TopicId=1 },
        new VocabularyEntity { Id=4, Name="Vocabulary 4", Pronunciation="Pronunciation 4", Meaning="Meaning 4", TopicId=1 },
        new VocabularyEntity { Id=5, Name="Vocabulary 5", Pronunciation="Pronunciation 5", Meaning="Meaning 5", TopicId=2 },
        new VocabularyEntity { Id=6, Name="Vocabulary 6", Pronunciation="Pronunciation 6", Meaning="Meaning 6", TopicId=2 },
    };

    protected Mock<IEnglishContext> GetMockContext()
    {
        var mockContext = new Mock<IEnglishContext>();
        mockContext.Setup(c => c.Vocabularies).ReturnsDbSet(_data);

        return mockContext;
    }

    protected VocabularyRepositoryInterface GetRepo(IEnglishContext context)
    {
        var repo = new VocabularyRepository(context);

        return repo;
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async void Get_Invalid_Id(int id)
    {
        var mockRepo = new Mock<VocabularyRepositoryInterface>();
        mockRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetVocabularyResult
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
    public async void Get_Success(int id)
    {
        var mockRepo = new Mock<VocabularyRepositoryInterface>();
        mockRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetVocabularyResult
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
    public async void Get_Failed_Not_Found_Any_Item(int id)
    {
        var mockRepo = new Mock<VocabularyRepositoryInterface>();
        mockRepo.Setup(c => c.Get(id)).Returns(Task.FromResult(new GetVocabularyResult
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
    public async void GetByTopicId_InvalidId(int topicId)
    {
        var mockRepo = new Mock<VocabularyRepositoryInterface>();
        mockRepo.Setup(c => c.GetByTopicId(topicId)).Returns(Task.FromResult(new GetListVocabulariesResult
        {
            Message = string.Format(ErrorMessage.INVALID_PARAMETER, "topicId")
        }));
        var expectedResult = await mockRepo.Object.GetByTopicId(topicId);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.GetByTopicId(topicId);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public async void GetByTopicId_NotFoundItem(int topicId)
    {
        var mockRepo = new Mock<VocabularyRepositoryInterface>();
        mockRepo.Setup(c => c.GetByTopicId(topicId)).Returns(Task.FromResult(new GetListVocabulariesResult
        {
            Message = string.Format(ErrorMessage.NOT_FOUND_ITEM, _itemName)
        }));
        var expectedResult = await mockRepo.Object.GetByTopicId(topicId);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.GetByTopicId(topicId);

        Assert.False(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(expectedResult.Data, actualResult.Data);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void GetByTopicId_Success(int topicId)
    {
        var mockRepo = new Mock<VocabularyRepositoryInterface>();
        mockRepo.Setup(c => c.GetByTopicId(topicId)).Returns(Task.FromResult(new GetListVocabulariesResult
        {
            Success = true,
            Message = string.Format(SuccessMessage.FOUND_LIST_ITEMS, _itemName),
            Data = _data.Where(item => item.TopicId == topicId),
        }));
        var expectedResult = await mockRepo.Object.GetByTopicId(topicId);

        var mockContext = GetMockContext();
        var repo = GetRepo(mockContext.Object);
        var actualResult = await repo.GetByTopicId(topicId);

        Assert.True(actualResult.Success);
        Assert.Equal(expectedResult.Success, actualResult.Success);
        Assert.Equal(expectedResult.Message, actualResult.Message);
        Assert.Equal(JsonHelper.Encode(expectedResult.Data), JsonHelper.Encode(actualResult.Data));
    }
}