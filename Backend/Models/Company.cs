using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Company : Audit
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public int DivisionId { get; set; }
    public int NumberOfProperties { get; set; }
    public int NumberOfNotListedUnits { get; set; }
    public int NumberOfAvailableUnits { get; set; }
    public int NumberOfInProgressUnits { get; set; }
    public int NumberOfActiveUnits { get; set; }
    public virtual Division? Division { get; set; }
}