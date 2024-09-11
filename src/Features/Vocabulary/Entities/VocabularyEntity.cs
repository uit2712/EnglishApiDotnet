using System.ComponentModel.DataAnnotations;
using Core.Features.Topic.Entities;
using Newtonsoft.Json;

namespace Core.Features.Vocabulary.Entities;

public class VocabularyEntity
{
    [Key]
    [JsonProperty]
    public long Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [JsonProperty]
    [StringLength(100)]
    public string Name { get; set; }

    [JsonProperty]
    public string? Pronunciation { get; set; }

    [Required(ErrorMessage = "Meaning is required")]
    [JsonProperty]
    [StringLength(100)]
    public string Meaning { get; set; }

    [JsonProperty]
    [StringLength(300)]
    public string? Image { get; set; }

    [JsonProperty]
    public int TopicId { get; set; }
    public TopicEntity Topic { get; set; }
}