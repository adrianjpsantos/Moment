using System.ComponentModel.DataAnnotations;

namespace Moment.Models.EntityDto;

public class UserManagerIndexView
{
    [Required(ErrorMessage = "{1} é obrigatorio")]
    [Display(Name = "Nome de Usuario")]
    public string? Username;

    [Required(ErrorMessage = "{1} é obrigatorio")]
    [Display(Name = "Email")]
    public string? Email;

    [Required(ErrorMessage = "{1} é obrigatorio")]
    [Display(Name = "Telefone")]
    public string? Phone;

     [Display(Name = "Primeiro Nome")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Deve ter ao minimo 3 e no máximo 25 caracteres")]
    public string? FirstName { get; set; }

    [Display(Name = "Ultimo Nome")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Deve ter ao minimo 3 e no máximo 25 caracteres")]
    public string? LastName { get; set; }

    [Display(Name = "Foto de perfil")]
    public string? ProfilePicture { get; set; }

    [Display(Name = "Nome da rua")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Deve ter ao minimo 3 e no máximo 50 caracteres")]
    public string? StreetAddress { get; set; }

    [Display(Name = "Numero")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    public int NumberAddress { get; set; }

    [Display(Name = "Bairro")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [StringLength(35, MinimumLength = 3, ErrorMessage = "Deve ter ao minimo 3 e no máximo 35 caracteres")]
    public string? DistrictAddress { get; set; }

    [Display(Name = "Cep")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "Corrija o formato do {0}, Ex: 00000-000")]
    public string? ZipCodeAddress { get; set; }

    [Display(Name = "Cidade")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [MaxLength(25, ErrorMessage = "O Campo ultrapassou seu limite (25 Caracteres).")]
    public string? CityAddress { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [MaxLength(2, ErrorMessage = "O Campo ultrapassou seu limite (2 Caracteres).")]
    public string? StateAddress { get; set; }

    [Display(Name = "Complemento")]
    [Required(ErrorMessage = "Este Campo é Obrigátorio.")]
    [MaxLength(25, ErrorMessage = "O Campo ultrapassou seu limite (25 Caracteres).")]
    public string? ComplementAddress { get; set; }

    [Display(Name = "CPF")]
    [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}", ErrorMessage = "Insira um CPF Válido")]
    public string? CPF { get; set; }

    [Display(Name = "CNPJ")]
    [RegularExpression(@"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}", ErrorMessage = "Insira um CPF ou CNPJ Válido")]
    public string? CNPJ { get; set; }
}
