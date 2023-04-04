using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moment.Models.EntityDto
{
    public class SearchForm
    {
        [Required]
        public string Texto { get; set; }
        public string Local { get; set; }
        public string Categoria { get; set; }
        public string Valor { get; set; }
    }
}