using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;


public class DefaultController(DataContext dataContext) : Controller
{
    private readonly DataContext _dataContext = dataContext;

    [Route("/")]
    public IActionResult Home()
    {
        return View();
    }

    #region Features
    [Route("/features")]
    public IActionResult Features()
    {
        return RedirectToAction("Home", "Default", "features");
    }
    #endregion      

}
