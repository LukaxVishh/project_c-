using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PersonagemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem(Personagem personagem)
        {
            if (personagem == null){
                return BadRequest("Personagem não pode ser nulo");
            }

            _appDbContext.ProjectDb.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagem);
        }
    }
}