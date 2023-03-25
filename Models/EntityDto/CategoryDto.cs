using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moment.Models.Entity;

namespace Moment.Models.EntityDto
{
    public class CategoryDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
        public string? ImagePath { get; set; }

        public CategoryDto(ConventionCategory conventionCategory){
            this.Name = conventionCategory.Name;
            this.Description = conventionCategory.Description;
            this.ImagePath = conventionCategory.ImagePath;
        }
    }
}