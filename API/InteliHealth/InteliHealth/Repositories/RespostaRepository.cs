using InteliHealth.Data;
using InteliHealth.Domains;
using InteliHealth.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InteliHealth.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        private readonly Context ctx;
        public RespostaRepository(Context appContext)
        {
            ctx = appContext;
        }
        public Resposta BuscarPorId(int id)
        {
            return ctx.Resposta.FirstOrDefault(r => r.IdResposta == id);
        }

        public void Cadastrar(Resposta novaResposta)
        {
            ctx.Resposta.Add(novaResposta);
            ctx.SaveChanges();
        }

        public List<Resposta> ListarMeus(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);
            if (usuarioBuscado != null)
            {
                int idUsuario = usuarioBuscado.IdUsuario;

                return ctx.Resposta.Where(u => u.Topico.Usuario.IdUsuario == idUsuario)
                    .Select(r => new Resposta()
                    {
                        Realizado = r.Realizado
                    }).ToList();
            }

            return null;
        }
    }
}
