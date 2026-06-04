using AutoMapper;
using Centrodecomputo.data.DataContext;
using EIN.DTOS;
using EIN.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Centrodecomputo._1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneracionesController : ControllerBase
    {

        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public GeneracionesController(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]//obtener informacion 
        public async Task<IActionResult> Listar()
        {
            try
            {
                var generaciones = await _context.Generaciones
                    .Where(x => x.EstaActivo == true)
                    .Select(x => _mapper.Map<GeneraciongetDTO>(x))
                    .ToListAsync();


                if (generaciones == null || generaciones.Count == 0)
                    return NoContent();

                return Ok(generaciones);
            }
               
                 catch(Exception ex)
               {
                return BadRequest(ex.Message);
               }
        
        }
        [HttpPost]//agregar informacion tipo insert 
        public async Task<IActionResult> post([FromBody] GeneracionsetDTO newobj)

        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                //aqui ira la logica para agregar generacion a la base de datos
                var obj = _mapper.Map<GeneracionEntity>(newobj);
              await _context.Generaciones.AddAsync(obj);
              await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Listar), newobj);
            }

               catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("{id}")]//eliminar informacion
        public async Task< IActionResult> Delete(int id)
        {

            try 
            {
                //logica para eliminar la generacion ID proporcionado
                var Generacion = await _context.Generaciones.FindAsync(id);

                if (Generacion == null)
                    return NotFound();

                // _context.Generaciones.Remove(Generacion);
                Generacion.EstaActivo = false;
                _context.Generaciones.Update(Generacion);
               await _context.SaveChangesAsync();
                return Ok("Generacion eliminada correctamente");

            }

            catch(Exception ex)
                {
                return BadRequest(ex.Message);
                }
        }

        [HttpPut("{id}")]//actualizar informacion
        public async Task< IActionResult> put(int id, [FromBody] GeneracionsetDTO updateobj)
        {
            try 
            {

                if (ModelState.IsValid)
                    return BadRequest();
                //logica para actualizar la generacion con el ID proporcionado
                var generacion = await _context.Generaciones.Where(x => x.Id == id && x.EstaActivo)
                    .FirstOrDefaultAsync();

                if (generacion == null)
                    return NotFound();

                generacion.Nombre = updateobj.Nombre;


                _context.Generaciones.Update(generacion);
               await _context.SaveChangesAsync();
               
               return Ok("Generacion actualizada correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       
    }
}
