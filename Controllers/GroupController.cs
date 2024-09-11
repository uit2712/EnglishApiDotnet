using Core.Features.Group.Models;
using Core.Features.Group.UseCases;
using Core.Features.Topic.Models;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("groups")]
public class GroupController : ControllerBase
{
    private readonly GetAllGroupsUseCase getAllGroupsUseCase;
    private readonly GetGroupByIdUseCase getGroupByIdUseCase;
    private readonly GetListTopicsByGroupIdUseCase getListTopicsByGroupIdUseCase;
    private readonly GetAllGroupsFromFileUseCase getAllGroupsFromFileUseCase;

    public GroupController(
        GetAllGroupsUseCase getAllGroupsUseCase,
        GetGroupByIdUseCase getGroupByIdUseCase,
        GetListTopicsByGroupIdUseCase getListTopicsByGroupIdUseCase,
        GetAllGroupsFromFileUseCase getAllGroupsFromFileUseCase
    )
    {
        this.getAllGroupsUseCase = getAllGroupsUseCase;
        this.getGroupByIdUseCase = getGroupByIdUseCase;
        this.getListTopicsByGroupIdUseCase = getListTopicsByGroupIdUseCase;
        this.getAllGroupsFromFileUseCase = getAllGroupsFromFileUseCase;
    }

    [HttpGet]
    public async Task<GetListGroupsResult> Get()
    {
        return await getAllGroupsUseCase.Invoke();
    }

    [HttpGet("{id}")]
    public async Task<GetGroupResult> Get(int id)
    {
        return await getGroupByIdUseCase.Invoke(id);
    }

    [HttpGet("{id}/topics")]
    public async Task<GetListTopicsResult> GetListTopics(int id)
    {
        return await getListTopicsByGroupIdUseCase.Invoke(id);
    }

    [HttpGet("GetFromFile")]
    public GetListGroupsResult GetFromFile()
    {
        return getAllGroupsFromFileUseCase.Invoke();
    }
}
