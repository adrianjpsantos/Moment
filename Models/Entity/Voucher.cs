using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Moment.Models.Entity;

[Table("voucher")]
public class Voucher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid IdConvention { get; set; }

    [Required]
    public Guid IdUser { get; set; }

    [Required]
    public Guid IdPurchase { get; set; }

    public bool Active;

    [Required]
    public DateTime DateOfUse { get; set; }

    [ForeignKey("IdConvention")]
    public Convention? Convention { get; set; }

    [ForeignKey("IdUser")]
    public IdentityUser? User { get; set; }

    [ForeignKey("IdPurchase")]
    public Purchase? Purchase { get; set; }
}
