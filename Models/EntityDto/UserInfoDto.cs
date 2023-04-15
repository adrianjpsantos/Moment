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
    public int ZipCodeAddress { get; set; }

    [Required]
    public string? CityAddress { get; set; }
    [Required]
    public string? StateAddress { get; set; }

    public string? ComplementAddress { get; set; }

    public int CPF { get; set; }
    public int CNPJ { get; set; }
}
