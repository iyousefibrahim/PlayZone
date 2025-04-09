using PlayZone.PL.ViewModels;

public class EditGameFormViewModel : GameFormViewModel
{
    public Guid Id { get; set; }

    [AllowExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
    [MaxFileSize(1 * 1024 * 1024)] // 1 MB
    public IFormFile? Cover { get; set; }

    public string? CurrentCover { get; set; }
}