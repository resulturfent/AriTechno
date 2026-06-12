using AriTechno.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AriTechno.Web.Areas.AdminPanel.Controllers;

public class ProductController : Controller
{

    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService= productService;
    }
    public IActionResult List()
    {
        return View(_productService.GetAll());
    }

    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Update()
    {
        return View();
    }
    public IActionResult Delete()
    {
        return View();
    }
}
