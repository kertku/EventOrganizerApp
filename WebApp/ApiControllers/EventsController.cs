using AutoMapper;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public EventsController(IMapper mapper, IAppUnitOfWork unitOfWork, ILogger logger)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<Event>> GetEventsAsync()
    {
        var eventsList = await _unitOfWork.Event.GetAllWithParticipatesAsync(true);
        return _mapper.Map<IEnumerable<Event>>(eventsList);
    }
}