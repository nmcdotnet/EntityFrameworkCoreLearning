
using EFCore.Data;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
;

using var context = new FootballLeageDbContext();


await DeleteData();

async Task DeleteData()
{
    var coach = await context.Coachs.FindAsync(5); 
    // context.Coachs.Remove(coach); //  way 1
    context.Entry(coach).State = EntityState.Deleted; // way 2
    context.SaveChanges();
}

async Task UpdateData()
{
    var coach = await context.Coachs
        .AsNoTracking()
        .FirstOrDefaultAsync(c=>c.CoachId==5);
    if(coach != null)
    {
        Console.WriteLine($"Coach found: {coach.Name}");
    }
   
    coach.Name = "Mr.Johnson";

    //context.Update(coach); // solution
    
    context.Entry(coach).State = EntityState.Modified; // Alternative way

    await context.SaveChangesAsync();

    Console.WriteLine($"Coach after changed: {coach.Name}");
}

async Task BatchInsert()
{
    var coach = new Coach()
    {
        Name = "Jose Mourinho",
        CreatedDate = DateTime.Now,
    };
    var newCoach1 = new Coach()
    {
        Name = "Theodore Whitmore",
        CreatedDate = DateTime.Now,

    };
    // add to list
    var listCoachs = new List<Coach>()
{
    coach, newCoach1
};

    await context.Coachs.AddRangeAsync(listCoachs);
    await context.SaveChangesAsync();
}

async Task BasicInsert()
{
    var coach = new Coach()
    {
        Name = "Jose Mourinho",
        CreatedDate = DateTime.Now,
    };
    var newCoach1 = new Coach()
    {
        Name = "Theodore Whitmore",
        CreatedDate = DateTime.Now,

    };
    // add to list
    var listCoachs = new List<Coach>()
{
    coach, newCoach1
};

    // add by loop
    foreach (var c in listCoachs)
    {
        await context.Coachs.AddAsync(c);
    }

    // view change 
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}

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
    var teamsInfo = await context.Teams
        .Select(t => new TeamInfo  { Name = t.Name , CreatedDate =  t.CreatedDate})
        .ToListAsync();
    foreach(TeamInfo team in teamsInfo)
    {
        await Console.Out.WriteLineAsync("Teams Info: "+ team.Name+ "-" + team.CreatedDate);
    }
}

public class TeamInfo
{
    public string? Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
