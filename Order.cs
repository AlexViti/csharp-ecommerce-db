using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("orders")]
public class Order
{
    [Key]
    public int Id { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("amount", TypeName = "DECIMAL(8,2)")]
    public decimal Amount { get; set; }
    [Column("status")]
    public string Status { get; set; }

    [Column("costumer_id")]
    public int CostumerId { get; set; }
    public Costumer Costumer { get; set; }

    public IList<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}