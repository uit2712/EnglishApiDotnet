using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Core.Features.Group.Entities;

public class GroupEntity
{
    [Key]
    [JsonProperty]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [JsonProperty]
    public string Name { get; set; }
}