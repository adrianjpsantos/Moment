using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Moment.Models.Entity;

[Table("userinfo")]
public class UserInfo
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid IdUser { get; set; }

    [Required]
    [StringLength(25)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(25)]
    public string? LastName { get; set; }

    [StringLength(400)]
    public string? ProfilePicture { get; set; }

    [Required]
    [StringLength(100)]
    public string? StreetAddress { get; set; }

    [Required]
    public int NumberAddress { get; set; }

    [Required]
    public string? DistrictAddress { get; set; }

    [Required]
    public int ZipCodeAddress { get; set; }

    [Required]
    public string? CityAddress { get; set; }
    [Required]
    public string? StateAddress { get; set; }
    [Required]
    public string? ComplementAddress { get; set; }

    public int CPF { get; set; }
    public int CNPJ { get; set; }

    [Required]
    public bool Promoter { get; set; } = false;

    [ForeignKey("IdUser")]
    public IdentityUser? User { get; set; }

    public string GetFullName(){
        return $"{FirstName} {LastName}";
    }
}
