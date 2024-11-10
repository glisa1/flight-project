using FlightProject.Domain.Models.Base;

namespace FlightProject.Domain.Models;

public class Reservation : Entity
{
    public Flight Flight { get; set; }
    public int FlightId { get; set; }
    public int UserId { get; set; }
}
