using InteliHealth.Domains;
using InteliHealth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InteliHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembretesController : ControllerBase
    {
        private readonly ILembreteRepository _lembreteRepository;
        public LembretesController(ILembreteRepository lembreteRepository)
        {
            _lembreteRepository = lembreteRepository;
        }
        // GET: api/Lembretes
        [HttpGet]
        public IActionResult Listar()
        {
            List<Lembrete> lembretes = _lembreteRepository.Listar();

            try
            {
                if (lembretes == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Nenhum lembrete encontrado"
                    });
                }

                return Ok(lembretes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Lembretes/5
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Lembrete lembreteBuscado = _lembreteRepository.BuscarPorId(id);

            try
            {
                if (lembreteBuscado == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Lembrete não encontrado"
                    });
                }

                return Ok(lembreteBuscado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/Lembretes
        [HttpPost]
        public IActionResult CriarLembrete(Lembrete lembrete)
        {
            try
            {
                _lembreteRepository.Cadastrar(lembrete);

                return Ok(new
                {
                    Mensagem = "Lembrete cadastrado com sucesso"
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
       

        // PUT: api/Lembretes/5
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Lembrete lembrete)
        {
            Lembrete lembreteBuscado = _lembreteRepository.BuscarPorId(id);

            try
            {
                if (lembrete.Titulo == null)
                {
                    lembrete.Titulo = lembreteBuscado.Titulo;
                }

                if (lembrete.Horario < DateTime.Now)
                {
                    lembrete.Horario = lembreteBuscado.Horario;
                }

                _lembreteRepository.Atualizar(id, lembrete);

                return StatusCode(204);

            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    Mensagem = "Não foi possível atualizar o lembrete"
                });
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _lembreteRepository.Excluir(id);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    Mensagem = "Não foi possível excluir o lembrete"
                });
                throw;
            }
        }

        [HttpGet("Meus/{id}")]
        public IActionResult ListarMeus(int id)
        {
            List<Lembrete> lembretes = _lembreteRepository.ListarMeus(id);

            try
            {
                if (lembretes == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Lembrete não encontrado"
                    });
                }

                return Ok(lembretes);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    Mensagem = "Não foi possível listar os lembretes"
                });
                throw;
            }
        }
    }
}
