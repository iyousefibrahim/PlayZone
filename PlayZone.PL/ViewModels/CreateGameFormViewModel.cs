using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PlayZone.PL.ViewModels
{
    public class CreateGameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public List<Guid> SelectedDevices { get; set; }
        public IEnumerable<SelectListItem> Devices { get; set; }
        [MaxLength(2500)]

        public string Description { get; set; }

        public IFormFile Cover { get; set; }

    }
}
