using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PlayZone.PL.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {
        [Required(ErrorMessage = "Image cover is required")]
        [AllowExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(1 * 1024 * 1024)] // 1 MB
        public IFormFile Cover { get; set; }
    }
}
