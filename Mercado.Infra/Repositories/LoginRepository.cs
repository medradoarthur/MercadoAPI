using Mercado.Domain.Entities;
using Mercado.Infra.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Infra.Repositories
{
    public class LoginRepository
    {
        private readonly DtContext _dtContext;

        public LoginRepository(DtContext dtContext)
        {
            _dtContext = dtContext;
        }

        public Mercados RetornaMercado(int idMercado)
        {
            var mercado = _dtContext.Mercados.Where(x => x.IdMercado == idMercado).FirstOrDefault();

            if (mercado == null)
            {
                throw new Exception("Mercado nao encontrado");
            }
            else
            {
                return mercado;
            }
        }

        public Cliente ValidarCliente(string email, string senha)
        {
            var clientes = _dtContext.Cliente.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            if (clientes == null)
            {
                throw new Exception("Login ou senha inválidos");
            }
            else
            {
                clientes.Senha = null;
                clientes.Mercado = _dtContext.Mercados.Where(x => x.IdMercado == clientes.IdMercado).FirstOrDefault();
                clientes.Mercado.Clientes = null;
                return clientes;
            }

        }
    }
}
