namespace FlightProject.Application.Models.DTOs;

public record FlightCreatedDto
    (
        int FlightId,
        int SourceCityId,
        int DestinationCityId,
        DateTime Departure,
        DateTime Arrival,
        double Price
    );
