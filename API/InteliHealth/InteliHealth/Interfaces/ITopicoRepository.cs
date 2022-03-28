using InteliHealth.Domains;
using System.Collections.Generic;

namespace InteliHealth.Interfaces
{
    public interface ITopicoRepository
    {
        void Cadastrar(Topico novoTopico);
        void Atualizar(int id,Topico topicoAtualizado);
        void Excluir(int id);
        List<Topico> Listar();
        List<Topico> ListarMeus(int id);

    }
}
