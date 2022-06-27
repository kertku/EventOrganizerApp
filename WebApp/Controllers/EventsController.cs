using DAL.App.EF;
using Domain.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    
    public async Task<IActionResult> Create()
    {
  
        return  View();
    }

    // POST: PartInPartsStocks/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Event @event)
    {
        if (ModelState.IsValid)
        {
            _ctx.Events.Add(@event);
            await _ctx.SaveChangesAsync();
            return RedirectToAction( nameof(Index), "Home");
        }
        return View(@event);
    }
    
}