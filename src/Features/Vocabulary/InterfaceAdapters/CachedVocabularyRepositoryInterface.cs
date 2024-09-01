using Core.Features.Vocabulary.Models;

namespace Core.Features.Vocabulary.InterfaceAdapters;

public interface CachedVocabularyRepositoryInterface {
    public Task<GetListVocabulariesResult> GetAll();
}