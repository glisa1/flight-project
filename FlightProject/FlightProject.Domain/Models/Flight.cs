using FlightProject.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Domain.Models;

public class Flight : Entity
{
    public City Source { get; set; }
    public required int SourceId { get; set; }
    public City Destination { get; set; }
    public required int DestinationId { get; set; }
    public Plane Plane { get; set; }
    public required int PlaneId { get; set; }
    [Required]
    public required DateTime Departure { get; set; }
    [Required]
    public required DateTime Arrival { get; set; }
    [Required]
    public required double Price { get; set; }
}
