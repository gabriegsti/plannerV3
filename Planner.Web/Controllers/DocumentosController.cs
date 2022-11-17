using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Entidades;

namespace Planner.Web.Controllers
{

    public class PostRequest
    {
        public IFormFile documento { get; set; }

    }
    public class DocumentosController : ControllerBase    
    {
        //[HttpPost("upload")]
        //public async Task<ActionResult> Upload([FromForm] IFormFile documento)
        //{
        //    if (documento == null || documento.Count == 0 )
        //        return BadRequest();

        //    List<byte[]> data = new List<byte[]>();

        //    if(documento.Length > 0)
        //    {
        //        using(var stream = new MemoryStream())
        //        {
        //            await documento.CopyToAsync(stream);
        //            data.Add(stream.ToArray());
        //        }
        //    }

        //    return Ok();
        //}

        private readonly DocumentosRepositorio _repositorio;

        public DocumentosController(DocumentosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }


        [HttpPost("upload")]
        public async Task<ActionResult> Upload([FromForm] IFormFile documento)
        {
            if (documento == null)
                return BadRequest();

            List<byte[]> data = new List<byte[]>();

            if (documento.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await documento.CopyToAsync(stream);
                    data.Add(stream.ToArray());
                }
            }

            Documentos arquivo = new Documentos();
            arquivo.Titulo = documento.FileName.ToString();
            arquivo.documento = data;
            arquivo.ContentType = documento.ContentType;
            _repositorio.Adicionar(arquivo);

            return File(data[0], documento.ContentType, "BaixadoNoPlanner.png");

        }

        [HttpGet]
        [Route("indexDocumentos")]
        public IActionResult RecuperaDocumentos()
        {
            var documentos = _repositorio.Buscar();
            return Ok(documentos);
        }

        [HttpGet]
        [Route("DownloadDocumentos/{id}")]
        public IActionResult DownloadDocumentos(int id)
        {
            var documentos = _repositorio.Buscar(id);
            var titulo = documentos.Titulo;
            var dados = documentos.documento;
            var type = documentos.ContentType;
            return File(dados[0], type, titulo);
        }
       
    }
}
