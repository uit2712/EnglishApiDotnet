using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Helpers;

namespace Core.Features.Vocabulary.Mappers;

public class VocabularyMapper : VocabularyMapperInterface
{
    public VocabularyEntity? mapFromDbToEntity(dynamic data)
    {
        if (null == data) {
            return null;
        }

        VocabularyEntity result = new VocabularyEntity();
        if (NumberHelper.IsNumeric(data.Id) == false) {
            result.Id = (int)data.Id;
        }

        if (String.IsNullOrEmpty(data.Name) == false) {
            result.Name = ((string)data.Name).Trim();
        }

        if (String.IsNullOrEmpty(data.Pronunciation) == false) {
            result.Pronunciation = ((string)data.Pronunciation).Trim();
        }

        if (String.IsNullOrEmpty(data.Meaning) == false) {
            result.Meaning = ((string)data.Meaning).Trim();
        }

        return result;
    }
}