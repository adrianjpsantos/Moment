using Moment.Models.Entity;

namespace Moment.Models.EntityDto;

public class CategoryView
{
    private CategoryDto _category;
    private List<EventCard> _conventions;

    public CategoryView(CategoryDto category, List<EventCard> conventions)
    {
        this._category = category;
        this._conventions = conventions;
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
