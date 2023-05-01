using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Moment.Models.Entity;

[Table("city")]
public class City
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    [Required]
    [StringLength(2)]
    public string? State { get; set; }

    public string CityAndState
    {
        get
        {

            return $"{this.Name},{this.State}";

        }
    }


    public City() { }

    public City(string name, string state)
    {
        this.Name = name;
        this.State = state;
    }
}
