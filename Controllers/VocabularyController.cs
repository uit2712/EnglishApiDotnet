using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class VocabularyController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly VocabularyRepositoryInterface db;

    public VocabularyController(VocabularyRepositoryInterface db)
    {
        this.db = db;
    }

    [HttpGet(Name = "Test")]
    public async Task<IEnumerable<VocabularyEntity>?> Get()
    {
        return await this.db.getAll();
    }
}
