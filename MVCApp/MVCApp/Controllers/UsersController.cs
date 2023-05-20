using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using System;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public UsersController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _blogRepository.GetUsers();

            foreach (var author in authors)
            {
                Console.WriteLine($"Author name: {author.FirstName}, joined {author.JoinDate}");
            }

            return View(authors);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _blogRepository.AddUser(newUser);
            return View(newUser);
        }
    }
}
