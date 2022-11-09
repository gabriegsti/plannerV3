using Microsoft.AspNetCore.Mvc;
using Planner.Dados.DTO.Anotacao;
using Planner.Dados.DTO.Evento;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class AnotacaoController : Controller
    {
        private readonly AnotacaoRepositorio _repositorio;
        private readonly AulaRepositorio RepositorioAula;

        public AnotacaoController(AnotacaoRepositorio repositorio, AulaRepositorio aulaRepositorio)
        {
            _repositorio = repositorio;
            RepositorioAula = aulaRepositorio;
        }

        [HttpGet]
        [Route("indexAnotacao")]
        public IActionResult RecuperaAnotacao()
        {
            var anotacoes = _repositorio.Buscar();
            return Ok(anotacoes);
        }

        [HttpPost]
        [Route("CadastrarAnotacao")]
        public IActionResult CadastrarAnotacao([FromBody] CreateAnotacaoDTO anotacaoDto)
        {
            Anotacao anotacao = new Anotacao();
            anotacao.Titulo = anotacaoDto.Titulo;
            anotacao.Campo_Texto = anotacaoDto.Campo_Texto;
            anotacao.Link = anotacaoDto.Link;

           _repositorio.Adicionar(anotacao);

            return Ok();
        }

        [HttpPut]
        [Route("AtualizarAnotacao")]
        public IActionResult AtualizaAnotacao([FromBody] UpdateAnotacaoDTO anotacaoDto)
        {
            if (anotacaoDto == null)
            {
                return NotFound();
            }
            _repositorio.AtualizarAnotacao(anotacaoDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("RemoverAnotacaoPorId/{id}")]
        public void RemoverAnotacaoPorId(int id)
        {
            _repositorio.Excluir(id);
        }

        public IActionResult Index()
        {
            List<AnotacaoViewModel> lst = new List<AnotacaoViewModel>();
            var anotacoes = _repositorio.Buscar();

            foreach (var anotacao in anotacoes)
            {
                AnotacaoViewModel model = new AnotacaoViewModel();
                model.Id_Anotacao = anotacao.Id_Anotacao;
                model.Titulo = anotacao.Titulo;
                model.Campo_Texto = anotacao.Campo_Texto;
                model.Link = anotacao.Link;
                model.Titulo = anotacao.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        public IActionResult Cadastrar()
        {
            List<AulaViewModel> lst = new List<AulaViewModel>();
            IEnumerable<Aula> aulas = RepositorioAula.Buscar();

            foreach (Aula aula in aulas)
            {
                AulaViewModel model = new AulaViewModel();
                model.Id_Materia = aula.Id_Materia;
                model.Titulo = aula.Titulo;
                model.Data_Hora = aula.Data_Hora;
                lst.Add(model);
            }
            ViewBag.Aulas = lst;
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(AnotacaoViewModel anotacaoViewModel)
        {
            Anotacao anotacao = new Anotacao();
            anotacao.Titulo = anotacaoViewModel.Titulo;
            anotacao.Campo_Texto = anotacaoViewModel.Campo_Texto;
            anotacao.Id_Anotacao = anotacaoViewModel.Id_Anotacao;
            anotacao.Link = anotacaoViewModel.Link;
            anotacao.Titulo = anotacaoViewModel.Titulo.ToString();

            var id = _repositorio.Adicionar(anotacao);

            return RedirectToAction("Index");
        }


        public IActionResult Remover(int id)
        {
            var anotacao = _repositorio.Buscar(id);

            AnotacaoViewModel model = new AnotacaoViewModel();
            model.Id_Anotacao = anotacao.Id_Anotacao;
            model.Id_Aula = anotacao.AulaId;
            model.Titulo = anotacao.Titulo;
            model.Campo_Texto = anotacao.Campo_Texto;
            model.Link = anotacao.Link;

            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var anotacao = _repositorio.Buscar(id);
            var aula = RepositorioAula.Buscar(anotacao.AulaId);
            
            AnotacaoViewModel model = new AnotacaoViewModel();
            model.Id_Anotacao = anotacao.Id_Anotacao; 
            model.Id_Aula = anotacao.AulaId;
            model.Titulo = anotacao.Titulo;
            model.Campo_Texto = anotacao.Campo_Texto;
            model.Link = anotacao.Link;
           
            if(aula != null)
            model.AulaTitulo = aula.Titulo;

            return View(model);
        }

        public IActionResult EditarPorId(AnotacaoViewModel anotacaoViewModel)
        {
           
            Anotacao model = new Anotacao();
            model.Id_Anotacao = anotacaoViewModel.Id_Anotacao;
            model.AulaId = anotacaoViewModel.Id_Aula;
            model.Titulo = anotacaoViewModel.Titulo;
            model.Campo_Texto = anotacaoViewModel.Campo_Texto;
            model.Link = anotacaoViewModel.Link;

            _repositorio.Atualizar(model);

            return RedirectToAction("Index");
        }
    }
}
