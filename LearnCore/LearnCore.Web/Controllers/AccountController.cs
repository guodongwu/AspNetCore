using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnCore.Application.UserMapper;
using Microsoft.AspNetCore.Mvc;

namespace LearnCore.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetUsers();
            return View(model);
        }
    }
}