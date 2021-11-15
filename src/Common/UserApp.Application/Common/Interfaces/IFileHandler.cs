using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserApp.Application.Common.Interfaces
{
    public interface IFileHandler
    {
        Task<IEnumerable<T>> GetContentInJsonAsync<T>(string filePath) where T : class, new();

        Task<IEnumerable<T>> SaveFileAsync<T>(string fileDirectory, T record) where T : class, new();
    }
}