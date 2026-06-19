using AriTechno.Core.EntityDTOS;
using AriTechno.Service.Services.Interfaces;
using AriTechno.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AriTechno.Web.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBasketService _basketService;


        public UrunlerController(IProductService productService, ICategoryService categoryService, IBasketService basketService )
        {
            _productService = productService;
            _categoryService = categoryService;
            _basketService = basketService;
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

        [HttpPost]
        public JsonResult SepeteEkle(int urunId,decimal urunFiyat)
        {
            //Db
            SepetDto sepetDto = new SepetDto
            {
                ProductId = urunId,
                Fiyat = urunFiyat,
                Adet = 1,
                EkleynId = 1
            };
            var sepetUrunu = _basketService.SepeteEkle(sepetDto);
                
            return Json(new { success = true, sepetUrunu });
        }




    }
}
