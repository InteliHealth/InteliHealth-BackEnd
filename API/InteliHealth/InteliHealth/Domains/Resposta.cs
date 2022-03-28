using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteliHealth.Domains
{
    public class Resposta
    {
        [Key]
        public int IdResposta { get; set; }

        [ForeignKey("Topico")]
        public int IdTopico { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public bool Realizado { get; set; }
    }
}
