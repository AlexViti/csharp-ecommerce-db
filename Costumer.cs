using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("costumers")]
public class Costumer
{
    [Key]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("surname")]
    public string Surname { get; set; }
    [Column("email")]
    public string Email { get; set; }
    
    public List<Order> Orders { get; set; }
}

