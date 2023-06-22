using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Moment.Models.EntityDto;

public class EventEditView
{

    [Display(Name = "Id")]
    public string? Id { get; set; }

    [Required(ErrorMessage = "Nome do Evento é Obrigatório.")]
    [Display(Name = "Nome")]
    [StringLength(60, MinimumLength = 10, ErrorMessage = "Nome do Evento deve ter no mínimo 10 e no máximo 60 caracteres.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Resumo é Obrigatório.")]
    [Display(Name = "Resumo")]
    [StringLength(60, MinimumLength = 10, ErrorMessage = "Nome do Evento deve ter no mínimo 10 e no máximo 60 caracteres.")]
    public string? Resume { get; set; }

    [Required(ErrorMessage = "Descrição é Obrigatória.")]
    [Display(Name = "Descrição")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Digite seus Termos.")]
    [Display(Name = "Termos do Evento")]
    public string? Terms { get; set; }

    public string? ThumbnailPath { get; set; }

    public string? BackgroundPath { get; set; }

    [Required(ErrorMessage = "Nome do Local é Obrigatório.")]
    [Display(Name = "Nome do Local")]
    public string? LocalNameAddress { get; set; }

    [Required]
    [Display(Name = "CEP")]
    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP não é válido.")]
    public string? ZipCodeAddress { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Rua")]
    public string? StreetAddress { get; set; }

    [Required(ErrorMessage = "Digite o Número do Endereço")]
    [Display(Name = "Número")]
    public int NumberAddress { get; set; }

    [StringLength(50)]
    [Display(Name = "Complemento")]
    public string? ComplementAddress { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Bairro")]
    public string? DistrictAddress { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Cidade")]
    public string? CityAddress { get; set; }

    [Required]
    [StringLength(2)]
    [Display(Name = "UF")]
    public string? StateAddress { get; set; }

    [Required(ErrorMessage = "Início do Evento é Obrigátorio.")]
    [Display(Name = "Início do Evento")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Fim do Evento é Obrigátorio.")]
    [Display(Name = "Fim do Evento")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Escolha a Categoria do Evento.")]
    [Display(Name = "Categoria")]
    public string? IdCategory { get; set; }

    [Required]
    [Display(Name = "Evento é Gratuito?")]
    public bool IsFree { get; set; }

    public SelectList? Categories { get; set; }
}
