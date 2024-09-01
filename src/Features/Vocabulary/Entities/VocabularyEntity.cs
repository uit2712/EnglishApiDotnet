using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Core.Features.Vocabulary.Entities;

public class VocabularyEntity {
    [Key]
    [JsonProperty]
    public long Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [JsonProperty]
    public string Name { get; set; }
    [JsonProperty]
    public string? Pronunciation { get; set; }
    [Required(ErrorMessage = "Meaning is required")]
    [JsonProperty]
    public string Meaning { get; set; }
}