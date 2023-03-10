using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment.Models;

public class ItemPurchase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string IdPurchase { get; set; }
    public string IdTicket { get; set; }

    public DateTime Date { get; set; }
}
