using AriTechno.Core.EntityDTOS;
using AriTechno.Service.Services.Interfaces;
using AriTechno.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AriTechno.Web.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrunlerController(IProductService productService, ICategoryService categoryService, IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _categoryService = categoryService;
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(int id = 0)
        {
            var productList = _productService.GetAll();

            if (id > 0)
            {
                productList = productList.Where(p => p.CategoryId == id).ToList();
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
        public JsonResult SepeteEkle(int urunId, decimal urunFiyat)
        {
            //Db
            SepetDto sepetDto = new SepetDto
            {
                ProductId = urunId,
                Fiyat = urunFiyat,
                Adet = 1,
                EkleynId = 1,
                Adi = _productService.GetById(urunId).Adi//bu işlem ile ürünün adı sepete yansır
            };
            var sepetUrunu = _basketService.SepeteEkle(sepetDto);

            //Sepet Cookie (Çerez) İşlemleri yapılacak
            //Cookie için 2 durum var
            //1)Cookie ekle
            //2)Cookie de olan ürünleri göster
            //Cookie => geçici dataları tarayıcı hafızasında tutan kod yapılarıdır. Bu geçicilik işlemini ayarlardan süre olarak kod içinde ayarlayabiliriz 

            var sepetList = _basketService.SepetList(sepetDto.EkleynId);
            UrunuCookieyeEkle(sepetList);

            return Json(new { success = true, sepetUrunu });
        }

        #region Cookie (Çerez) İşlemleri 

        /// <summary>
        /// Sepetteki ürümleri Cookie'ye ekler
        /// </summary>
        /// <param name="guncelSepetList"></param>
        public void UrunuCookieyeEkle(List<SepetDto> guncelSepetList)
        {
            var cookieyeOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true
            };

            var jsonString = JsonSerializer.Serialize(cookieyeOptions);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("MusteriSepeti", jsonString, cookieyeOptions);

        }


        public void CookidekiUrunList()
        {

        }


        #endregion
    }
}
