using System.ComponentModel.DataAnnotations;

namespace Core.Features.Vocabulary.Entities;

public class VocabularyEntity {
    [Key]
    public long Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string? Pronunciation { get; set; }
    [Required(ErrorMessage = "Meaning is required")]
    public string Meaning { get; set; }
}