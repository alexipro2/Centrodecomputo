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
    public class GruposController : ControllerBase
    {

        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public GruposController(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var lista = await _context.Grupo
               .Include(x=>x.Generacion)
               .Select(x => _mapper.Map<GrupoGetDTO>(x))
                .ToListAsync();
            return Ok(lista);
        }

        [HttpPost]
        public async Task< IActionResult> Guardar(GrupoSetDTO newobj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                //aqui ira la logica para agregar generacion a la base de datos
                var obj = _mapper.Map<GrupoEntity>(newobj);
               await _context.Grupo.AddAsync(obj);
               await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Listar), newobj);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
