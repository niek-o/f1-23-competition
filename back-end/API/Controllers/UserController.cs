using API.Database;
using API.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using API.Services.Interfaces;
using Core.Entities.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public UserController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET: api/User
        [HttpGet]
        [Route("/user/{id}")]
        public async Task<ActionResult<UserDto>> GetUsers([FromServices] IUserService userService, int id)
        {
            return await userService.GetUser(id);
        }

        // PUT: api/
        // Set active user for requests
        [HttpPut]
        [Route("/activeuser/{id}")]
        public async Task<ActionResult> SetActiveUser(int id)
        {
            IMemoryStore memoryStore = new MemoryStore(_memoryCache);

            memoryStore.SetCachedData("CurrentActiveUser", id.ToString());

            return Ok(memoryStore.GetCachedData("CurrentActiveUser"));
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/user")]
        public async Task<ActionResult> PostUser([FromServices] IUserService userService, CreateUserDto createUser)
        {
            UserDto? user = await userService.CreateUser(createUser);

            return Ok(user);
        }
    }
}