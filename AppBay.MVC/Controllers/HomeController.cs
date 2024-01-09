using AppBay.Business.ViewModels;
using AppBay.DAL.Context;
using AppBay.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppBay.MVC.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

	

        public IActionResult Index()
        {
            HomeVM homevm = new HomeVM()
            {
                features = _context.features.ToList(),
            };
            return View(homevm);
        }

      
    }
}