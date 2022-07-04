using AutoMapper;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class IndividualUserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _uow;

    public IndividualUserController(IAppUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /*public async Task<IActionResult> CreateEdit(Guid? id)
    {
        var vm = new IndividualUserCreateEditViewModel();
        vm.IndividualUser = new IndividualUser();
        vm.PaymentTypeSelectList = new SelectList(await _uow.PaymentType.GetAllOrderedAsync(), "Id",
            "ProductionLineSectionName", vm.IndividualUser.);

        if (id == null) return View(vm);

        vm.WorkRequest = await _bll.WorkRequests.FirstOrDefaultAsync(id.Value);
        if (vm.WorkRequest == null) return NotFound();

        return View(vm);
    }*/
}