using InteliHealth.Domains;
using System.Collections.Generic;

namespace InteliHealth.Interfaces
{
    public interface IRespostaRepository
    {
        void Cadastrar(Resposta novaResposta);
        List<Resposta> ListarMeus(int id);
        Resposta BuscarPorId(int id);
    }
}
