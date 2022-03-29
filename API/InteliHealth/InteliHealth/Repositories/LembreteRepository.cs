using InteliHealth.Data;
using InteliHealth.Domains;
using InteliHealth.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InteliHealth.Repositories
{
    public class LembreteRepository : ILembreteRepository
    {
        private readonly Context ctx;
        public LembreteRepository(Context appContext)
        {
            ctx = appContext;
        }
        public void Atualizar(int id, Lembrete lembreteAtualizado)
        {
            Lembrete lembreteBuscado = BuscarPorId(id);

            lembreteBuscado.Titulo = lembreteAtualizado.Titulo;
            lembreteBuscado.Horario = lembreteAtualizado.Horario;

            ctx.Lembrete.Update(lembreteBuscado);
            ctx.SaveChanges();
        }

        public Lembrete BuscarPorId(int id)
        {
            return ctx.Lembrete.FirstOrDefault(l => l.IdLembrete == id);
        }

        public void Cadastrar(Lembrete novoLembrete)
        {
            ctx.Lembrete.Add(novoLembrete);
            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            ctx.Lembrete.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Lembrete> Listar()
        {
            return ctx.Lembrete.ToList();
        }

        public List<Lembrete> ListarMeus(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);
            if (usuarioBuscado != null)
            {
                int idUsuario = usuarioBuscado.IdUsuario;

                return ctx.Lembrete.Where(u => u.Topico.Usuario.IdUsuario == idUsuario)
                    .Select(l => new Lembrete()
                    {
                        Titulo = l.Titulo,
                        Horario = l.Horario,
                    }).ToList();
            }

            return null;
        }
    }
}
