using Core.Features.Vocabulary.Entities;

namespace Core.Features.Vocabulary.InterfaceAdapters;

public interface VocabularyMapperInterface {
    public VocabularyEntity? mapFromDbToEntity(dynamic data);
    public IEnumerable<VocabularyEntity> mapFromDbToListEntities(dynamic data);
}