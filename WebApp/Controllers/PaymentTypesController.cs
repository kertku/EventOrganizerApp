using AutoMapper;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.PaymentTypes;

namespace WebApp.Controllers;

[Route("admin/[controller]/[action]")]
public class PaymentTypesController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _uow;

    public PaymentTypesController(IMapper mapper, IAppUnitOfWork uow)
    {
        _mapper = mapper;
        _uow = uow;
    }
    [Route("/admin/PaymentTypes")]
    public async Task<IActionResult> Index()
    {
        return View(await _uow.PaymentType.GetAllOrderedAsync());
    }

    //GET 
    public async Task<IActionResult> CreateEdit(Guid? id)
    {
        var vm = new PaymentTypeVm();
        if (id == null) return View(vm);
        vm.Id = (Guid)id;
        var paymentType = await _uow.PaymentType.FirstOrDefaultAsync(id.Value);
        if (paymentType != null) vm.PaymentTypeName = paymentType.PaymentTypeName;
        return View(vm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(PaymentTypeVm vm)
    {
        if (vm.Id == Guid.Empty)
        {
            if (ModelState.IsValid)
            {
                _uow.PaymentType.Add(_mapper.Map<PaymentType>(vm));
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            _uow.PaymentType.Update(_mapper.Map<PaymentType>(vm));
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(vm);
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null) return NotFound();
        var paymentType = await _uow.PaymentType.FirstOrDefaultAsync(id.Value);

        if (paymentType == null) return NotFound();
        return View(_mapper.Map<PaymentTypeVm>(paymentType));
    }


    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _uow.PaymentType.RemoveAsync(id);
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}