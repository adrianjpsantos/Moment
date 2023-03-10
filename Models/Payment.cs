using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment.Models;

public class Payment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string IdPurchase { get; set; }
    public decimal Amount { get; set; }
    public string Provider { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
}
