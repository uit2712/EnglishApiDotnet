using Core.Features.Topic.Models;

namespace Core.Features.Topic.InterfaceAdapters;

public interface TopicRepositoryInterface {
    public Task<GetListTopicsResult> GetAll();
    public Task<GetTopicResult> Get(long id);
}