namespace FlightProject.Application.Models;

public record FlightDto
    (
        int FlightId, 
        double Price, 
        DateTime Departure, 
        DateTime Arrival,
        string DepartureCityName,
        string DestinationCityName,
        int NumberOfSeats
    );
