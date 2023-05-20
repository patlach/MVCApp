using Microsoft.AspNetCore.Mvc;
using MVCApp.Repository;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class LogController : Controller
    {
        private readonly IRequestRepository _requestRepository;

        public LogController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _requestRepository.GetRequests();

            return View(requests);
        }
    }
}
