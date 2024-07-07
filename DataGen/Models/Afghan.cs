using System.ComponentModel.DataAnnotations;

namespace DataGen.Models;

public class Afghan
{
    [Key]
    public string AfghanId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    public string OrganizationId { get; set; }
}