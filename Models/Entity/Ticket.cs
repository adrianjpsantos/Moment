using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment.Models.Entity;

[Table("ticket")]
public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid IdConvention { get; set; }

    [Required]
    public int Lot { get; set; }
    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public DateTime LaunchDay { get; set; }

    [Required]
    public DateTime ClosingDay { get; set; }

    [ForeignKey("IdConvention")]
    public Convention? Convention { get; set; }
}
