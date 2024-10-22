using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TarjetaCreditoController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TarjetaCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarjetaCreditoModel>>> GetTarjeta()
        {
            return await _context.Tarjeta.ToListAsync();
        }

        // GET: api/TarjetaCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarjetaCreditoModel>> GetTarjetaCreditoModel(int id)
        {
            var tarjetaCreditoModel = await _context.Tarjeta.FindAsync(id);

            if (tarjetaCreditoModel == null)
            {
                return NotFound();
            }

            return tarjetaCreditoModel;
        }

        // PUT: api/TarjetaCredito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjetaCreditoModel(int id, TarjetaCreditoModel tarjetaCreditoModel)
        {
            if (id != tarjetaCreditoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarjetaCreditoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaCreditoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tarjetaCreditoModel);
        }

        // POST: api/TarjetaCredito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TarjetaCreditoModel>> PostTarjetaCreditoModel(TarjetaCreditoModel tarjetaCreditoModel)
        {
            _context.Tarjeta.Add(tarjetaCreditoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarjetaCreditoModel", new { id = tarjetaCreditoModel.Id }, tarjetaCreditoModel);
        }

        // DELETE: api/TarjetaCredito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarjetaCreditoModel(int id)
        {
            var tarjetaCreditoModel = await _context.Tarjeta.FindAsync(id);
            if (tarjetaCreditoModel == null)
            {
                return NotFound();
            }

            _context.Tarjeta.Remove(tarjetaCreditoModel);
            await _context.SaveChangesAsync();

            return Created();
        }

        private bool TarjetaCreditoModelExists(int id)
        {
            return _context.Tarjeta.Any(e => e.Id == id);
        }
    }
}
