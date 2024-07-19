using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_TraSua_API.Data;
using Web_TraSua_API.Model;

namespace Web_TraSua_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public RolesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> Getrole()
        {
            return await _context.role.ToListAsync();
        }

        private bool RolesExists(int id)
        {
            return _context.role.Any(e => e.RoleId == id);
        }
    }
}
