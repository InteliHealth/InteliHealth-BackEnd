using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteliHealth.Domains
{
    public class Topico
    {
        [Key]
        public int IdTopico { get; set; }
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<Lembrete> Lembretes { get; set; }
        public ICollection<Resposta> Respostas { get; set; }
    }
}
