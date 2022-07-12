using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("products")]
public class Product
{
    [Key]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("price", TypeName = "DECIMAL(8,2)")]
    public decimal Price { get; set; }

    public IList<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
}