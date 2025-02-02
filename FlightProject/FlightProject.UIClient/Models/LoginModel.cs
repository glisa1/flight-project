using System.ComponentModel.DataAnnotations;

namespace FlightProject.UIClient.Models;

public class LoginModel
{
    [Required]
    [MaxLength(50)]
    public string? Email { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Password { get; set; }
}
