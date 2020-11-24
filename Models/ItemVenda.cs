using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Models
{
    public class ItemVenda : BaseModel
    {

        public ItemVenda()
        {
            Produto = new Produto();
        }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }

        public string CarrinhoId { get; set; }

    }
}
