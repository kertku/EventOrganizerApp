using AutoMapper;
using Contracts.DAL.App;
using DAL.App.EF;
using Domain.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Events;

namespace WebApp.Controllers;

public class EventsController : Controller
{

    private readonly IAppUnitOfWork _uow;
    private readonly IMapper _mapper;

    public EventsController( IAppUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _uow.Event.GetAllOrderedAsync());
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
    public async Task<IActionResult> Create(DAL.App.DTO.Event @event)
    {
        if (ModelState.IsValid)
        {
            _uow.Event.Add(@event);
            await _uow.SaveChangesAsync();
            return RedirectToAction( nameof(Index), "Home");
        }
        return View(@event);
    }
    
    public async Task<IActionResult> EventDetails(Guid id)
    {
        var eventWithParticipates = await _uow.Event.GetEventWithParticipatesAsync(id, true);
        return View(_mapper.Map<EventDetailsViewVm>(eventWithParticipates));

    }
    
}