using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAppUnitOfWork _uow;

    public HomeController(ILogger<HomeController> logger, IAppUnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _uow.Event.GetAllOrderedAsync());
    }
}