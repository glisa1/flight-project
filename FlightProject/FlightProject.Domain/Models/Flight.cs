using FlightProject.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Domain.Models;

public class Flight : Entity
{
    public required City Source { get; set; }
    public required City Destination { get; set; }
    public required Plane Plane { get; set; }
    [Required]
    public DateTime Departure { get; set; }
    [Required]
    public DateTime Arrival { get; set; }
    [Required]
    public double Price { get; set; }
}
