using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext dataContext) : ControllerBase
    {
        private readonly DataContext AppDbContext = dataContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await AppDbContext.Users.ToListAsync();
            return users;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await AppDbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            return user;
        }
    }
}