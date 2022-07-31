using AutoMapper;
using Contracts.DAL.App;
using DAL.App.DTO;
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
        var eventsList = await _unitOfWork.Event.GetAllOrderedAsync();
        return _mapper.Map<IEnumerable<Events>>(eventsList);
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    public async Task<ActionResult<Events>> GetEvent(Guid id)
    {
        var eventObj = await _unitOfWork.Event.FirstOrDefaultAsync(id);
        if (eventObj is null) return NotFound();
        return _mapper.Map<Events>(eventObj);
    }

    // POST: api/Event
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EventPost), StatusCodes.Status200OK)]
    public async Task<ActionResult<EventPost>> PostEvent(EventPost eventObj)
    {
        var addEvent = _unitOfWork.Event.Add(_mapper.Map<Event>(eventObj));
        await _unitOfWork.SaveChangesAsync();

        var returnEvent = _mapper.Map<Events>(addEvent);

        return CreatedAtAction("GetEvent", new
        {
            id = addEvent.Id,
            version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"
        }, returnEvent);
    }
}