using AppBay.Business.Services.Interfaces;
using AppBay.Business.ViewModels.FeatureVM;
using AppBay.Core.Entities;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Index()
        {
            var features = await _service.GetAllAsync();
            return View(features);
        }
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureVM feature)
        {
            await _service.Create(feature);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Update(int id)
        {
            Feature features = await _service.GetByIdAsync(id);
			UpdateFeatureVM vm = new UpdateFeatureVM()
			{
				Title = features.Title,
				Description = features.Description,
				Icon = features.Icon,
			};
			return View(vm);
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureVM feature)
        {
            await _service.Update(feature);
         
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Delete(int id)
        {
            Feature features = await _service.GetByIdAsync(id);
            _service.Delete(features);

            return RedirectToAction("Index");
        }
    }
}
