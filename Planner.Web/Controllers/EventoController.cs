﻿using Microsoft.AspNetCore.Mvc;
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


        public IActionResult Consulta()
        {
            List<EventoViewModel> lst = new List<EventoViewModel>();
            var eventos = _repositorio.Buscar();

            foreach (var evento in eventos)
            {
                EventoViewModel model = new EventoViewModel();
                model.Titulo = evento.Titulo;
                model.Data_Hora = evento.Data_Hora;
                model.Id_Evento = evento.Id_Evento;
                model.Id_Usuario = evento.UsuarioId;
                model.Titulo = evento.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }
        
        //Criei para a primeira tela
        public IActionResult ListaDeEventos()
        {
            List<EventoViewModel> lst = new List<EventoViewModel>();
            var eventos = _repositorio.Buscar();

            foreach (var evento in eventos)
            {
                EventoViewModel model = new EventoViewModel();
                model.Titulo = evento.Titulo;
                model.Data_Hora = evento.Data_Hora;
                model.Titulo = evento.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        public IActionResult Cadastrar()
        {
            return View();
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


        public IActionResult Remover(int id)
        {
            var evento = _repositorio.Buscar(id);

            EventoViewModel model = new EventoViewModel();
            model.Titulo = evento.Titulo;
            model.Data_Hora = evento.Data_Hora;
            model.Id_Evento = evento.Id_Evento;
            model.Id_Usuario = evento.UsuarioId;
            model.Titulo = evento.Titulo.ToString();

            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Consulta");
        }

        public IActionResult Editar(int id)
        {
            var evento = _repositorio.Buscar(id);

            EventoViewModel model = new EventoViewModel();
            model.Titulo = evento.Titulo;
            model.Data_Hora = evento.Data_Hora;
            model.Id_Evento = evento.Id_Evento;
            model.Id_Usuario = evento.UsuarioId;
            model.Titulo = evento.Titulo.ToString();

            return View(model);
        }

        public IActionResult EditarPorId(EventoViewModel eventoViewModel)
        {
            Evento evento = new Evento();
            evento.Titulo = eventoViewModel.Titulo;
            evento.Data_Hora = eventoViewModel.Data_Hora;
            evento.Id_Evento = eventoViewModel.Id_Evento;
            evento.UsuarioId = eventoViewModel.Id_Usuario;

           _repositorio.Atualizar(evento);

            return RedirectToAction("Consulta");
        }
    }
}
