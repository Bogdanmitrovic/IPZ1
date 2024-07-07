using System.ComponentModel.DataAnnotations;

namespace DataGen.Models;

public class Organization
{
    [Key]
    public string OrganizationId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}