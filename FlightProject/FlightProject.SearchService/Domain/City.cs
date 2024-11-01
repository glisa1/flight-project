using System.ComponentModel.DataAnnotations;

namespace FlightProject.SearchService.Domain;

public sealed class City
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
}
