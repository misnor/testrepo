using System.ComponentModel.DataAnnotations;

namespace EFApiLayerDemo.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }
    public int UserID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}