namespace FlightProject.Application.Models;

public record ReservationDto(
    int FlightId, 
    double Price, 
    DateTime Departure, 
    DateTime Arrival,
    string SourceCity,
    string DestinationCity,
    string Plane);
