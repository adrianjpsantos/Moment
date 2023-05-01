using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Moment.Models.EntityDto;

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
    public string? IdUserPromoter { get; set; }

    [Required]
    public Guid IdCategory { get; set; }

    [Required]
    [StringLength(60)]
    public string? ThumbnailPath { get; set; }

    [StringLength(60)]
    public string? BackgroundPath { get; set; }

    [Required]
    [StringLength(40)]
    public string? LocalNameAddress { get; set; }

    [Required]
    [StringLength(9)]
    public string? ZipCodeAddress { get; set; }

    [Required]
    [StringLength(50)]
    public string? StreetAddress { get; set; }

    [Required]
    public int NumberAddress { get; set; }

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
    public string? StateAddress { get; set; }

    [Required]
    public DateTime StartDate { get; set; }


    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public bool IsFree { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }


    [ForeignKey("IdUserPromoter")]
    public IdentityUser? UserPromoter { get; set; }

    [ForeignKey("IdCategory")]
    public ConventionCategory? Category { get; set; }

    public string Date()
    {
        var start = StartDate.ToString("dd/MMMM • HH:mm");
        var end = EndDate.ToString("dd/MMMM • HH:mm");
        return $"{start} até {end}";
    }

    public string CityAndState
    {
        get
        {
            return $"{this.CityAddress},{this.StateAddress}";
        }
    }
}
