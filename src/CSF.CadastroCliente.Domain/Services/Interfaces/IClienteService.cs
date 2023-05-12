using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CSF.CadastroCliente.Domain.Model;

namespace CSF.CadastroCliente.Domain.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObterClientes(Expression<Func<Cliente, bool>> filter = null);
        Task<Cliente> ObterCliente(int id);
        Task<int> CadastrarCliente(Cliente cliente);
        Task<int> AtualizarCliente(Cliente cliente);
        Task<int> DeletarCliente(int id);
        Task<bool> ClienteExiste(int id);
        Task<bool> ValidarCadastroCpfParaEmpresaDesignada(Cliente cliente);
    }
}
