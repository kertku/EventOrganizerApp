using AutoMapper;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models.IndividualUsers;

namespace WebApp.Controllers;

public class IndividualUserController : Controller
{
    private readonly IAppUnitOfWork _uow;
    private readonly IMapper _mapper;

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