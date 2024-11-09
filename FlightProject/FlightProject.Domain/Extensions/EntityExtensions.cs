using FlightProject.Domain.Models.Base;

namespace FlightProject.Domain.Extensions;

public static class EntityExtensions
{
    public static void SetCreatedOnAndUpdatedOn(this Entity entity)
    {
        entity.CreatedOn = DateTime.UtcNow;
        entity.SetUpdatedOn();
    }

    public static void SetUpdatedOn(this Entity entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;
    }
}
