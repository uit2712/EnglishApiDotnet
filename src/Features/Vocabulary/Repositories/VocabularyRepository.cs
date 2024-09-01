using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Features.Vocabulary.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Vocabulary.Repositories;

public class VocabularyRepository : VocabularyRepositoryInterface
{
    private Core.EnglishContext.EnglishContext _context;

    public VocabularyRepository(Core.EnglishContext.EnglishContext context)
    {
        _context = context;
    }

    public async Task<GetListVocabulariesResult> GetAll()
    {
        var result = new GetListVocabulariesResult
        {
            Data = await this._context.Vocabularies.ToListAsync()
        };
        if (null == result.Data) {
            result.Message = "Get all vocabularies failed";
            return result;
        }

        result.Success = true;
        result.Message = "Get all vocabularies success";
        result.Data = await this._context.Vocabularies.ToListAsync();
        return result;
    }
}