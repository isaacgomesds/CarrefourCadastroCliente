using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSF.CadastroCliente.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new InvalidDataException("ClienteRepository não pode ser nulo");
        }

        public async Task<int> AtualizarCliente(Cliente cliente)
        {
            return await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task<int> CadastrarCliente(Cliente cliente)
        {
            _clienteRepository.Add(cliente);

            return await _clienteRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<bool> ClienteExiste(int id)
        {
            return await _clienteRepository.AnyAsync(x => x.Id == id);
        }

        public async Task<int> DeletarCliente(int id)
        {
            var entity = await _clienteRepository.GetClienteByIdAsync(id);

            return await _clienteRepository.DeleteAsync(entity);
        }

        public async Task<List<Cliente>> ObterClientes(Expression<Func<Cliente, bool>> filter = null)
        {
            var results = _clienteRepository.GetAllBySpec(filter)
                .Include(e => e.Enderecos)
                .ThenInclude(e => e.Endereco)
                .ThenInclude(e => e.Cidade);

            return await Task.FromResult(results.ToList());
        }

        public async Task<Cliente> ObterCliente(int id)
        {
            var entity = await _clienteRepository.GetClienteByIdAsync(id);

            return await Task.FromResult(entity);
        }

        public async Task<bool> ValidarCadastroCpfParaEmpresaDesignada(Cliente cliente)
        {
            return !await _clienteRepository.AnyAsync(x => x.CPF == cliente.CPF && x.CodEmpresa == cliente.CodEmpresa);
        }
    }
}
