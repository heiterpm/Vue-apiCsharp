using APIVue.Models;
using APIVue.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace APIVue.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;
        private readonly IWebHostEnvironment _environment;

        public ProdutosController(IProdutosRepository produtosRepository, IWebHostEnvironment environment)
        {
            _produtosRepository = produtosRepository;
            _environment = environment;
        }

        [HttpGet("AllProdutos")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {

            return Ok(await _produtosRepository.ReadAllProdutos());

        }

        [HttpGet("GetProduto/{id}")]
        public async Task<ActionResult<Produtos>> GetProduto(int id)
        {

            var produto = await _produtosRepository.ReadProduto(id);

            string nomeFileImg = produto.NomeArquivo;
            var path = Path.Combine(_environment.ContentRootPath + "/wwwroot/" + nomeFileImg);
            produto.ImgByte = System.IO.File.ReadAllBytes(path);



            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            else
            {
                return Ok(produto);
            }

        }

        [HttpPost("AddProduto")]
        public async Task<ActionResult> AddProduto ([FromForm] Produtos produto)
        {
            var files = HttpContext.Request.Form.Files;
            _produtosRepository.CreateProduto(produto);
            if (produto.Img != null)
            {
                    string nomeFileImg = Path.GetFileNameWithoutExtension(produto.Img.FileName);
                    string extensao = Path.GetExtension(produto.Img.FileName);
                    produto.NomeArquivo = nomeFileImg = nomeFileImg + extensao;
                    var path = Path.Combine(_environment.ContentRootPath + "/wwwroot/" + nomeFileImg);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        produto.Img.CopyToAsync(fileStream);
                    }
            }
            
            if (await _produtosRepository.SaveAllAsync())
            {
                return Ok("Produto Cadastrado Com sucesso");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao cadastrar produto");
            }
        }

        [HttpPut("UpdateProduto")]
        public async Task<ActionResult> UpdateProduto(Produtos produto)
        {
            _produtosRepository.UptadeProduto(produto);
            if (await _produtosRepository.SaveAllAsync())
            {
                return Ok("Produto editado com sucesso");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao editar produto");
            }
        }
        [HttpDelete("DeleteProduto/{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            var produto = await _produtosRepository.ReadProduto(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            _produtosRepository.RemoveProduto(produto);

            if (await _produtosRepository.SaveAllAsync())
            {
                return Ok("Produto removido com sucesso");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao remover o produto");
            }
        }

    }
}
