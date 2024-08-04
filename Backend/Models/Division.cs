using System.ComponentModel.DataAnnotations.Schema;
using Backend.Interfaces;

namespace Backend.Models;

public class Division: Audit, IAddress
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public virtual ICollection<Company>? Companies { get; set; }
    public int Zip { get; set; }
    public string City { get; set; } = "";
}