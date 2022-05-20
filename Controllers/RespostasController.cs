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
    public class RespostasController : ControllerBase
    {
        private readonly IRespostaRepository _respostaRepository;
        public RespostasController(IRespostaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }
       
        // GET: api/Respostas
        [HttpGet]
        public IActionResult Listar()
        {
            List<Resposta> respostas = _respostaRepository.Listar();
            try
            {
                if (respostas == null)
                {
                    return BadRequest(new
                    {
                        Erro = "Nenhuma resposta encontrada"
                    });             
                }

                return Ok(respostas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Erro = "Erro no banco de dados, contate o administrador!"
                    });
                throw;
            }

        }

        // GET: api/Respostas/5
        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Resposta respostaBuscada = _respostaRepository.BuscarPorId(id);
            try
            {
                if (respostaBuscada == null)
                {
                    return BadRequest(new
                    {
                        Erro = "Resposta não encontrada"
                    });
                }

                return Ok(respostaBuscada);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Erro = "Erro no banco de dados, contate o administrador!"
                    });
                throw;
            }   
        }

        // POST: api/Respostas
        [HttpPost]
        public IActionResult Cadastrar(Resposta resposta)
        {
            try
            {
                _respostaRepository.Cadastrar(resposta);

                return StatusCode(201, new
                {
                    mensagem = "Resposta cadastrada com sucesso!"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    Erro = "Erro ao cadastrar resposta"
                });
                throw;
            }
        }

        [HttpGet("Meus/{id}")]
        public IActionResult ListarMeus(int id)
        {
            List<Resposta> respostas = _respostaRepository.ListarMeus(id);
            try
            {
                if (respostas == null)
                {
                    return BadRequest(new
                    {
                        Erro = "Nenhuma resposta encontrada"
                    });
                }

                return Ok(respostas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Erro = "Erro no banco de dados, contate o administrador!"
                    });
                throw;
            }
        }
        
        [HttpGet("Meus/Realizados/{id}")]
        public IActionResult ListarMeusRealizados(int id)
        {
            List<Resposta> respostas = _respostaRepository.ListarMeusRealizados(id);
            try
            {
                if (respostas == null)
                {
                    return BadRequest(new
                    {
                        Erro = "Nenhuma resposta encontrada"
                    });
                }

                return Ok(respostas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Erro = "Erro no banco de dados, contate o administrador!"
                    });
                throw;
            }
        }
    }
}
