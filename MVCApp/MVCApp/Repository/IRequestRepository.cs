using MVCApp.Models;
using System.Threading.Tasks;

namespace MVCApp.Repository
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);

        Task<Request[]> GetRequests();
    }
}
