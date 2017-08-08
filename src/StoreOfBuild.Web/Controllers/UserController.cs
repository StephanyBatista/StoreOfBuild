using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class UserController : Controller
    {
        private readonly IManager _manager;

        public UserController(IManager manager){

            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.ListAll();
            var usersViewModel = users.Select(u => new UserViewModel{Id = u.Id, Email = u.Email});
            return View(usersViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            await _manager.CreateAsync(viewModel.Email, viewModel.Password, viewModel.Role);
            return Ok();
        }
    }
}