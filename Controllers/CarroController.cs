using cp3.Data;
using cp3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cp3.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class CarroController : Controller
    {
        private readonly AppDbContext _context;
        public CarroController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carros>>> getCarros()
        {
            return await _context.Carros.ToListAsync();
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Carros>> getCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }
        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<Carros>> getCarroByPlaca(string placa)
        {
            var placaCarro = await _context.Carros.FindAsync(placa);

            if (placaCarro == null)
            {
                return NotFound();
            }

            return placaCarro;
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCarro(int id, Carros carro)
        {
            if (id != carro.Id)
            {
                return BadRequest();
            }
            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrosExist(id))
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


        [HttpPost]
        public async Task<ActionResult<Carros>> AddCarro(Carros carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getCarro", new { id = carro.Id }, carro);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrosExist(int id)
        {
            return _context.Carros.Any(i => i.Id == id);
        }
    }
}
