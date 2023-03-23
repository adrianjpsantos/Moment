using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class CategoryView
{
    public ConventionCategory Category;

    public CategoryView(ConventionCategory category,List<EventCard> hotEvents,List<EventCard> endWeekEvents)
    {
        this.Category = category;
        this.HotEvents = hotEvents;
        this.EndWeekEvents = endWeekEvents;
    }

    public List<EventCard> HotEvents = new();
    public List<EventCard> EndWeekEvents = new();
}
