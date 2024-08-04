using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

[NotMapped]
public abstract class Audit
{
    public DateTime CreatedAt { get; } = DateTime.Now;
    public string CreatedBy { get; set; } = "";
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}