using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InteliHealth.Domains
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdFirebase { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public string Foto { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<Topico> Topicos { get; set; }
    }
}
