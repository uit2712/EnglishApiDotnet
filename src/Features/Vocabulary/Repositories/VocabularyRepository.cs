using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Vocabulary.Repositories;

public class VocabularyRepository : VocabularyRepositoryInterface
{
    private Core.EnglishContext.EnglishContext _context;
    private VocabularyMapperInterface _mapper;

    public VocabularyRepository(Core.EnglishContext.EnglishContext context, VocabularyMapperInterface mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<VocabularyEntity>?> getAll()
    {
        var result = await this._context.Vocabularies.ToListAsync();
        if (null == result) {
            return [];
        }

        return result;
    }
}