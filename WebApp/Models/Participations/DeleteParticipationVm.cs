namespace WebApp.Models.Participations;

public class DeleteParticipationVm
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string EventName { get; set; } = default!;
    public string Name { get; set; } = default!;
}