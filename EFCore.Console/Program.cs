
using EFCore.Data;
using Microsoft.EntityFrameworkCore; ;

using var context = new FootballLeageDbContext();

// Filter
await FilterQuery();
async Task FilterQuery()
{ 
    var teamsFiltered = await context.Teams.Where(t=>t.Name == "Tivoli Gardens FC").ToListAsync();
    foreach(var team in teamsFiltered)
    {
        Console.WriteLine(team.Name);
    }
}


#region Functions List
//await GetAllTeam();
async Task SelectSingleRecord()
{
    // select a single record - first one in the list
    var team1 = await context.Teams.FirstAsync();

    // Select a single record - first one in the list that meets a condition
    var team2 = await context.Teams.FirstAsync(team => team.TeamId == 1);
}
async Task GetAllTeam()
{
    // SELECT * Form Teams
    DbSet<EFCore.Domain.Team> teams = context.Teams;
    var teamList = await teams.ToListAsync();
    foreach (var team in teamList)
    {
        Console.WriteLine(team.Name);
    }
}
#endregion

