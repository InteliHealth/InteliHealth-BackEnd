using InteliHealth.Domains;
using System.Collections.Generic;

namespace InteliHealth.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Cadastrar(Usuario novoUsuario);
        Usuario Atualizar(Usuario usuarioAtualizado);
        void Deletar(Usuario usuarioDeletado);
        Usuario BuscarPorId(int id);
        List<Usuario> Listar();
    }
}
