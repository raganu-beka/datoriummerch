﻿using datoriummerch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace datoriummerch.Controllers
{
    [Route("api/datorium-merch")]
    [ApiController]
    public class MerchController : ControllerBase
    {
        private readonly MerchContext _dbContext;

        public MerchController(MerchContext context)
        {
            _dbContext = context;
        }

        [HttpGet("ok")]
        public ActionResult<string> GetOk()
        {
            return "OK";
        }

        [HttpGet]
        public ActionResult<IEnumerable<Merch>> GetMerch()
        {
            return _dbContext.Merches.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Merch> GetMerchById(long id)
        {
            var merch = _dbContext.Merches.Find(id);

            if (merch == null)
            {
                return NotFound();
            }

            return merch;
        }

        [HttpPost]
        public ActionResult PostMerch(Merch merch)
        {
            _dbContext.Merches.Add(merch);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMerch(long id, Merch merch)
        {
            if (id != merch.Id)
            {
                return BadRequest();
            }

            var existingMerch = _dbContext.Merches.Find(id);

            if (existingMerch == null)
            {
                return NotFound();
            }

            existingMerch.Stock = merch.Stock;
            existingMerch.Price = merch.Price;
            existingMerch.Name = merch.Name;
            existingMerch.Color = merch.Color;

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
