using AutoMapper;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models.Participations;

namespace WebApp.Controllers;

public class ParticipationsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _uow;

    public ParticipationsController(IAppUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    //GET
    public async Task<IActionResult> CreateEdit(Guid? id, [FromQuery] string? eventId, [FromQuery] string? user)
    {
        var vm = new ParticipationCreateEditVm();
        vm.Participation = new Participation();
        vm.IndividualUser = new IndividualUser();
        if (eventId != null) vm.EventId = Guid.Parse(eventId);
        vm.PaymentTypeSelectList = new SelectList(await _uow.PaymentType.GetAllOrderedAsync(), "Id",
            "PaymentTypeName", vm.Participation?.PaymentTypeId);

        if (id == null) return View(vm);

        vm.Participation = await _uow.Participation.FirstOrDefaultAsync(id.Value);
        if (eventId != null) vm.Participation!.EventId = Guid.Parse(eventId);
        if (user != null) vm.IndividualUser = await _uow.IndividualUser.FirstOrDefaultAsync(Guid.Parse(user));
        if (vm.Participation == null) return NotFound();

        return View(vm);
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(
        ParticipationCreateEditVm vm)
    {
        if (vm.Participation!.Id == Guid.Empty)
        {
            if (ModelState.IsValid)
            {
                var user = _uow.IndividualUser.Add(vm.IndividualUser!);
                vm.Participation.EventId = vm.EventId;
                vm.Participation.IndividualUserId = user.Id;
                _uow.Participation.Add(vm.Participation);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Home");
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                var user = _uow.IndividualUser.Update(vm.IndividualUser!);
                vm.Participation.EventId = vm.EventId;
                vm.Participation.IndividualUserId = user.Id;
                _uow.Participation.Update(vm.Participation);
                await _uow.SaveChangesAsync();
                return RedirectToAction("EventDetails", "Events", new { id = vm.Participation.EventId });
            }
        }

        vm.PaymentTypeSelectList = new SelectList(await _uow.PaymentType.GetAllOrderedAsync(), "Id",
            "PaymentType",
            vm.Participation!.PaymentTypeId);

        return View("~/Views/Events/EventDetails.cshtml");
    }
}