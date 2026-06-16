using AriTechno.Database.Entities;

namespace AriTechno.Web.Models;

public class ProductCategoryView
{
    public List<Product> ProductList { get; set; }
    public List<Category> CategoryList { get; set; }
}
