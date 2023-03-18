using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Moment.Models.Entity;

[Table("purchase")]
public class Purchase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public string IdUser { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.Now;

    [Required]
    public int Total { get; set; }

    [Required]
    public Guid IdPayment { get; set; }

    [ForeignKey("IdPayment")]
    public Payment? Payment { get; set; }

    [ForeignKey("IdUser")]
    public IdentityUser? User { get; set; }
}
