using AutoMapper;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class BusinessUserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _uow;

    public BusinessUserController(IAppUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
}