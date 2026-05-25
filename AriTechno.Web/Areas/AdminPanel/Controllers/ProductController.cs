using Microsoft.AspNetCore.Mvc;

namespace AriTechno.Web.Areas.AdminPanel.Controllers;

public class ProductController : Controller
{
    public IActionResult List()
    {
        return View();
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
