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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var devices = await _unitOfWork.DeviceRepository.GetAllAsync();

            var viewModel = new CreateGameFormViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }),

                Devices = devices.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel game)
        {
            if (ModelState.IsValid)
            {
                string coverFileName = null;
                if (game.Cover != null)
                {
                    coverFileName = await DocumentSettings.UploadFileAsync(game.Cover, "assets/images/games");
                }

                var gameEntity = new Game
                {
                    Name = game.Name,
                    Description = game.Description,
                    CategoryId = game.CategoryId,
                    Cover = coverFileName,
                    Device = game.SelectedDevices.Select(d => new GameDevice
                    {
                        DeviceId = d
                    }).ToList(),
                };

                await _unitOfWork.GameRepository.CreateAsync(gameEntity);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var devices = await _unitOfWork.DeviceRepository.GetAllAsync();

            var viewModel = new CreateGameFormViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }),

                Devices = devices.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
            };

            return View(viewModel);
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
