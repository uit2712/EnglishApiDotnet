using Core.Features.Group.Models;
using Core.Features.Group.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("groups")]
public class GroupController : ControllerBase
{
    private readonly GetAllGroupsUseCase getAllGroupsUseCase;
    private readonly GetGroupByIdUseCase getGroupByIdUseCase;

    public GroupController(
        GetAllGroupsUseCase getAllGroupsUseCase,
        GetGroupByIdUseCase getGroupByIdUseCase
    )
    {
        this.getAllGroupsUseCase = getAllGroupsUseCase;
        this.getGroupByIdUseCase = getGroupByIdUseCase;
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
}
