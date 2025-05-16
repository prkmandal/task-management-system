using Domain.Entities;
using Web.Infrastructure;

namespace Web.API;

public class DailyTasks : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGet("/all-tasks", () =>
        {
            return Results.Ok(new List<DailyTask>());
        }).WithTags("DailyTask");
    }

    
}

