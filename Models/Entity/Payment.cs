using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment.Models.Entity;

[Table("payment")]
public class Payment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid IdPurchase { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public string? Provider { get; set; }

    [Required]
    public bool Paid { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [ForeignKey("IdPurchase")]
    public Purchase? Purchase { get; set; }
}
