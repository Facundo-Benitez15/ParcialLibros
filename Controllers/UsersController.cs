using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParcialLibros.Models;
using ParcialLibros.Views.Users.ViewModels;

namespace ParcialLibros.Controllers;
[Authorize]
public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        //Listar usuarios
        var users = _userManager.Users.ToList();
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user != null)
        {
            await _userManager.AddToRoleAsync(user, model.Role);
        }

        return RedirectToAction("Index");
    }

}
