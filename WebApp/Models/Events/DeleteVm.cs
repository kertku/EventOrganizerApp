namespace WebApp.Models.Events;

public class DeleteVm
{
    public Guid Id { get; set; }
    public string EventName { get; set; } = default!;
    public DateTime Date { get; set; }
}