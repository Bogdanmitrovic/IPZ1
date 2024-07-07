using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataGen.Models;

public class Unit
{
    [Key]
    public string UnitId { get; set; }
    public string Name { get; set; }
    public string? CommanderId { get; set; }
}