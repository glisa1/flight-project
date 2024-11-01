using System.ComponentModel.DataAnnotations;

namespace FlightProject.SearchService.Domain;

public sealed class Plane
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    public int NumberOfSeats { get; set; }
}
