using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.Dto.v1.Events;

public class Events
{
    [DisplayName("Ürituse nimi")] public string Name { get; set; } = default!;

    [DisplayName("Toimumisaeg")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
    public DateTime Date { get; set; }

    [DisplayName("Toimumiskoht")] public string Location { get; set; } = default!;

    [StringLength(1000, ErrorMessage = "{0} välja pikkus maksimaalselt {1} märki!")]
    [DisplayName("Informatsioon")]
    public string Information { get; set; } = default!;

    public IEnumerable<string> Participates { get; set; } = default!;

    public int ParticipationCount { get; set; }
}