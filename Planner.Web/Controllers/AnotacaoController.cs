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

        public AnotacaoController(AnotacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
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

    }
}
