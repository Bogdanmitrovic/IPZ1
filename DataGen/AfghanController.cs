using Microsoft.AspNetCore.Mvc;
using DataGen.Models;

namespace DataGen
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AfghanController(AfghanContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AddOrganizations()
        {
            try
            {
                var organizations = Lists.Organizations.Select(o => new Organization
                {
                    OrganizationId = Guid.NewGuid().ToString(),
                    Name = o,
                    Country = "Afghanistan"
                });
                await context.Organizations.AddRangeAsync(organizations);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddLocations()
        {
            for (var i = 0; i < 100; i++)
            {
                var location = new Location
                {
                    LocationId = Guid.NewGuid().ToString(),
                    Name = Lists.AfghanEncounterLocations[Random.Shared.Next(Lists.AfghanEncounterLocations.Length)],
                    Country = "Afghanistan",
                    Region = Lists.AfghanRegions[Random.Shared.Next(Lists.AfghanRegions.Length)],
                    Latitude = (int)(Random.Shared.NextDouble() * 10) + 30,
                    Longitude = (int)(Random.Shared.NextDouble() * 10) + 60
                };
                await context.Locations.AddAsync(location);
            }

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> AddAfghans()
        {
            var organizations = context.Organizations.ToList();
            for (var i = 0; i < 100; i++)
            {
                var afghan = new Afghan
                {
                    AfghanId = Guid.NewGuid().ToString(),
                    Name = Lists.Names[Random.Shared.Next(Lists.Names.Length)],
                    Surname = Lists.Surnames[Random.Shared.Next(Lists.Surnames.Length)],
                    Gender = Random.Shared.Next(10) % 10 == 0 ? "Female" : "Male",
                    Role = Lists.Roles[Random.Shared.Next(Lists.Roles.Length)],
                    Age = Random.Shared.Next(18, 60),
                    OrganizationId =
                        organizations.Select(o => o.OrganizationId).ToList()[
                            Random.Shared.Next(organizations.Count)]
                };
                await context.Afghans.AddAsync(afghan);
            }

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> AddUnits()
        {
            for (var i = 0; i < 10; i++)
            {
                var unit = new Unit()
                {
                    UnitId = Guid.NewGuid().ToString(),
                    Name = Lists.AmericanMilitaryUnits[Random.Shared.Next(Lists.AmericanMilitaryUnits.Length)]
                };
                await context.Units.AddAsync(unit);
            }

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> AddGroups()
        {
            var afghanIds = context.Afghans.Select(a => a.AfghanId).ToList();
            var id = Guid.NewGuid().ToString();
            foreach (var afghanInGroup in afghanIds.Select(t => new AfghansInGroups
                     {
                         AfghanId = t,
                         GroupId = id
                     }))
            {
                await context.AfghansInGroups.AddAsync(afghanInGroup);
                if (Random.Shared.Next(10) % 10 == 0)
                {
                    id = Guid.NewGuid().ToString();
                }
            }

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> AddMilitaryPersonnel()
        {
            var units = context.Units.ToList();
            foreach (var u in units)
            {
                var militaryPersonnel = new MilitaryPersonnel
                {
                    MilitaryPersonnelId = Guid.NewGuid().ToString(),
                    Name = Lists.AmericanNames[Random.Shared.Next(Lists.AmericanNames.Length)],
                    Surname = Lists.AmericanSurnames[Random.Shared.Next(Lists.AmericanSurnames.Length)],
                    Rank = Lists.AmericanMilitaryRanks.Last(),
                    UnitID = u.UnitId,
                    Age = Random.Shared.Next(18, 60)
                };
                await context.MilitaryPersonnel.AddAsync(militaryPersonnel);
                u.CommanderId = militaryPersonnel.MilitaryPersonnelId;
            }

            for (var i = 0; i < 40; i++)
            {
                var militaryPersonnel = new MilitaryPersonnel
                {
                    MilitaryPersonnelId = Guid.NewGuid().ToString(),
                    Name = Lists.AmericanNames[Random.Shared.Next(Lists.AmericanNames.Length)],
                    Surname = Lists.AmericanSurnames[Random.Shared.Next(Lists.AmericanSurnames.Length)],
                    Rank = Lists.AmericanMilitaryRanks[Random.Shared.Next(Lists.AmericanMilitaryRanks.Length)],
                    UnitID = units[Random.Shared.Next(units.Count)].UnitId,
                    Age = Random.Shared.Next(18, 60)
                };
                await context.MilitaryPersonnel.AddAsync(militaryPersonnel);
            }

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> AddEncounters()
        {
            var afghans = context.Afghans.ToList();
            var locations = context.Locations.ToList();
            var units = context.Units.ToList();
            var groups = context.AfghansInGroups.ToList();
            for (var i = 0; i < 100; i++)
            {
                var encounter = new Encounter
                {
                    EncounterId = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now.AddDays(-Random.Shared.Next(365 * 3)).AddHours(12 - Random.Shared.Next(24))
                        .AddMinutes(30 - Random.Shared.Next(60)),
                    LocationId = locations[Random.Shared.Next(locations.Count)].LocationId,
                    GroupId = groups[Random.Shared.Next(groups.Count)].GroupId,
                    UnitId = units[Random.Shared.Next(units.Count)].UnitId,
                    NumberOfCivilians = Random.Shared.Next(10),
                    NumberOfCasualties = Random.Shared.Next(10)
                };
                await context.Encounters.AddAsync(encounter);
            }

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}