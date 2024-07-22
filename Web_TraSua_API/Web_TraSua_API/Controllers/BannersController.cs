﻿using System;
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
    public class BannersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public BannersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Banners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banner>>> Getbanner()
        {
            return await _context.banner.ToListAsync();
        }

        // GET: api/Banners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banner>> GetBanner(int id)
        {
            var banner = await _context.banner.FindAsync(id);

            if (banner == null)
            {
                return NotFound();
            }

            return banner;
        }

        // PUT: api/Banners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanner(int id, Banner banner)
        {
            if (id != banner.Id)
            {
                return BadRequest();
            }

            _context.Entry(banner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Banners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banner>> PostBanner(Banner banner)
        {
            _context.banner.Add(banner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanner", new { id = banner.Id }, banner);
        }

        // DELETE: api/Banners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var banner = await _context.banner.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }

            _context.banner.Remove(banner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BannerExists(int id)
        {
            return _context.banner.Any(e => e.Id == id);
        }
    }
}
