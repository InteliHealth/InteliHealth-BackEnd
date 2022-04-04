using InteliHealth.Domains;
using InteliHealth.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InteliHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicosController : ControllerBase
    {
        private readonly ITopicoRepository _topicoRepository;
        public TopicosController(ITopicoRepository topicoRepository)
        {
            _topicoRepository = topicoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<Topico> listaTopicos = _topicoRepository.Listar();

            try
            {
                if (listaTopicos == null)
                {
                    return BadRequest(new
                    {
                        Message = "Nenhum tópico encontrado"
                    });
                }
                return Ok(listaTopicos);
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarTopicos(int id)
        {
            Topico topicoBuscado = _topicoRepository.BuscarPorId(id);

            try
            {
                if (topicoBuscado == null)
                {
                    return NoContent();
                }

                return Ok(topicoBuscado);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTopico(int id, Topico topico)
        {
            try
            {
                Topico topicoBuscado = _topicoRepository.BuscarPorId(id);

                if (topico.Nome == null)
                {
                    topico.Nome = topicoBuscado.Nome;
                }
                if (topico.Icone == null)
                {
                    topico.Icone = topicoBuscado.Icone;
                }

                _topicoRepository.Atualizar(id, topico);

                return StatusCode(204);
            }
            catch (Exception)
            {
                return NoContent();
                throw;
            }
        }

        [HttpPost]
        public IActionResult CadastrarTopico(Topico topico)
        {
            try
            {
                _topicoRepository.Cadastrar(topico);

                return StatusCode(201, new 
                { 
                    message = "Topico criado" 
                });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTopico(int id)
        {
            try
            {
                _topicoRepository.Excluir(id);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("Meus/{id}")]
        public IActionResult ListarMeus(int id)
        {
            List<Topico> listaTopicos = _topicoRepository.ListarMeus(id);

            try
            {
                if (listaTopicos == null)
                {
                    return BadRequest(new
                    {
                        message = "Nenhum tópico encontrado"
                    });
                }

                return Ok(listaTopicos);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
