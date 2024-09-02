using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Topic.Repositories;

public class TopicRepository : TopicRepositoryInterface
{
    private Core.EnglishContext.EnglishContext _context;

    public TopicRepository(Core.EnglishContext.EnglishContext context)
    {
        _context = context;
    }

    public async Task<GetListTopicsResult> GetAll()
    {
        var result = new GetListTopicsResult
        {
            Data = await this._context.Topics.ToListAsync()
        };
        if (null == result.Data) {
            result.Message = "Get all topics failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get all topics success";
        return result;
    }

    public async Task<GetTopicResult> Get(long id)
    {
        var result = new GetTopicResult
        {
            Data = await this._context.Topics.FirstOrDefaultAsync(item => item.Id == id)
        };
        if (null == result.Data) {
            result.Message = "Get Topic by id failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get Topic by id success";
        return result;
    }
}