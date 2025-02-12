namespace FlightProject.Application.Models.DTOs;

public record ReservationDto(
    int FlightId,
    double Price,
    DateTime Departure,
    DateTime Arrival,
    string SourceCity,
    string DestinationCity,
    string Plane);
