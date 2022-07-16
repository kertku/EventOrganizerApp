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

    //GET
    public async Task<IActionResult> Delete(Guid id)
    {
        var eventObj = await _uow.Event.FirstOrDefaultAsync(id);
        var vm = new DeleteVm();
        if (eventObj != null) vm.EventName = eventObj.Name;
        vm.Id = id;
        if (eventObj != null) vm.Date = eventObj.Date;
        return View(vm);
    }


    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteVm vm)
    {
        await _uow.Event.RemoveAsync(vm.Id);
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index), "Home");
    }
}