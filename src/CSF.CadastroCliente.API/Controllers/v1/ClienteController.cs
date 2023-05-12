using AutoMapper;
using CSF.CadastroCliente.API.Model;
using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Domain.Services.Interfaces;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CSF.CadastroCliente.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Cliente")]
    [ApiVersion("1.0")]
    public class ClienteController : ControllerBase
    {
        protected ApiResponse _response;

        private readonly IClienteService _clienteService;
        private readonly ICidadeService _cidadeService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, ICidadeService cidadeService, IMapper mapper)
        {
            _clienteService = clienteService;
            _cidadeService = cidadeService;
            _mapper = mapper;

            _response = new ApiResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> Get([FromQuery] FiltroClienteModel filtroRequest)
        {
            try
            {
                IEnumerable<Cliente> clientes;

                if (filtroRequest == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_response);
                }

                if (filtroRequest.CodEmpresa != (int)CodEmpresaEnum.Carrefour &&
                    filtroRequest.CodEmpresa != (int)CodEmpresaEnum.Atacadao)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "CodEmpresa inválido" };

                    return BadRequest(_response);
                }

                var filtro = PredicateBuilder.New<Cliente>();

                filtro.And(c => c.CodEmpresa == (CodEmpresaEnum)filtroRequest.CodEmpresa);

                if (!string.IsNullOrWhiteSpace(filtroRequest.Nome))
                    filtro.And(c => c.Nome.ToUpper().Contains(filtroRequest.Nome.ToUpper()));

                if (!string.IsNullOrWhiteSpace(filtroRequest.CPF))
                    filtro.And(c => c.CPF.Equals(filtroRequest.CPF));

                if (!filtroRequest.CidadeId.Equals(0))
                    filtro.And(c => c.Enderecos.Any(e => e.Endereco.CidadeId.Equals(filtroRequest.CidadeId)));

                if (!string.IsNullOrWhiteSpace(filtroRequest.Estado) && await _cidadeService.EstadoValido(filtroRequest.Estado))
                    filtro.And(c => c.Enderecos.Any(e => e.Endereco.Cidade.Estado.Equals(filtroRequest.Estado)));

                clientes = await _clienteService.ObterClientes(filtro);

                _response.Result = _mapper.Map<List<ClienteModel>>(clientes);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    
                    return BadRequest(_response);
                }

                var cliente = await _clienteService.ObterCliente(id);

                if (cliente == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<ClienteModel>(cliente);
                _response.StatusCode = HttpStatusCode.OK;
                
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] NovoClienteModel clienteRequest)
        {
            try
            {
                if (clienteRequest == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_response);
                }

                var cliente = _mapper.Map<Cliente>(clienteRequest);

                if (!await _clienteService.ValidarCadastroCpfParaEmpresaDesignada(cliente))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "CPF já está cadastrado para essa empresa" };

                    return BadRequest(_response);
                }

                if (cliente.ExisteTipoEnderecoDuplicado())
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "Existe tipos de endereço duplicado" };

                    return BadRequest(_response);
                }

                var result = await _clienteService.CadastrarCliente(cliente);

                if (result < 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "O cliente não foi cadastrado" };

                    return BadRequest(_response);
                }

                _response.Result = _mapper.Map<ClienteModel>(cliente);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction(nameof(Get), new { id = cliente.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> Put(int id, [FromBody] AlteradoClienteModel clienteRequest)
        {
            try
            {
                if (clienteRequest == null || id != clienteRequest.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_response);
                }

                if (!await _clienteService.ClienteExiste(id))
                {
                    _response.StatusCode = HttpStatusCode.NotFound;

                    return NotFound(_response);
                }                    

                var cliente = _mapper.Map<Cliente>(clienteRequest);

                var result = await _clienteService.AtualizarCliente(cliente);

                if (result < 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "O cliente não foi atualizado" };

                    return BadRequest(_response);
                }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_response);
                }

                if (!await _clienteService.ClienteExiste(id))
                {
                    _response.StatusCode = HttpStatusCode.NotFound;

                    return NotFound(_response);
                }

                var result = await _clienteService.DeletarCliente(id);

                if (result < 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "O cliente não foi deletado" };

                    return BadRequest(_response);
                }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
