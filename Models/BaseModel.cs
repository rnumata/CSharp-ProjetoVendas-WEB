using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Models
{
    public class BaseModel
    {

        public BaseModel() => Criadoem = DateTime.Now;
        
        [Key]
        public int Id { get; set; }

        public DateTime Criadoem { get; set; }

    }
}
