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
    private readonly SeedDataFromFileUseCase<VocabularyEntity> seedListVocabulariesFromFileUseCase;

    public VocabularyController(
        CachedVocabularyRepositoryInterface db,
        GetDataFromFileUseCase<VocabularyEntity> getListVocabulariesFromFileUseCase,
        SeedDataFromFileUseCase<VocabularyEntity> seedListVocabulariesFromFileUseCase
    )
    {
        this.db = db;
        this.getListVocabulariesFromFileUseCase = getListVocabulariesFromFileUseCase;
        this.seedListVocabulariesFromFileUseCase = seedListVocabulariesFromFileUseCase;
    }

    [HttpGet("{id}")]
    public async Task<GetVocabularyResult> GetById(long id)
    {
        return await db.Get(id);
    }

    [HttpGet("getFromFile")]
    public Result<IEnumerable<VocabularyEntity>> GetFromFile()
    {
        return getListVocabulariesFromFileUseCase.Invoke();
    }

    [HttpPost("seedFromFile")]
    public Result<bool> SeedFromFile()
    {
        return seedListVocabulariesFromFileUseCase.Invoke();
    }
}
