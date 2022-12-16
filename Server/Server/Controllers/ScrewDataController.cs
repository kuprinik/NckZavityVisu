using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Controllers;

[Route("api/[controller]")]
public class ScrewDataController : Controller
{
    private readonly ServerContext context;

    public ScrewDataController(ServerContext context)
    {
        this.context = context;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Models.ScrewData>> GetData(int id)
    {
        var data = await (from d in context.Data
            where d.ScrewId == id
            select d).ToListAsync();

        if (data.Count == 0)
        {
            return NotFound();
        }

        return new Models.ScrewData{ScrewId = id, Data = data};
    }
}
