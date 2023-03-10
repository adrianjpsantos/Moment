using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment.Models;

[Table("purchase")]
public class Purchase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string IdUser { get; set; }
    public string IdTicket { get; set; }

    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}
