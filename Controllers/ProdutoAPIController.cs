using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasWEB.DAL;
using VendasWEB.Models;

namespace VendasWEB.Controllers
{
    [Route("api/Produto")]
    [ApiController]
    public class ProdutoAPIController : ControllerBase
    {

        private readonly ProdutoDAO _produtoDAO;
       
        public ProdutoAPIController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        //GET: /api/Produto/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Produto> produtos = _produtoDAO.Listar();
            
            if(produtos.Count > 0)
            {
                return Ok(produtos);
            }
            return BadRequest(new {msg = "Lista de produtos Vazia"});   
            
        }


        //GET: /api/Produto/Buscar/1
        [HttpGet]
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            Produto produto = _produtoDAO.BuscarPorId(id);

            if (produto != null)
            {
                return Ok(produto);
            }
            return NotFound(new { msg = "Produto inexistente" });

        }



        //POST: /api/Produto/Cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Cadastrar(produto))
                {
                    return Created("", produto);
                }
                return Conflict(new { msg = "Produto Já Existe" });
            }
            return BadRequest(ModelState);
        }



    }
}
