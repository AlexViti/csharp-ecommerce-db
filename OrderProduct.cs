using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("order_product")]
public class OrderProduct
{
    [Column("order_id")]
    public int OrderId { get; set; }
    [Column("product_id")]
    public int ProductId { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
    [Column("quantity")]
    public int Quantity { get; set; }
}

