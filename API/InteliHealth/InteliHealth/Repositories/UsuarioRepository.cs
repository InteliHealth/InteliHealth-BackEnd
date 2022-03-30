using InteliHealth.Data;
using InteliHealth.Domains;
using InteliHealth.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InteliHealth.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context ctx;
        public UsuarioRepository(Context appContext)
        {
            ctx = appContext;
        }
        //public void Atualizar(int id, Usuario usuarioAtualizado)
        //{
        //    Usuario usuarioBuscado = BuscarPorId(id);

        //    usuarioBuscado.Nome = usuarioAtualizado.Nome;
        //    usuarioBuscado.Sobrenome = usuarioAtualizado.Sobrenome;
        //    usuarioBuscado.DataNascimento = usuarioAtualizado.DataNascimento;
        //    usuarioBuscado.Altura = usuarioAtualizado.Altura;
        //    usuarioBuscado.Peso = usuarioAtualizado.Peso;
        //    usuarioBuscado.TipoSanguineo = usuarioAtualizado.TipoSanguineo;
        //    usuarioBuscado.Foto = usuarioAtualizado.Foto;

        //    ctx.Usuario.Update(usuarioBuscado);
        //    ctx.SaveChanges();
        //}

        public Usuario Atualizar(Usuario usuarioAtualizado)
        {
            ctx.Entry(usuarioAtualizado).State = EntityState.Modified;
            ctx.SaveChanges();

            return usuarioAtualizado;
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        public Usuario Cadastrar(Usuario novoUsuario)
        {
            novoUsuario.DataCriacao = DateTime.Now;
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();

            return novoUsuario;
        }

        //public void Deletar(int id)
        //{
        //    ctx.Usuario.Remove(BuscarPorId(id));

        //    ctx.SaveChanges();
        //}

        public void Deletar(Usuario usuarioDeletado)
        {
            ctx.Usuario.Remove(usuarioDeletado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

    }
}
