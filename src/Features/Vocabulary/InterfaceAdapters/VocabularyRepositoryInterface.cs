using Core.Features.Vocabulary.Entities;

namespace Core.Features.Vocabulary.InterfaceAdapters;

public interface VocabularyRepositoryInterface {
    public VocabularyEntity getById(string id);
}