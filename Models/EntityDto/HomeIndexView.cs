using Microsoft.AspNetCore.Mvc.Rendering;
using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class HomeIndexView
{
    public List<EventCard> RecentEvents = new();

    public HomeIndexView()
    {
    }

    public void CreateRecentEvents(List<Convention> conventions)
    {
        foreach (var convention in conventions)
        {
            RecentEvents.Add(new EventCard(convention));
        }
    }

}
