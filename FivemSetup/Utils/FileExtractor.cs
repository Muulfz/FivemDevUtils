using System.IO.Compression;

namespace FivemSetup.Utils
{
    public class FileExtractor
    {
        public static async void Zip(string filePath, string extractLocation)
        {
            using (var zip = ZipFile.OpenRead(filePath))
            {
               zip.ExtractToDirectory(extractLocation,true);
            }
        }
    }
}