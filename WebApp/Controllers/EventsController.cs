using DAL.App.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

public class EventsController : Controller
{
    private readonly AppDbContext _ctx;

    public EventsController(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _ctx.Events.ToListAsync());
    }
}