using MVCApp.Models;
using System.Threading.Tasks;

namespace MVCApp
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
