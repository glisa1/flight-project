using FlightProject.Domain.Models.Base;

namespace FlightProject.Domain.Models;

public class Reservation : Entity
{
    public required Flight Flight { get; set; }
    public int UserId { get; set; }
}
