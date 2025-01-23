using Microsoft.AspNetCore.Mvc.Razor;

namespace KidKinder.Extensions
{
    public static class FileExtension
    {
        public static bool IsValidType(this IFormFile file,string type)
            => file.ContentType.StartsWith(type);

        public static bool IsValidSize(this IFormFile file, int kb)
            => file.Length < kb * 1024;

        public static async Task<string> UploadAsync(this IFormFile file, params string[] paths)
        {
            string fileUpload = Path.Combine(paths);
            if (!Path.Exists(fileUpload))
            {
                Directory.CreateDirectory(fileUpload);
            }
            string newFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
            using(Stream stream = File.Create(Path.Combine(fileUpload, newFileName)))
            {
                await file.CopyToAsync(stream);
            }
            return newFileName;
        }
    }
}
