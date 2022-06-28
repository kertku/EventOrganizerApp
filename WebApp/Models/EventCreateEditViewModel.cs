using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.App.Validators;

namespace WebApp.Models;

public class EventCreateEditViewModel
{
    public string Name { get; set; } = default!;

    [DateHigherOrEqualToToday] public DateTime Date { get; set; }

    public string Location { get; set; } = default!;

    [StringLength(5000)] public string Information { get; set; } = default!;
}