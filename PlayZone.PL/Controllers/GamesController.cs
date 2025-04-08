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
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
