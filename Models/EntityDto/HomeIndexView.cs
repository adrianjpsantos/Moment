using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Moment.Models.EntityDto;

public class HomeIndexView
{
    public List<CategoryDto> Categories;
    public SearchForm searchForm = new();

    public HomeIndexView(List<CategoryDto> categories)
    {
        this.Categories = categories;
    }

    public SelectList SelectCategories
    {
        get { return new SelectList(Categories.OrderBy(c => c.Name).ToList(), "Name"); }
    }

}
