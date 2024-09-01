using System.Collections;
using Core.Features.Vocabulary.Entities;
using Core.Features.Vocabulary.InterfaceAdapters;
using Core.Helpers;

namespace Core.Features.Vocabulary.Mappers;

public class VocabularyMapper : VocabularyMapperInterface
{
    public VocabularyEntity? mapFromDbToEntity(dynamic data)
    {
        if (null == data)
        {
            return null;
        }

        VocabularyEntity result = new VocabularyEntity();
        if (NumberHelper.IsNumeric(data.Id) == false)
        {
            result.Id = (int)data.Id;
        }

        if (String.IsNullOrEmpty(data.Name) == false)
        {
            result.Name = ((string)data.Name).Trim();
        }

        if (String.IsNullOrEmpty(data.Pronunciation) == false)
        {
            result.Pronunciation = ((string)data.Pronunciation).Trim();
        }

        if (String.IsNullOrEmpty(data.Meaning) == false)
        {
            result.Meaning = ((string)data.Meaning).Trim();
        }

        return result;
    }

    public IEnumerable<VocabularyEntity> mapFromDbToListEntities(dynamic data)
    {
        var result = new List<VocabularyEntity>();
        if (null == data || data is IEnumerable == false)
        {
            return result;
        }

        foreach (var item in data)
        {
            var newItem = this.mapFromDbToEntity(item);
            if (null != newItem) {
                result.Add(newItem);
            }
        }

        return result;
    }
}