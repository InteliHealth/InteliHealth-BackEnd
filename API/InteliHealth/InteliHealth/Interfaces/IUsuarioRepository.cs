﻿using InteliHealth.Domains;
using System.Collections.Generic;

namespace InteliHealth.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(int id, Usuario usuarioAtualizado);
        void Deletar(int id);
        Usuario BuscarPorId(int id);
        List<Usuario> Listar();
    }
}
