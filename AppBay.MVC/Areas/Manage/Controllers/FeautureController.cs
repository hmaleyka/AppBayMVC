using AppBay.Business.Services.Interfaces;
using AppBay.Business.ViewModels.FeatureVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AppBay.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class FeautureController : Controller
    {
        private readonly IFeatureService _service;

        public FeautureController(IFeatureService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var features = await _service.GetAllAsync();
            return View(features);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureVM feature)
        {
            await _service.Create(feature);
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateFeatureVM feature)
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
