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
    public string IdUserPromoter { get; set; }

    [Required]
    public Guid IdCategory { get; set; }

    [Required]
    [StringLength(40)]
    public string? ThumbnailPath { get; set; }

    [StringLength(40)]
    public string? BackgroundPath { get; set; }

    [Required]
    [StringLength(9)]
    public string? CepAddress { get; set; }
    [Required]
    [StringLength(50)]
    public string? StreetAddress { get; set; }

    [Required]
    public int NumberAddress { get; set; }

    [Required]
    [StringLength(50)]
    public string? ComplementAddress { get; set; }
    [Required]
    [StringLength(50)]
    public string? DistrictAddress { get; set; }
    [Required]
    [StringLength(50)]
    public string? CityAddress { get; set; }

    [Required]
    [StringLength(2)]
    public string? UFAddress { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }


    [ForeignKey("IdUserPromoter")]
    public IdentityUser? UserPromoter { get; set; }

    [ForeignKey("IdCategory")]
    public ConventionCategory? Category { get; set; }

}
