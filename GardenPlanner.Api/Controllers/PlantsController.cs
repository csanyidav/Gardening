using Microsoft.AspNetCore.Mvc;
using GardenPlanner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using GardenPlanner.Domain.Entities;

namespace GardenPlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantsController : ControllerBase
{
    private readonly GardenPlannerDbContext _context;

    public PlantsController(GardenPlannerDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
    {
        var plants = await _context.Plants.ToListAsync();
        return Ok(plants);
    }
}