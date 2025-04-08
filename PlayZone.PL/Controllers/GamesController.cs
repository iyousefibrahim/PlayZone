using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayZone.BLL.Interfaces;
using PlayZone.DAL.Models;
using PlayZone.PL.Helpers;
using PlayZone.PL.ViewModels;

namespace PlayZone.PL.Controllers
{
    public class GamesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
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



    }
}
