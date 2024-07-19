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
    public class StatusController : ControllerBase
    {
        private readonly AppDBContext _context;

        public StatusController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> Getstatus()
        {
            return await _context.status.ToListAsync();
        }
        private bool StatusExists(int id)
        {
            return _context.status.Any(e => e.StatusId == id);
        }
    }
}
