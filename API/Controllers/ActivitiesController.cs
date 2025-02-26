using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;





using Persistence;

namespace API.Controllers;

public class ActivitiesController(AppDbContext context) : BaseApiController
{
    [HttpGet]    
    public async Task<ActionResult<List<Acivity>>>GetActivities(){
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Domain.Acivity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);
        if(activity != null) return activity;

        return NotFound();
    }
}
