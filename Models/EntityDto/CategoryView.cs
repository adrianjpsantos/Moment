using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class CategoryView
{
    private CategoryDto _category;
    public List<EventCard> EventCards;

    public CategoryView(CategoryDto category, List<EventCard> eventCards)
    {
        this._category = category;
        this.EventCards = eventCards;
    }

    public string? Name
    {
        get
        {
            return _category?.Name;
        }
    }

    public string? Description
    {
        get
        {
            return _category?.Description;
        }
    }

    public string ImagePath
    {
        get
        {
            return _category?.ImagePath;
        }
    }
}
