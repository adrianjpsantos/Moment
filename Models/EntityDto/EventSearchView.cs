using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class EventSearchView
{
    public List<City> Cities = new List<City>();

    public EventSearchView(List<City> cities)
    {
        this.Cities = cities;
    }
}
