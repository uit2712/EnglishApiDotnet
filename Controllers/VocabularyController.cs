using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class VocabularyController : ControllerBase
{
    private readonly CachedVocabularyRepositoryInterface db;

    public VocabularyController(CachedVocabularyRepositoryInterface db)
    {
        this.db = db;
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
}
