using System.ComponentModel.DataAnnotations;

namespace EFApiLayerDemo.Models;

public class Product
{
    [Key]
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryID { get; set; }

    public virtual Category Category { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}