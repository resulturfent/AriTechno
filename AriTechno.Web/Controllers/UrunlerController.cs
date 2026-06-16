using AriTechno.Service.Services.Interfaces;
using AriTechno.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AriTechno.Web.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;


        public UrunlerController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int id = 0)
        {
            var productList = _productService.GetAll();

            if (id > 0)
            {
                productList= productList.Where(p => p.CategoryId == id).ToList();
            }
            var categoryList = _categoryService.GetAll();

            var productCategoryView = new ProductCategoryView
            {
                ProductList = productList,
                CategoryList = categoryList
            };
            return View(productCategoryView);
        }


    }
}
