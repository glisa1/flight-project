﻿using FlightProject.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Domain.Models;

public class Plane : Entity
{
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    public int NumberOfSeats { get; set; }
}
