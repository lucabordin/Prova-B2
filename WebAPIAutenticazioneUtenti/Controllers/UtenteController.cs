using Microsoft.AspNetCore.Mvc;
using WebAPIAutenticazioneUtenti.DTO;
using WebAPIAutenticazioneUtenti.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIAutenticazioneUtenti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private IUtenteService _service;
        public UtenteController(IUtenteService service)
            => _service = service;
        // GET: api/<UtenteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UtenteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UtenteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/<UtenteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromBody] UtenteDto utenteDto)
        {
            return await _service.InserisciUtente(id, utenteDto);
        }

        // DELETE api/<UtenteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
