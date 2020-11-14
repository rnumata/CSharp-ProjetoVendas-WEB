using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Models
{
    public class Context : DbContext
    {
        //options eh a string de conexao e o BD de dados a utilizar
        public Context(DbContextOptions options) : base(options)
        {
             
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

    }
}
