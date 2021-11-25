using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using apiweb.Data.Dtos;

namespace api.Controllers
{   
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private DataContext dc;

        // Construtor
        public PessoaController(DataContext context)
        {
            this.dc = context;
        }
        
        // Cdastrar um Usuário no banco de dados
        [HttpPost("cadastrar")]
        public async Task<ActionResult> cadastrar([FromBody] CreatePessoaDTO pDto)
        {
            Pessoa pessoa = new Pessoa
            {
                Nome = pDto.Nome,
                Cidade = pDto.Cidade,
                Idade = pDto.Idade
            };

            dc.pessoa.Add(pessoa);
            await dc.SaveChangesAsync();
            return Created("Objeto pessoa", pDto);
        }
        
        // Lista de cadastro de  Usuário no banco de dados
        [HttpGet("lista")]
        public async Task<ActionResult> lista()
        {
            var dados = await dc.pessoa.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("lista/{id}")]
        public Pessoa filtrar( int id ) 
        {
            Pessoa p = dc.pessoa.Find(id);
            return p;
        }


        // Editar um Usuário no banco de dados
        [HttpPut("editar/{id}")]
        public async Task<ActionResult> editar(int id, [FromBody] Pessoa p)
        {
            dc.pessoa.Update(p);
            await dc.SaveChangesAsync();
            return Ok(p);
        }


        // Deletar um usuário no banco de dados
        [HttpDelete("remove/{id}")]
        public async Task<ActionResult> delete( int id )
        {
            Pessoa p = filtrar(id);
            
            if (p == null) {
                return NotFound();
            } else {
                dc.pessoa.Remove(p);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }

        // Teste
        [HttpGet("oi")]
        public string oi()
        {
            return "Hello World";
        }

    }
}