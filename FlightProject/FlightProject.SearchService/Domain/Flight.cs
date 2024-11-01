using System.ComponentModel.DataAnnotations;

namespace FlightProject.SearchService.Domain;

public sealed class Flight
{
    [Key]
    public int Id { get; set; }
    public required City SourceId { get; set; }
    public required City DestinationId { get; set; }
    public required Plane PlaneId { get; set; }
    [Required]
    public DateTime Departure { get; set; }
    [Required]
    public double Price { get; set; }
}
