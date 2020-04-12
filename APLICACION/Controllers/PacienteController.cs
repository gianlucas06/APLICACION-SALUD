using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using APLICACION.Models;
namespace APLICACION.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;
        public IConfiguration Configuration { get; }
        public PacienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _pacienteService = new PacienteService(connectionString);
        }
        // GET: api/Paciente
        [HttpGet]
        public IEnumerable<PacienteViewModel> Gets()
        {
            var pacientes = _pacienteService.ConsultarTodos().Select(p=> new PacienteViewModel(p));
            return pacientes;
        }
        // POST: api/paciente
        [HttpPost]
        public ActionResult<PacienteViewModel> Post(PacienteInputModel pacienteInput)
        {
            Paciente paciente = MapearPaciente(pacienteInput);
            var response = _pacienteService.Guardar(paciente);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Paciente);
        }
        
        private Paciente MapearPaciente(PacienteInputModel pacienteInput)
        {
            var paciente = new Paciente
            {
                Identificacion = pacienteInput.Identificacion,
                ValorServicio = pacienteInput.ValorServicio,
                Salario = pacienteInput.Salario,
                
            };
            return paciente;
        }
       
}
}