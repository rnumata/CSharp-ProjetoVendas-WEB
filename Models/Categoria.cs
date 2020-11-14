using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Models
{
    [Table("Categorias")]
    public class Categoria : BaseModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Produto> produtos { get; set; }
    }
}
