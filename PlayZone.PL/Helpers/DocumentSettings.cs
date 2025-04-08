namespace PlayZone.PL.Helpers
{
    public class DocumentSettings
    {
        public static async Task<string> UploadFileAsync(IFormFile file, string folderPath)
        {
            try
            {
                // Ensure the folder exists, create it if it doesn't
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Generate a unique file name (optional, based on the current timestamp or GUID)
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(directoryPath, fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                // Log the error (consider using a logger here)
                Console.WriteLine($"Error uploading file: {ex.Message}");
                throw new InvalidOperationException("Error uploading file.", ex);
            }
        }


    }
}
