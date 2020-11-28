using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWEB.DAL;
using VendasWEB.Models;
using VendasWEB.Utils;

namespace VendasWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly ItemVendaDAO _itemVendaDAO;
        private readonly Secao _secao;


        public HomeController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO, ItemVendaDAO itemVendaDAO, Secao secao)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _itemVendaDAO = itemVendaDAO;
            _secao = secao;
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


        public IActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = _produtoDAO.BuscarPorId(id);
            ItemVenda item = new ItemVenda
            {
                Produto = produto,
                Preco = produto.Preco,
                Quantidade = 1,
                CarrinhoId = _secao.BuscarCarrinhoId()
            };
            _itemVendaDAO.Cadastrar(item);
            return RedirectToAction("CarrinhoCompras");
        }


        //public IActionResult CarrinhoCompras()
        //{
        //    ViewBag.Title = "Carrinho Compras";
        //    string carrinhoId = _secao.BuscarCarrinhoId();
        //    ViewBag.Total = _itemVendaDAO.SomarTotalCarrinho(carrinhoId);
        //    return View(_itemVendaDAO.ListarPorCarrinhoId(carrinhoId);
        //}

    }
}



