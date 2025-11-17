using application.Activities.Commands;
using application.Activities.Queries;
using domain;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class ActivitiesController() : BaseApiCotroller
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
    {
        return await Mediator.Send(new GetActivityList.Query(),ct);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(String id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }
    [HttpPost]
    public async Task<ActionResult<String>> CreateActivity(Activity act)
    {
        return await Mediator.Send(new CreateActivity.Command { activity = act });
    }
    [HttpPut]
    public async Task<IActionResult> EditActivity(Activity act)
    {
        await Mediator.Send(new EditActivity.Command { activity = act });
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(String id)
    {
        await Mediator.Send(new DeleteActivity.Command { Id = id });
        return Ok();
    }
}
