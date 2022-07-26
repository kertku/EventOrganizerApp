using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models.Participations;

namespace WebApp.Controllers;

public class ParticipationsController : Controller
{
    private readonly IAppUnitOfWork _uow;

    public ParticipationsController(IAppUnitOfWork uow)
    {
        _uow = uow;
    }

    //GET
    public async Task<IActionResult> CreateEdit(Guid? id, [FromQuery] string? eventId, [FromQuery] string? user,
        [FromQuery] string? bu)

    {
        var vm = new ParticipationCreateEditVm
        {
            Participation = new Participation(),
            IsBusinessUser = bu != null && bool.Parse(bu)
        };
        if (eventId != null) vm.EventId = Guid.Parse(eventId);
        vm.PaymentTypeSelectList = new SelectList(await _uow.PaymentType.GetAllOrderedAsync(), "Id",
            "PaymentTypeName", vm.Participation?.PaymentTypeId);

        if (bu != null && bool.Parse(bu))
            vm.BusinessUser = new BusinessUser();
        else
            vm.IndividualUser = new IndividualUser();

        if (id == null) return View(vm);

        vm.Participation = await _uow.Participation.FirstOrDefaultAsync(id.Value);
        if (vm.Participation == null) return NotFound();
        if (eventId != null) vm.Participation!.EventId = Guid.Parse(eventId);
        if (bu != null && bool.Parse(bu))
        {
            if (user != null) vm.BusinessUser = await _uow.BusinessUser.FirstOrDefaultAsync(Guid.Parse(user));
        }
        else
        {
            if (user != null) vm.IndividualUser = await _uow.IndividualUser.FirstOrDefaultAsync(Guid.Parse(user));
        }

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
                vm.Participation.EventId = vm.EventId;
                if (vm.IndividualUser != null && vm.IndividualUser.Id == Guid.Empty)
                {
                    var user = _uow.IndividualUser.Add(vm.IndividualUser!);
                    vm.Participation.IndividualUserId = user.Id;
                    vm.Participation.NumberOfParticipants = 1;
                }

                if (vm.BusinessUser != null && vm.BusinessUser.Id == Guid.Empty)
                {
                    var user = _uow.BusinessUser.Add(vm.BusinessUser!);
                    vm.Participation.BusinessUserId = user.Id;
                }

                _uow.Participation.Add(vm.Participation);
                await _uow.SaveChangesAsync();
                return RedirectToAction("EventDetails", "Events", new { id = vm.EventId });
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                vm.Participation.EventId = vm.EventId;
                if (vm.IndividualUser != null && vm.IndividualUser.Id == Guid.Empty)
                {
                    var user = _uow.IndividualUser.Update(vm.IndividualUser!);
                    vm.Participation.IndividualUserId = user.Id;
                }

                if (vm.BusinessUser != null && vm.BusinessUser.Id == Guid.Empty)
                {
                    var user = _uow.BusinessUser.Update(vm.BusinessUser!);
                    vm.Participation.BusinessUserId = user.Id;
                }

                _uow.Participation.Update(vm.Participation);
                await _uow.SaveChangesAsync();
                return RedirectToAction("EventDetails", "Events", new { id = vm.EventId });
            }
        }

        vm.PaymentTypeSelectList = new SelectList(await _uow.PaymentType.GetAllOrderedAsync(), "Id",
            "PaymentType",
            vm.Participation!.PaymentTypeId);

        return View(vm);
    }


    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var participationObj = await _uow.Participation.FirstOrDefaultAsync(id);
        if (participationObj is null) NotFound();

        var vm = new DeleteParticipationVm
        {
            Name = participationObj!.BusinessUserId != null
                ? participationObj.BusinessUser!.CompanyName
                : participationObj.IndividualUser!.FullName,
            Id = id,
            EventName = participationObj.Event!.Name,
            EventId = participationObj.EventId
        };

        return View(vm);
    }


    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteParticipationVm vm)
    {
        await _uow.Participation.RemoveAsync(vm.Id);
        await _uow.SaveChangesAsync();
        return RedirectToAction("EventDetails", "Events", new { id = vm.EventId });
    }
}