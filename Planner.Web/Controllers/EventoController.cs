using Microsoft.AspNetCore.Mvc;
using Planner.Dados.DTO;
using Planner.Dados.DTO.Evento;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class EventoController : Controller
    {
        private readonly EventoRepositorio _repositorio;

        public EventoController(EventoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("indexEvento")]
        public IActionResult RecuperaEvento()
        {
            var eventos = _repositorio.Buscar();
            return Ok(eventos);
        }

        [HttpPost]
        [Route("CadastrarEvento")]
        public IActionResult CadastrarEvento([FromBody] CreateEventoDTO eventoDto)
        {
            
            Evento evento = new Evento();
            evento.Titulo = eventoDto.Titulo;
            evento.Data_Hora = eventoDto.Data_Hora;

            var id = _repositorio.Adicionar(evento);
            
            return Ok();
        }

        [HttpPut]
        [Route("AtualizaEvento")]
        public IActionResult AtualizaEvento([FromBody] UpdateEventoDTO eventoDto)
        {
            if (eventoDto == null)
            {
                return NotFound();
            }
            _repositorio.AtualizarEvento(eventoDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("RemoverEventoPorId/{id}")]
        public void RemoverEventoPorId(int id)
        {
            _repositorio.Excluir(id);
        }

        [HttpPost]
        public IActionResult Cadastrar(EventoViewModel eventoViewModel)
        {
                Evento evento = new Evento();
                evento.Titulo = eventoViewModel.Titulo;
                evento.Data_Hora = eventoViewModel.Data_Hora;
                evento.Id_Evento = eventoViewModel.Id_Evento;
                evento.UsuarioId = eventoViewModel.Id_Usuario;
                evento.Titulo = eventoViewModel.Titulo.ToString();
            
               var id =  _repositorio.Adicionar(evento);

            return RedirectToAction("Consulta");
        }
    }
}
