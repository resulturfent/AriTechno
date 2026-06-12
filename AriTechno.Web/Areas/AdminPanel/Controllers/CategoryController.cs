using AriTechno.Database.Entities;
using AriTechno.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AriTechno.Web.Areas.AdminPanel.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult List()
    {
        var list = _categoryService.GetAll();
        return View(list);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        bool result=_categoryService.Save(category);
        if (result)
        {
            return RedirectToAction("List");
        }
        ViewBag.ErrorMessage = "Kategori eklenirken bir hata oluştu";
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
