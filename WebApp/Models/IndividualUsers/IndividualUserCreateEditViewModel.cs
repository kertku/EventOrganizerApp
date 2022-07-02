using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models.IndividualUsers;

public class IndividualUserCreateEditViewModel
{
    public IndividualUser? IndividualUser { get; set; }
    public SelectList? PaymentTypeSelectList { get; set; }
}