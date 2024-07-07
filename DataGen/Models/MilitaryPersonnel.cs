using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataGen.Models;

public class MilitaryPersonnel
{
    [Key]
    public string MilitaryPersonnelId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Rank { get; set; }
    public string UnitID { get; set; }
    public int Age { get; set; }
}