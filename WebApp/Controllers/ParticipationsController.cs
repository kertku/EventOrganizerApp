using AutoMapper;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models.Participations;

namespace WebApp.Controllers;

public class ParticipationsController : Controller
{
    private readonly IAppUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ParticipationsController(IAppUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IActionResult> CreateEdit(Guid? id)
    {
        var vm = new ParticipationCreateEditVm();
        vm.IndividualUser = new IndividualUser();
        vm.PaymentTypeSelectList = new SelectList(await _uow.PaymentType.GetAllOrderedAsync(), "Id",
            "PaymentTypeName", vm.Participation?.PaymentTypeId);

        if (id == null) return View(vm);

        vm.Participation = await _uow.Participation.FirstOrDefaultAsync(id.Value);
        if (vm.Participation == null) return NotFound();

        return View(vm);
    }
}