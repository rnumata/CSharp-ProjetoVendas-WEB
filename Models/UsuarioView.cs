using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Models
{

    [Table("Usuarios")]
    public class UsuarioView : BaseModel
    {
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da Senha")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Campos diferentes")]
        public string ConfirmacaoSenha { get; set; }

        [Display(Name ="CEP")]
        public string Cep { get; set; }

        [Display(Name = "Rua")]
        public string Logradouro { get; set; }

        [Display(Name = "Localidade")]
        public string Localidade { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Estado")]
        public string Uf { get; set; }

    }
}
