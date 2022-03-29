using InteliHealth.Domains;
using System.Collections.Generic;

namespace InteliHealth.Interfaces
{
    public interface ILembreteRepository
    {
        void Cadastrar(Lembrete novoLembrete);
        void Atualizar(int id,Lembrete lembreteAtualizado);
        void Excluir(int id);
        List<Lembrete> Listar();
        List<Lembrete> ListarMeus(int id);
        Lembrete BuscarPorId(int id);
    }
}
