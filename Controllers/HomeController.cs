using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWEB.DAL;

namespace VendasWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;

        public HomeController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
        }
      
        public IActionResult Index(int id)
        {
            ViewBag.Categorias = _categoriaDAO.Listar();

            if(id == 0)
            {
                return View(_produtoDAO.Listar());
            }

            return View(_produtoDAO.ListarCategoria(id));
            
        }


        public IActionResult AdiconarAoCarrinho(int id)
        {
            return View();
        }
    }
}



