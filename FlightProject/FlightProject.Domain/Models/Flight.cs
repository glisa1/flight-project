using FlightProject.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace FlightProject.Domain.Models;

internal class Flight : Entity
{
    public required City Source { get; set; }
    public required City Destination { get; set; }
    public required Plane Plane { get; set; }
    [Required]
    public DateTime Departure { get; set; }
    [Required]
    public double Price { get; set; }
}
