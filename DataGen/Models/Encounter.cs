using System.ComponentModel.DataAnnotations;

namespace DataGen.Models;

public class Encounter
{
    [Key]
    public string EncounterId { get; set; }
    public DateTime Timestamp { get; set; }
    public string LocationId { get; set; }
    public string GroupId { get; set; }
    public string UnitId { get; set; }
    public int NumberOfCivilians { get; set; }
    public int NumberOfCasualties { get; set; }
}