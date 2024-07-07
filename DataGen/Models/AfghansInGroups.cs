using Microsoft.EntityFrameworkCore;

namespace DataGen.Models;

[PrimaryKey(nameof(AfghanId), nameof(GroupId))] 
public class AfghansInGroups
{
    public string AfghanId { get; set; }
    public string GroupId { get; set; }
}