using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VendasWEB.DAL;
using VendasWEB.Models;

namespace VendasWEB.Controllers
{
    public class ProdutoController : Controller
    {
        //#3
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _CategoriaDAO;
        private readonly IWebHostEnvironment _hosting;


        //#2
        public ProdutoController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO, IWebHostEnvironment hosting)
        {   
            _produtoDAO = produtoDAO;
            _CategoriaDAO = categoriaDAO;       
            _hosting = hosting;
        }

        //#1
        public IActionResult Index()
        {       
            ViewBag.Title = "Gerenciamento de Produtos";  
            return View(_produtoDAO.Listar());
        }

        //#4
        public IActionResult Cadastrar() 
        {
            ViewBag.Categorias = new SelectList(_CategoriaDAO.Listar(), "Id", "Nome");
            return View();
        }
      
        //#5
        [HttpPost]
        public IActionResult Cadastrar(Produto produto, IFormFile file)
        {
            // #5.1
            if (ModelState.IsValid)
            {
                if(file != null)
                {
                    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));
                    produto.Imagem = arquivo;
                }
                else
                {
                    produto.Imagem = "download.png";
                }

                produto.Categoria = _CategoriaDAO.BuscarPorId(produto.CategoriaId);

                if (_produtoDAO.Cadastrar(produto))
                {
                    return RedirectToAction("Index", "Produto");
                }
                //Prop que existe em qq controller. Como a ViewBag so funciona antes de return View().. pode repetir com outro erro na linha 53, 54.. ou qtas forem necessarias
                ModelState.AddModelError("", "Cadastro Não realizado. Produto já cadastrado"); 
            }
            ViewBag.Categorias = new SelectList(_CategoriaDAO.Listar(), "Id", "Nome");
            return View(produto);
        }

        // #6
        public IActionResult Remover(int id)
        {
            _produtoDAO.Remover(id);
            return RedirectToAction("Index", "Produto");
        }
  

        public IActionResult Alterar(int id)
        {    
            return View(_produtoDAO.BuscarPorId(id));
        }


        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            _produtoDAO.Alterar(produto);           
            return RedirectToAction("Index", "Produto");
        }

       
    }
}


/* #1
 *  Sempre que tiver return View() a app vai tentar encontrar na View no pacote com o nome do controller e um cshtml com o nome da Action. Neste caso Index
 */


/* #2
    Criar o ctor com o ProdutoDAO aonde tem a chamada ao context
    ViewBag: Obj dinamico que leva qq coisa (string, List, Obj) para a index. So pode ser usado antes de um return view
 */

/* #3
    obj global para receber o ProdutoDAO
    readonly _produtoDAO so pode ser atribuido no ctor ou na mesma linha dele 
 */

/* #4
    Action que só abre a View/Produto/Cadastrar.cshtml..eh chamada la no index pelo link <a> asp-action="Cadastrar"
    Clicar com btnD em Cadastrar e add view || btnD na pasta Produto e add view
 */

/* #5
    Action que recebe os inputs do form. So pode acessar se a req for Post -> [HttpPost]
    O return eh o direcionamento para o index
 */

/* #5.1
    ModelState.IsValid verifica se todas as anotacoes da model estao ok
 */

/* #6
    return RedirectToAction("Index","Produto");   =>  Ao terminar o processo volta para o Index.cshtml do controller do Produto
 
 */
