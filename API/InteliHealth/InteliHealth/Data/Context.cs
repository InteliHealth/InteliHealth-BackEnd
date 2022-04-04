using InteliHealth.Domains;
using Microsoft.EntityFrameworkCore;

namespace InteliHealth.Data
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Topico> Topico { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
        public DbSet<Lembrete> Lembrete { get; set; }
    }
}
