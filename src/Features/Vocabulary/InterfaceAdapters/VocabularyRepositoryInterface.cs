using Core.Features.Vocabulary.Models;

namespace Core.Features.Vocabulary.InterfaceAdapters;

public interface VocabularyRepositoryInterface {
    public Task<GetListVocabulariesResult> GetAll();
    public Task<GetVocabularyResult> Get(long id);
}