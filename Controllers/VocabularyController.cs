using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
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
    public async Task<GetListVocabulariesResult> Get()
    {
        return await this.db.GetAll();
    }
}
