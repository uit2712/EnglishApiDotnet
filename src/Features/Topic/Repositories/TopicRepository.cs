using Core.Constants;
using Core.EnglishContext;
using Core.Features.Topic.InterfaceAdapters;
using Core.Features.Topic.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Topic.Repositories;

public class TopicRepository : TopicRepositoryInterface
{
    private IEnglishContext _context;

    public TopicRepository(IEnglishContext context)
    {
        _context = context;
    }

    public async Task<GetListTopicsResult> GetAll()
    {
        var result = new GetListTopicsResult
        {
            Data = await this._context.Topics.ToListAsync()
        };
        if (null == result.Data)
        {
            result.Message = "Get all topics failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get all topics success";
        return result;
    }

    public async Task<GetTopicResult> Get(int id)
    {
        var result = new GetTopicResult();
        if (id <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        result.Data = await _context.Topics.FirstOrDefaultAsync(item => item.Id == id);
        if (null == result.Data)
        {
            result.Message = "Get Topic by id failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get Topic by id success";
        return result;
    }

    public async Task<GetTopicResult> UpdateTopicName(int id, string name)
    {
        var result = new GetTopicResult();
        if (id <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "id");
            return result;
        }

        if (string.IsNullOrEmpty(name))
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "name");
            return result;
        }

        result = await Get(id);
        if (null == result.Data)
        {
            return result;
        }

        result.Data.Name = name;
        var totalUpdatedRows = _context.SaveChanges();
        result.Success = totalUpdatedRows > 0;
        result.Message = "Update topic name success";

        return result;
    }

    public async Task<GetListTopicsResult> GetByGroupId(int groupId)
    {
        var result = new GetListTopicsResult();
        if (groupId <= 0)
        {
            result.Message = string.Format(ErrorMessage.INVALID_PARAMETER, "groupId");
            return result;
        }

        result.Success = true;
        result.Data = await _context.Topics.Where(item => item.GroupId == groupId).ToListAsync();
        result.Message = "Get list topics by group id success";
        return result;
    }
}