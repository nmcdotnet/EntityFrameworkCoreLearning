
using EFCore.Data;
using Microsoft.EntityFrameworkCore; ;

using var context = new FootballLeageDbContext();


//await GetAllTeamWithSelect();
await GetAllTeam();


async Task SkipAndTakeMethod()
{
    while (true)
    {
        var page = Console.ReadLine();
        var pageData = context.Teams.Skip(int.Parse(page)-1).Take(1);
        foreach (var team in pageData)
        {
            await Console.Out.WriteLineAsync(team.Name);
        }
    }
   
}
async Task OrderByMethod()
{
    var orderTeams1 = context.Teams.OrderBy(t => t.Name);
    foreach (var team in orderTeams1)
    {
        await Console.Out.WriteLineAsync(team.Name);
    }

    var orderTeams2 = context.Teams.OrderByDescending(t => t.Name);
    foreach (var team in orderTeams2)
    {
        await Console.Out.WriteLineAsync(team.Name);
    }
}
async Task GroupByMethod()
{
    var groupTeams = context.Teams.GroupBy(t => t.Level);
    foreach (var group in groupTeams)
    {
        await Console.Out.WriteLineAsync("Group key: " + group.Key);
        foreach (var team in group) // Retrieve teams from a group of teams
        {
            await Console.Out.WriteLineAsync($"Team in group key ${group.Key}: {team.Name}"); 
        }
    }
}
async Task AggregateMethod()
{
    var numberOfTeams = await context.Teams.CountAsync();
    var numberOfTeamWithCondition =  await context.Teams.CountAsync(t=> t.TeamId.Equals(1));
    Console.WriteLine($"Number of team: {numberOfTeams}");
    Console.WriteLine($"Number of team with ID = 1: {numberOfTeamWithCondition}");

    var maxId = context.Teams.MaxAsync(t => t.TeamId); 
    var minId = context.Teams.MinAsync(t => t.TeamId);
    var avgId = context.Teams.AverageAsync(t => t.TeamId); //
    var sumId = context.Teams.SumAsync(t => t.TeamId);  // 6

    await Console.Out.WriteLineAsync($"maxId: {maxId.Result}");
    await Console.Out.WriteLineAsync($"minId: {minId.Result}");
    await Console.Out.WriteLineAsync($"avgId: {avgId.Result}");
    await Console.Out.WriteLineAsync($"sumId: {sumId.Result}");


}

async Task FilterQuery()
{
    Console.WriteLine("Enter search Term: ");
    var desiredTeam = Console.ReadLine();
    //var teamsFiltered = await context.Teams.Where(t=>t.Name.Contains(desiredTeam)).ToListAsync();
    var teamsFiltered = await context.Teams.Where(t => EF.Functions.Like(t.Name, $"%{desiredTeam}%")).ToListAsync();
    foreach (var team in teamsFiltered)
    {
        Console.WriteLine(team.Name);
    }
}

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
    var teamList = await context.Teams.ToListAsync();
    foreach (var team in teamList)
    {
        Console.WriteLine(team.Name);
    }
}

async Task GetAllTeamWithSelect()
{
    var teamNameList = await context.Teams
        .Select(t => t.Name)
        .ToListAsync();
    foreach(var name in teamNameList)
    {
        await Console.Out.WriteLineAsync(name);
    }
}
