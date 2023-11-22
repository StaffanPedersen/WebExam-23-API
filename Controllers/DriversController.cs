namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Contexts;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly APIContext context;
    public DriversController(APIContext _context)
    {
        context = _context;
    }
    [HttpGet]
    public async Task<ActionResult<List<Driver>>> Get()
    {
        try
        {
            List<Driver> drivers = await context.Drivers.ToListAsync();
            if (drivers != null)
            {
                return Ok(drivers);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Driver>> Get(int id)
    {
        try
        {
            Driver? driver = await context.Drivers.FindAsync(id);
            if (driver != null)
            {
                return Ok(driver);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Driver>> Post(Driver driver)
    {
        try
        {
            await context.Drivers.AddAsync(driver);
            await context.SaveChangesAsync();
            return Ok(driver);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Driver>> Put(int id, Driver driver)
    {
        try
        {
            if (id != driver.Id)
            {
                return BadRequest();
            }
            else
            {
                context.Entry(driver).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(driver);
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Driver>> Delete(int id)
    {
        try
        {
            Driver? driver = await context.Drivers.FindAsync(id);
            if (driver != null)
            {
                context.Drivers.Remove(driver);
                await context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

}
