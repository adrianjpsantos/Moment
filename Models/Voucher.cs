using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment.Models;

[Table("voucher")]
public class Voucher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string IdConvention { get; set; }
    public string IdUser { get; set; }
    public string IdPurchase { get; set; }
    public bool Active;

    public DateTime DateOfUse { get; set; }
}
