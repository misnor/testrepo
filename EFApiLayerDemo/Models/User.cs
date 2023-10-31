using System.ComponentModel.DataAnnotations;

namespace EFApiLayerDemo.Models;

public class User
{
    [Key]
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}