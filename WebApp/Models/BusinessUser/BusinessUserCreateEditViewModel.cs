using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models.BusinessUser;

public class BusinessUserCreateEditViewModel
{
    public DAL.App.DTO.BusinessUser? BusinessUser { get; set; }
    public SelectList? PaymentType { get; set; }
}