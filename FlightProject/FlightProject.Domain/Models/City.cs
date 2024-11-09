using FlightProject.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Domain.Models;

public class City : Entity
{
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
}
