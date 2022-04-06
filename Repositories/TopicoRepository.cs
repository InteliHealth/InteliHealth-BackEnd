﻿using InteliHealth.Data;
using InteliHealth.Domains;
using InteliHealth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InteliHealth.Repositories
{
    public class TopicoRepository : ITopicoRepository
    {
        private readonly Context ctx;
        public TopicoRepository(Context appContext)
        {
            ctx = appContext;
        }
        public void Atualizar(int id, Topico topicoAtualizado)
        {
            Topico topicoBuscado = BuscarPorId(id);

            topicoBuscado.Nome = topicoAtualizado.Nome;
            
            ctx.Topico.Update(topicoBuscado);
            ctx.SaveChanges();
        }

        public Topico BuscarPorId(int id)
        {
            return ctx.Topico.FirstOrDefault(t => t.IdTopico == id);
        }

        public void Cadastrar(Topico novoTopico)
        {
            novoTopico.DataCriacao = DateTime.Now;
            ctx.Topico.Add(novoTopico);
            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            ctx.Topico.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Topico> Listar()
        {
            return ctx.Topico.ToList();
        }

        public List<Topico> ListarMeus(string id)
        {
            return ctx.Topico.Where(t => t.IdUsuario == id)
                    .Select(t => new Topico()
                    {
                        Nome = t.Nome,
                        Icone = t.Icone
                    }).ToList();
        }
    }
}