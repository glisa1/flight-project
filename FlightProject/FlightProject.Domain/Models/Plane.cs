﻿using System.ComponentModel.DataAnnotations;

namespace FlightProject.Domain.Models;

internal class Plane
{
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    public int NumberOfSeats { get; set; }
}
