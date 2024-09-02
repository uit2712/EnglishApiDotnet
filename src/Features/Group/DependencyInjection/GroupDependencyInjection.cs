using Core.Features.Group.InterfaceAdapters;
using Core.Features.Group.Repositories;

namespace Core.Features.Group.DependencyInjection;

public class GroupDependencyInjection
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<GroupRepositoryInterface, GroupRepository>();
        services.AddScoped<CachedGroupRepositoryInterface, CachedGroupRepository>();
    }
}