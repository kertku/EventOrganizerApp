using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models.Participations;

public class ParticipationCreateEditVm
{
    public Participation? Participation { get; set; }
    public DAL.App.DTO.BusinessUser? BusinessUser { get; set; }
    public IndividualUser? IndividualUser { get; set; }
    public SelectList? PaymentTypeSelectList { get; set; }
}