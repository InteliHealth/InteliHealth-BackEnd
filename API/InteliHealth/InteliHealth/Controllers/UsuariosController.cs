using InteliHealth.Domains;
using InteliHealth.Interfaces;
using InteliHealth.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace InteliHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult Listar()
        {
            List<Usuario> listaUsuarios = _usuarioRepository.Listar();

            try
            {
                if (listaUsuarios == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Nenhum usuário encontrado"
                    });
                }

                return Ok(listaUsuarios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult BuscarUsuario(int id)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            try
            {
                if (usuarioBuscado == null)
                {
                    return StatusCode(204);
                }

                return Ok(usuarioBuscado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {

            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuario.Nome == null)
                {
                    usuario.Nome = usuarioBuscado.Nome;
                }
                if (usuario.Sobrenome == null)
                {
                    usuario.Sobrenome = usuarioBuscado.Sobrenome;
                }
                if (usuario.DataNascimento >= DateTime.Now)
                {
                    usuario.DataNascimento = usuarioBuscado.DataNascimento;
                }
                if (usuario.Altura == null)
                {
                    usuario.Altura = usuarioBuscado.Altura;
                }
                if (usuario.Peso == null)
                {
                    usuario.Peso = usuarioBuscado.Peso;
                }
                if (usuario.TipoSanguineo == null)
                {
                    usuario.TipoSanguineo = usuarioBuscado.TipoSanguineo;
                }
                if (usuario.Foto == null)
                {
                    usuario.Foto = usuarioBuscado.Foto;
                }

                _usuarioRepository.Atualizar(id, usuario);

                return StatusCode(204);
            }
            catch (Exception)
            {
                return NoContent();

                throw;
            }
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, new
                {
                    Mensagem = "Usuário criado"
                });
            }
            catch (Exception)
            {
                return BadRequest();

                throw;
            }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
