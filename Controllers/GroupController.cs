using Core.Features.Group.Models;
using Core.Features.Group.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace english_api_dotnet.Controllers;

[ApiController]
[Route("groups")]
public class GroupController : ControllerBase
{
    private readonly GetAllGroupsUseCase getAllGroupsUseCase;

    public GroupController(
        GetAllGroupsUseCase getAllGroupsUseCase
    )
    {
        this.getAllGroupsUseCase = getAllGroupsUseCase;
    }

    [HttpGet]
    public async Task<GetListGroupsResult> Get()
    {
        return await getAllGroupsUseCase.Invoke();
    }
}
