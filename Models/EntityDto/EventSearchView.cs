using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class EventSearchView
{
    public string Title;
    public string Local;
    public string Categoria;

    public List<CategoryDto> Categories = new List<CategoryDto>();
    public List<City> Cities = new List<City>();
    public List<EventCard> EventCards = new List<EventCard>();

    public EventSearchView(string title,string local)
    {
        this.Title = title;
        this.Local = local;
    }
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

    public int CountEvents { get { return EventCards.Count; } }
}
