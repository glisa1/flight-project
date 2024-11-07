using System.ComponentModel.DataAnnotations;

namespace FlightProject.Domain.Models.Base;

public class Entity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
