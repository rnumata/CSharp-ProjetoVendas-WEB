using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Models
{
    [Table("Produtos")]
    public class Produto : BaseModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(5,ErrorMessage ="Min 5 caracteres")]
        [MaxLength(100,ErrorMessage ="Max 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1,200,ErrorMessage ="Valores entre 1 a 200")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Preco { get; set; }

        public string Imagem { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }
    }
}
