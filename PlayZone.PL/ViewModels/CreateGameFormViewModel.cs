using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PlayZone.PL.ViewModels
{
    public class CreateGameFormViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Guid CategoryId { get; set; } = Guid.Empty;

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Required(ErrorMessage = "At least one device must be selected")]
        public List<Guid> SelectedDevices { get; set; } = new List<Guid>();

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(2500, ErrorMessage = "Description cannot exceed 2500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image cover is required")]
        [AllowExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(1 * 1024 * 1024)] // 1 MB
        public IFormFile Cover { get; set; }
    }
}
