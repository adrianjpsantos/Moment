using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Moment.Models;

[Table("Convention")]
public class Convention
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [StringLength(40)]
    public string? Name { get; set; }
    [Required]
    [StringLength(60)]
    public string? Resume { get; set; }

    [Required]
    public string IdUserPromoter { get; set; }

    [ForeignKey("IdUserPromoter")]
    public IdentityUser? UserPromoter { get; set; }

    [Required]
    [StringLength(40)]
    public string ThumbnailPath { get; set; } = "";

    [StringLength(40)]
    public string BackgroundPath { get; set; } = "";

    public string? LatitudeAdress { get; set; }

    public string? LongitudeAdress { get; set; }

}
