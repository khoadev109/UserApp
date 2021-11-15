using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserApp.Application.Common.Interfaces;

namespace UserApp.Infrastructure.Files
{
    public class FileHandler : IFileHandler
    {
        public async Task<IEnumerable<T>> GetContentInJsonAsync<T>(string fileDirectory) where T : class, new()
        {
            EnsureDirectory(fileDirectory);
            FileStream stream = EnsureFile(Path.Combine(fileDirectory, "users.json"));

            var result = stream.Length > 0
                ? await JsonSerializer.DeserializeAsync<IEnumerable<T>>(stream)
                : Enumerable.Empty<T>();

            await stream.DisposeAsync();

            return result;
        }

        public async Task<IEnumerable<T>> SaveFileAsync<T>(string fileDirectory, T record) where T : class, new()
        {
            EnsureDirectory(fileDirectory);

            var filePath = Path.Combine(fileDirectory, "users.json");
            FileStream stream = EnsureFile(filePath);

            await stream.DisposeAsync();

            List<T> records = new();

            using (StreamReader streamReader = new(filePath))
            {
                string content = await streamReader.ReadToEndAsync();
                if (content.Length > 0)
                {
                    records = JsonSerializer.Deserialize<List<T>>(content);
                }
                records.Add(record);
            }

            string result = JsonSerializer.Serialize(records);

            await File.WriteAllTextAsync(filePath, result);

            return records;
        }

        private void EnsureDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private FileStream EnsureFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream stream = File.Create(filePath);
                return stream;
            }
            else
            {
                FileStream stream = File.OpenRead(filePath);
                return stream;
            }
        }
    }
}
