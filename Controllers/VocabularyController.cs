using Core.Common.UseCases;
using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("vocabularies")]
public class VocabularyController : ControllerBase
{
    private readonly CachedVocabularyRepositoryInterface db;
    private readonly GetDataFromFileUseCase<VocabularyEntity> getListVocabulariesFromFileUseCase;

    public VocabularyController(
        CachedVocabularyRepositoryInterface db,
        GetDataFromFileUseCase<VocabularyEntity> getListVocabulariesFromFileUseCase
    )
    {
        this.db = db;
        this.getListVocabulariesFromFileUseCase = getListVocabulariesFromFileUseCase;
    }

    [HttpGet]
    public async Task<GetListVocabulariesResult> Get()
    {
        return await this.db.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<GetVocabularyResult> GetById(long id)
    {
        return await this.db.Get(id);
    }

    [HttpGet("getFromFile")]
    public Result<IEnumerable<VocabularyEntity>> GetFromFile()
    {
        return getListVocabulariesFromFileUseCase.Invoke();
    }
}
