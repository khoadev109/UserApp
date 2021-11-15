using System.Threading;
using System.Threading.Tasks;

namespace UserApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
