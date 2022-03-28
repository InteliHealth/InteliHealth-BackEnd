using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteliHealth.Domains
{
    public class Lembrete
    {
        [Key]
        public int IdLembrete { get; set; }

        [ForeignKey("Topico")]
        public int IdTopico { get; set; }
        public Topico Topico { get; set; }
        public string Titulo { get; set; }
        public DateTime Horario { get; set; }
    }
}
