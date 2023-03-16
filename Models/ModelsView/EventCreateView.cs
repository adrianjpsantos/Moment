using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moment.Models.ModelsView;

public class EventCreateView
{
    [Required(ErrorMessage = "Nome do Evento é Obrigátorio.")]
    [Display(Name="Nome")]
    [StringLength(60,MinimumLength = 10, ErrorMessage = "Nome do Evento deve ter no minimo 10 e no Máximo 60 Caracteres.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Resumo é Obrigátorio.")]
    [Display(Name="Resumo")]
    [StringLength(60,MinimumLength = 10, ErrorMessage = "Nome do Evento deve ter no minimo 10 e no Máximo 60 Caracteres.")]
    public string? Resume { get; set; }

        [Required(ErrorMessage = "Descrição é Obrigátoria.")]
    [Display(Name="Descrição")]
    [StringLength(60,MinimumLength = 10, ErrorMessage = "Descrição deve ter no minimo 10 e no Máximo 60 Caracteres.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Digite seus Termos.")]
    [Display(Name="Nome do Evento")]
    public string? Terms { get; set; }

    public string? ThumbnailPath { get; set; }

    public string? BackgroundPath { get; set; }

        [Required(ErrorMessage = "Endereço é Obrigátorio.")]
    [Display(Name="Endereço")]
    [StringLength(60,MinimumLength = 10, ErrorMessage = "Endereço deve ter no minimo 10 e no Máximo 60 Caracteres.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Início do Evento é Obrigátorio.")]
    [Display(Name="Início do Evento")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Fim do Evento é Obrigátorio.")]
    [Display(Name="Fim do Evento")]
    public DateTime EndDate { get; set; }
}
