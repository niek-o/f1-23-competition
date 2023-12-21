using API.Database;
using API.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Services.Interfaces;
using Core.Entities.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public LapController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET: api/User
        [HttpGet]
        [Route("/lap")]
        public async Task<ActionResult<LapDto>> GetLap([FromServices] ILapService lapService, int id)
        {
            return await lapService.GetLap(id);
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/lap")]
        public async Task<ActionResult> PostLap([FromServices] ILapService lapService, CreateLapDto createLap)
        {
            LapDto lap = await lapService.CreateLap(createLap);

            return Ok(lap);
        }
    }
}