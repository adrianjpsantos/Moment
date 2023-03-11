using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment.Models;

public class ItemPurchase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid IdPurchase { get; set; }

    [Required]
    public Guid IdTicket { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [ForeignKey("IdTicket")]
    public Ticket? Ticket { get; set; }

    [ForeignKey("IdPurchase")]
    public Purchase? Purchase { get; set; }
}
