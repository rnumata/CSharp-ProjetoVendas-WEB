using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Models
{
    public class Context : DbContext
    {
        // #1
        public Context(DbContextOptions options) : base(options)
        {
             
        }

        // #2
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

    }
}






/* #1
    DbContextOptions => é a string de conexao e o BD de dados a utilizar
    É configurada no Startup.cs
 */


/* #2
     
*/