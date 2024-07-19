﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_TraSua_API.Data;
using Web_TraSua_API.Model;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Web_TraSua_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public BillDetailsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/BillDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDetail>>> Getbill_detail()
        {
            //return await _context.bill_detail.ToListAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var billdetail = await _context.bill_detail
                .Include(u => u.Size_Products)
                .ThenInclude(u => u.Product)
                .ToListAsync();

            var serializedData = JsonSerializer.Serialize(billdetail, options);
            return Content(serializedData, "application/json");
        }

        // GET: api/BillDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDetail>> GetBillDetail(int id)
        {
            var billDetail = await _context.bill_detail.FindAsync(id);

            if (billDetail == null)
            {
                return NotFound();
            }

            return billDetail;
        }

        // PUT: api/BillDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillDetail(int id, BillDetail billDetail)
        {
            if (id != billDetail.BillDetailID)
            {
                return BadRequest();
            }

            _context.Entry(billDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillDetailExists(id))
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

        // POST: api/BillDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillDetail>> PostBillDetail(BillDetail billDetail)
        {
            var newBillDetail = new BillDetail
            {
                BillID = billDetail.BillID,
                SizeProductID = billDetail.SizeProductID,
                Quality = billDetail.Quality,
                Subtotal = billDetail.Subtotal
            };
            _context.bill_detail.Add(newBillDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillDetail", new { id = billDetail.BillDetailID }, newBillDetail);
        }
        private bool BillDetailExists(int id)
        {
            return _context.bill_detail.Any(e => e.BillDetailID == id);
        }
    }
}
