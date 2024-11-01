namespace FlightProject.SearchService.Domain;

public sealed class Reservation
{
    public int Id { get; set; }
    public required Flight Flight { get; set; }
    public int UserId { get; set; }
}
