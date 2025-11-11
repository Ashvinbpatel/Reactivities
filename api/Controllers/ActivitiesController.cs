using System;
using domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using persistence;

namespace api.Controllers;

public class ActivitiesController(AppDbContext context) : BaseApiCotroller
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(String id)
    {
        var activity = await context.Activities.FindAsync(id);
        if(activity == null) return NotFound();
        return activity;
    }
}
