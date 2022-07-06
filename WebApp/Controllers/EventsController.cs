using AutoMapper;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Events;

namespace WebApp.Controllers;

public class EventsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _uow;

    public EventsController(IAppUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _uow.Event.GetAllOrderedAsync());
    }

    public Task<IActionResult> Create()
    {
        return Task.FromResult<IActionResult>(View());
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
            _uow.Event.Add(@event);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        return View(@event);
    }

    public async Task<IActionResult> EventDetails(Guid id)
    {
        var eventWithParticipates = await _uow.Event.GetEventWithParticipatesAsync(id, true);
        return View(_mapper.Map<EventDetailsViewVm>(eventWithParticipates));
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _uow.Event.RemoveAsync(id);
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index), "Home");
    }
}