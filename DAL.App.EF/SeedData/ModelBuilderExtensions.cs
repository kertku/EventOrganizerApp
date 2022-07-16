using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.SeedData;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentType>().HasData(
            new PaymentType { Id = Guid.NewGuid(), PaymentTypeName = "Kaardimakse" },
            new PaymentType { Id = Guid.NewGuid(), PaymentTypeName = "Sularaha" }
        );

        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                Id = Guid.NewGuid(), Date = new DateTime(2022, 9, 15), Name = "Suvine seminar",
                Information = "Osad räägivad, teised kuulavad.", Location = "Ärimajas"
            },
            new Event
            {
                Id = Guid.NewGuid(), Date = new DateTime(2022, 6, 13), Name = "Eilene üritus",
                Information = "Osad räägivad, teised kuulavad.", Location = "Linnahall"
            },
            new Event
            {
                Id = Guid.NewGuid(), Date = new DateTime(2022, 7, 22), Name = "Suvepäevad",
                Information = "Saame kokku ja kuulame", Location = "Metsas"
            },
            new Event
            {
                Id = Guid.NewGuid(), Date = new DateTime(2022, 4, 20), Name = "Juhi sünnipäev",
                Information = "Tasub kindlasti tulla kõigil.", Location = "Aia 33, Tallinn"
            }
        );
        modelBuilder.Entity<IndividualUser>().HasData(
            new IndividualUser
            {
                Id = Guid.NewGuid(), FirstName = "Kaupe", LastName = "Kask", Information = "tubli",
                IdentificationCode = 46611110222
            },
            new IndividualUser
            {
                Id = Guid.NewGuid(), FirstName = "Piia", LastName = "Tulp", Information = "Infot palju ei ole",
                IdentificationCode = 46311110222
            },
            new IndividualUser
            {
                Id = Guid.NewGuid(), FirstName = "Aivar", LastName = "Roos", Information = "test",
                IdentificationCode = 46411110222
            },
            new IndividualUser
            {
                Id = Guid.NewGuid(), FirstName = "Kalle", LastName = "Sinilill", Information = "test",
                IdentificationCode = 46111110222
            }
        );

        modelBuilder.Entity<BusinessUser>().HasData(
            new BusinessUser { Id = Guid.NewGuid(), CompanyName = "Tublitöö As", RegistryCode = 77443382 },
            new BusinessUser { Id = Guid.NewGuid(), CompanyName = "Kõva Kate OÜ", RegistryCode = 77443382 },
            new BusinessUser { Id = Guid.NewGuid(), CompanyName = "Teeme Tööd OÜ", RegistryCode = 77443382 },
            new BusinessUser { Id = Guid.NewGuid(), CompanyName = "Testiminse AS", RegistryCode = 77443382 }
        );
    }
}