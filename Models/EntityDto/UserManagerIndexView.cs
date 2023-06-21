using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Moment.Models.EntityDto;

public class UserManagerIndexView
{
    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [Display(Name = "Nome de Usuário")]
    public string? NameUser { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    public string? EmailUser { get; set; }

    [Display(Name = "Telefone")]
    public string? PhoneUser { get; set; }

    [Display(Name = "Primeiro Nome")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Deve ter ao mínimo 3 e no máximo 25 caracteres.")]
    public string? FirstName { get; set; }

    [Display(Name = "Último Nome")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Deve ter ao mínimo 3 e no máximo 25 caracteres.")]
    public string? LastName { get; set; }

    [Display(Name = "Foto de perfil")]
    public string? ProfilePicture { get; set; }

    [Display(Name = "Nome da rua")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Deve ter ao mínimo 3 e no máximo 50 caracteres.")]
    public string? StreetAddress { get; set; }

    [Display(Name = "Número")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    public int NumberAddress { get; set; }

    [Display(Name = "Bairro")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [StringLength(35, MinimumLength = 3, ErrorMessage = "Deve ter ao mínimo 3 e no máximo 35 caracteres.")]
    public string? DistrictAddress { get; set; }

    [Display(Name = "CEP")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "Corrija o formato do {0}, Ex: 00000-000")]
    public string? ZipCodeAddress { get; set; }

    [Display(Name = "Cidade")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [MaxLength(25, ErrorMessage = "O Campo ultrapassou seu limite (25 caracteres).")]
    public string? CityAddress { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Este Campo é Obrigatório.")]
    [MaxLength(2, ErrorMessage = "O Campo ultrapassou seu limite (2 caracteres).")]
    public string? StateAddress { get; set; }

    [Display(Name = "Complemento")]
    [MaxLength(25, ErrorMessage = "O Campo ultrapassou seu limite (25 caracteres).")]
    public string? ComplementAddress { get; set; }

    [Display(Name = "CPF")]
    [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}", ErrorMessage = "Insira um CPF Válido")]
    public string? CPF { get; set; }

    [Display(Name = "CNPJ")]
    [RegularExpression(@"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}", ErrorMessage = "Insira um CPF ou CNPJ Válido")]
    public string? CNPJ { get; set; }
}
