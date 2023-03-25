using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moment.Models.Entity;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace Moment.Models.EntityDto;

public class HomeIndexView
{
    public List<CategoryDto> Categories;

    public HomeIndexView(List<CategoryDto> categories)
    {
        this.Categories = categories;
    }

    public string CategoriesJson()
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Default,
            WriteIndented = false
        };
        string s = JsonSerializer.Serialize(Categories,options);
        s.Replace("//","/");
        Debug.WriteLine(s);
        return s;
    }

}
