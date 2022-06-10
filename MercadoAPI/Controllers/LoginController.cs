using Mercado.Domain.Entities;
using Mercado.Infra.Repositories;
using MercadoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/login")]
    public class LoginController : Controller
    {

        private readonly LoginRepository _repository;

        public LoginController(LoginRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("TesteAPI/{nome}/{idade:int}")]
        [AllowAnonymous]
        public string TesteAPI(string nome, int idade)
        {
            return "Olá, " + nome + ". Tenho " + idade.ToString() + " anos e estou funcionando!";
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("ValidarCliente/{email}/{senha}")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> ValidarCliente(string email, string senha)
        {
            try
            {
                var cliente = _repository.ValidarCliente(email, senha);
                var token = TokenService.GenerateToken(cliente);

                return Ok(new
                {
                    cliente = cliente,
                    token = token
                });
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("RetornaMercado/{idMercado:int}")]
        [Authorize]
        public async Task<ActionResult<Mercados>> RetornaMercado(int idMercado)
        {
            try
            {
                var mercado = _repository.RetornaMercado(idMercado);

                return Ok(mercado);
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
