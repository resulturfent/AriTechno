using AriTechno.Core.EntityDTOS;
using AriTechno.Database.Entities;
using AriTechno.Service.Services.Interfaces;
using AriTechno.Web.Models;
using AspNetCoreGeneratedDocument;
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
        public IActionResult SepeteEkle(int urunId, decimal urunFiyat )
        {

            try
            {
                SepetDto sepetDto = new SepetDto
                {
                    ProductId = urunId,
                    Fiyat = urunFiyat,
                    Adet = 1,
                    EkleynId = 1,
                    Adi=_basketService.GetById(urunId).Adi
                };

                List<SepetDto> mevcutSepet = CookidenSepetGetir();
                var varmiUrunSepette = mevcutSepet.FirstOrDefault(k => k.ProductId == sepetDto.ProductId);

                if (varmiUrunSepette != null)
                {
                    varmiUrunSepette.Adet += 1; // Doğrudan 1 artırabilirsiniz (sepetDto.Adet zaten 1)

                    var getirUrun = _basketService.GetById(varmiUrunSepette.ProductId);
                    if (getirUrun != null)
                    {
                        getirUrun.Adet = varmiUrunSepette.Adet;
                        getirUrun.Adi = _basketService.GetById(urunId).Adi;
                        _basketService.Update(getirUrun);
                    }
                }
                else
                {               
                    mevcutSepet.Add(sepetDto);
                    _basketService.SepeteEkle(sepetDto);
                }
                
                SepetiCookieyeKaydet(mevcutSepet);

                // AJAX'a başarı durumu ve güncellenen nesneyi dönüyoruz
                varmiUrunSepette.Adi= _basketService.GetById(urunId).Adi;
                var sepetUrunu = varmiUrunSepette ?? sepetDto;
                return Json(new { success = true, sepetUrunu });
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                return StatusCode(500, new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        #region Sepet için Çerez(Cookie) İşlemleri

        private List<SepetDto> CookidenSepetGetir()
        {
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["MusteriSepeti"];
            if (string.IsNullOrEmpty(cookie))
            {
                return new List<SepetDto>(); // Çerez yoksa boş liste döner
            }

            return JsonSerializer.Deserialize<List<SepetDto>>(cookie);
        }

        // Parametreyi List<SepetDto> olarak güncelledik
        private void SepetiCookieyeKaydet(List<SepetDto> guncelSepetListesi)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true
            };

            var jsonString = JsonSerializer.Serialize(guncelSepetListesi);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("MusteriSepeti", jsonString, cookieOptions);
        }

        #endregion


    }
}
