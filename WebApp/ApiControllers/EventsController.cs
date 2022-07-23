using AutoMapper;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.Dto.v1.Events;

namespace WebApp.ApiControllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _unitOfWork;


    public EventsController(IMapper mapper, IAppUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet] 
    public async Task<IEnumerable<Events>> GetEventsAsync()
    {
        var eventsList = await _unitOfWork.Event.GetAllWithParticipatesAsync(true);
        return  _mapper.Map<IEnumerable<Events>>(eventsList);
    }
}