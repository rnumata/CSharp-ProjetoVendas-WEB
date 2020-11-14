using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWEB.Models;

namespace VendasWEB.DAL
{
    public class CategoriaDAO
    {
        private readonly Context _context;

        //Criar o ctor com o context para poder usa-lo ao instaciar Produto
        public CategoriaDAO(Context context)
        {
            _context = context;
        }

        public List<Categoria> Listar() => _context.Categorias.ToList();

        public Categoria BuscarPorId(int id) => _context.Categorias.Find(id);

    }
}
