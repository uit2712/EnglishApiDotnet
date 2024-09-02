using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Core.Features.Topic.UseCases;
using Core.Features.Vocabulary.Models;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    private readonly CachedTopicRepositoryInterface db;
    private readonly GetListVocabulariesByTopicIdUseCase getListVocabulariesByTopicIdUseCase;
    private readonly UpdateTopicUseCase updateTopicUseCase;

    public TopicController(
        CachedTopicRepositoryInterface db,
        GetListVocabulariesByTopicIdUseCase getListVocabulariesByTopicIdUseCase,
        UpdateTopicUseCase updateTopicUseCase
    )
    {
        this.db = db;
        this.getListVocabulariesByTopicIdUseCase = getListVocabulariesByTopicIdUseCase;
        this.updateTopicUseCase = updateTopicUseCase;
    }

    [HttpGet]
    public async Task<GetListTopicsResult> Get()
    {
        return await this.db.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<GetTopicResult> GetById(int id)
    {
        return await this.db.Get(id);
    }

    [HttpGet("{id}/vocabularies")]
    public async Task<GetListVocabulariesByTopicIdResult> GetListVocabularies(int id)
    {
        return await getListVocabulariesByTopicIdUseCase.Invoke(id);
    }

    [HttpPost]
    public async Task<GetTopicResult> Update(UpdateTopicViewModel model)
    {
        return await updateTopicUseCase.Invoke(model.Id, model.Name);
    }
}
