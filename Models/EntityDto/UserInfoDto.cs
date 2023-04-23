using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Moment.Models.EntityDto;

public class UserInfoDto
{

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    public string? ProfilePicture { get; set; }

    [Required]
    public string? StreetAddress { get; set; }

    [Required]
    public int NumberAddress { get; set; }

    [Required]
    public string? DistrictAddress { get; set; }

    [Required]
    public string? ZipCodeAddress { get; set; }

    [Required]
    public string? CityAddress { get; set; }

    [Required]
    public string? StateAddress { get; set; }

    public string? ComplementAddress { get; set; }

    [Required(ErrorMessage = "CPF ou CNPJ são obrigatórios.")]
    [Display(Name = "CPF ou CNPJ")]
    [RegularExpression(@"^(((\d{3}).(\d{3}).(\d{3})-(\d{2}))?((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))?)*$", ErrorMessage = "Insira um CPF ou CNPJ Válido")]
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }
}
