using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayZone.BLL.Interfaces;
using PlayZone.DAL.Models;
using PlayZone.PL.Helpers;
using PlayZone.PL.Models;
using PlayZone.PL.ViewModels;

namespace PlayZone.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var games = await _unitOfWork.GameRepository.GetAllAsync();
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var devices = await _unitOfWork.DeviceRepository.GetAllAsync();

            return View(games);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
