using FlightProject.Domain.Models.Base;

namespace FlightProject.Domain.Models;

internal class Reservation : Entity
{
    public required Flight Flight { get; set; }
    public int UserId { get; set; }
}
