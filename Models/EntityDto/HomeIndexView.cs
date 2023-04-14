using Microsoft.AspNetCore.Mvc.Rendering;
using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class HomeIndexView
{
    public List<CategoryDto> Categories = new();
    public List<City> Cities = new();
    public List<EventCard> RecentEvents = new();
    public HomeIndexView(List<CategoryDto> categories, List<City> cities)
    {
        this.Categories = categories;
        this.Cities = cities;
    }

    public void CreateRecentEvents(List<Convention> conventions)
    {
        foreach (var convention in conventions)
        {
            RecentEvents.Add(new EventCard(convention));
        }
    }



    public SelectList SelectCategories
    {
        get { return new SelectList(Categories.OrderBy(c => c.Name).ToList(), "Name"); }
    }

}
