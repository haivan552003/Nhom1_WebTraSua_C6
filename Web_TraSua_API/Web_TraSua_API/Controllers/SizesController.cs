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
    public class SizesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SizesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Sizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Size>>> Getsize()
        {
            return await _context.size.ToListAsync();
        }
        private bool SizeExists(int id)
        {
            return _context.size.Any(e => e.SizeID == id);
        }
    }
}
