using System.ComponentModel.DataAnnotations;

public class AllowExtensions : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowExtensions(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!_extensions.Contains(extension))
            {
                return new ValidationResult($"Only the following extensions are allowed: {string.Join(", ", _extensions)}");
            }
        }

        return ValidationResult.Success;
    }
}
