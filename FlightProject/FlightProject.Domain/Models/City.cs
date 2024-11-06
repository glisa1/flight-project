using FlightProject.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Domain.Models;

internal class City : Entity
{
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
}
