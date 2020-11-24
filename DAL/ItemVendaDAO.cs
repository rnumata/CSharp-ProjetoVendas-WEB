using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWEB.Models;

namespace VendasWEB.DAL
{
    public class ItemVendaDAO
    {
        private readonly Context _context;

        

        // #1
        public ItemVendaDAO(Context context)
        {
            _context = context;
        }

        public void Cadastrar(ItemVenda item)
        {
            _context.ItensVenda.Add(item);
            _context.SaveChanges();
        }

        public List<ItemVenda> ListarPorCarrinhoId(string id) => _context.ItensVenda.Include(x => x.Produto.Categoria).Where(x => x.CarrinhoId == id).ToList();

        //public Categoria BuscarPorId(int id) => _context.Categorias.Find(id);

    }
}


/* #1
    Criar o ctor com o context para poder usa-lo ao instaciar Produto
 */