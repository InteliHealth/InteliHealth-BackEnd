using InteliHealth.Data;
using InteliHealth.Domains;
using InteliHealth.Interfaces;
using System.Collections.Generic;

namespace InteliHealth.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context ctx;
        public UsuarioRepository(Context appContext)
        {
            ctx = appContext;
        }
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            throw new System.NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new System.NotImplementedException();
        }
    }
}
