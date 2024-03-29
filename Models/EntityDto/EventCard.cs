using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class EventCard
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Date { get; set; }
    public Guid Id { get; set; }

    public string ThumbnailPath { get; set; }
    public bool IsFree { get; set; }

    public EventCard(string name, string address, string date, Guid id)
    {
        this.Name = name;
        this.Address = address;
        this.Date = date;
        this.Id = id;
    }
    public EventCard(Convention convention)
    {
        this.Name = convention.Name;
        this.Address = convention.CityAndState;
        this.Date = convention.Date();
        this.Id = convention.Id;
        this.ThumbnailPath = convention.ThumbnailPath;
        this.IsFree = convention.IsFree;
    }

    public string? DateFormated
    {
        get
        {
            if (Date != null && Date.Contains("00:00"))
                return Date.Replace("• 00:00", "");
            else
                return Date;
        }
    }
}
