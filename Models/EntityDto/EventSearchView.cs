using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class EventSearchView
{
    public List<City> Cities = new List<City>();
    public List<EventCard> EventCards = new List<EventCard>();

    public void AddCities(List<City> cities)
    {
        this.Cities = cities;
    }

    public void CreateEventCards(List<Convention> conventions)
    {
        foreach (var convention in conventions)
        {
            EventCards.Add(new EventCard(convention));
        }
    }
}
