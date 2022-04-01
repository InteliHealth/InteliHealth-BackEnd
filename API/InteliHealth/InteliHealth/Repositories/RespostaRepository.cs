using InteliHealth.Data;
using InteliHealth.Domains;
using InteliHealth.Interfaces;
using System;
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
        public List<Resposta> Listar()
        {
            return ctx.Resposta.ToList();
        }
        public Resposta BuscarPorId(int id)
        {
            return ctx.Resposta.FirstOrDefault(r => r.IdResposta == id);
        }

        public void Cadastrar(Resposta novaResposta)
        {
            novaResposta.DataCriacao = DateTime.Now;
            ctx.Resposta.Add(novaResposta);
            ctx.SaveChanges();
        }

        public List<Resposta> ListarMeus(int id)
        {
            Topico topicoBuscado = ctx.Topico.FirstOrDefault(t => t.IdTopico == id);
            if (topicoBuscado != null)
            {
                int idTopico = topicoBuscado.IdTopico;

                return ctx.Resposta.Where(t => t.IdTopico == idTopico)
                    .Select(r => new Resposta()
                    {
                        Realizado = r.Realizado
                    }).ToList();
            }

            return null;
        }
    }
}
