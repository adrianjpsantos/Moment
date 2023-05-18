using System.ComponentModel.DataAnnotations;

namespace Moment.Models.EntityDto;

public class UserManagerIndexView
{
    [Required]
    [Display(Name = "Nome de Usuario")]
    public string? Username;
    [Required]
    [Display(Name = "Email")]
    public string? Email;
    [Required]
    [Display(Name = "Telefone")]
    public string? Phone;

    public UserInfoDto? Info;
}
