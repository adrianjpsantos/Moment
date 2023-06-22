using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment.Models.EntityDto
{
    public class UserManagerMyEventsView
    {
        public bool IsPromoter { get; set; }
        public List<EventCard> Conventions { get; set; }
        
    }
}