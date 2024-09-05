using Core.Constants;
using Core.EnglishContext;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Vocabulary.Repositories;

public class VocabularyRepository : VocabularyRepositoryInterface
{
    private IEnglishContext _context;

    public VocabularyRepository(IEnglishContext context)
    {
        _context = context;
    }

    public async Task<GetListVocabulariesResult> GetAll()
    {
        var result = new GetListVocabulariesResult
        {
            Data = await this._context.Vocabularies.ToListAsync()
        };
        if (null == result.Data)
        {
            result.Message = "Get all vocabularies failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get all vocabularies success";
        return result;
    }

    public async Task<GetVocabularyResult> Get(long id)
    {
        var result = new GetVocabularyResult
        {
            Data = await this._context.Vocabularies.FirstOrDefaultAsync(item => item.Id == id)
        };
        if (null == result.Data)
        {
            result.Message = "Get vocabulary by id failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get vocabulary by id success";
        return result;
    }

    public async Task<GetListVocabulariesResult> GetByTopicId(long topicId)
    {
        var result = new GetListVocabulariesResult();
        if (topicId <= 0)
        {
            result.Message = String.Format(ErrorMessage.INVALID_PARAMETER, "topicId");
            return result;
        }

        result.Success = true;
        result.Data = await _context.Vocabularies.Where(item => item.TopicId == topicId).ToListAsync();
        result.Message = "Get list vocabularies by topic id success";
        return result;
    }
}