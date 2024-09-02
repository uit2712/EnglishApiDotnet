using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    private readonly CachedTopicRepositoryInterface db;

    public TopicController(CachedTopicRepositoryInterface db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<GetListTopicsResult> Get()
    {
        return await this.db.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<GetTopicResult> GetById(long id)
    {
        return await this.db.Get(id);
    }
}
