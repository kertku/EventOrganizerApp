using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.App.Validators;

namespace WebApp.Models.Events;

public class EventDetailsViewVm
{
    [DisplayName("Ürituse nimi")] public string Name { get; set; } = default!;

    [DateHigherOrEqualToToday]
    [DisplayName("Toimumisaeg")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
    public DateTime Date { get; set; }

    [DisplayName("Koht")] public string Location { get; set; } = default!;

    [DisplayName("Osavõtjad")]
    public List<Participation>? Participations { get; set; } = new();
}