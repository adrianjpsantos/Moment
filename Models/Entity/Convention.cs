using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Moment.Models.Entity;

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
    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string? Terms { get; set; }

    [Required]
    public Guid IdUserPromoter { get; set; }

    [Required]
    [StringLength(40)]
    public string? ThumbnailPath { get; set; }

    [StringLength(40)]
    public string? BackgroundPath { get; set; }

    [Required]
    [Column(TypeName = "decimal(8, 6)")]
    public decimal LatitudeAdress { get; set; }

    [Required]
    [Column(TypeName = "decimal(9, 6)")]
    public string? LongitudeAdress { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }


    [ForeignKey("IdUserPromoter")]
    public IdentityUser? UserPromoter { get; set; }

}
