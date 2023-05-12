using AutoMapper;
using CSF.CadastroCliente.API.Controllers;
using CSF.CadastroCliente.API.Controllers.v1;
using CSF.CadastroCliente.API.Model;
using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Domain.Services.Interfaces;
using CSF.CadastroCliente.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSF.CadastroCliente.UnitTests.Systems.Controllers
{
    public class TestClientController
    {
        [Fact]
        public async Task Get_OnSuccess_listar_todos_clientes_cadastros()
        {
            // Arrange
            var mockClienteService = new Mock<IClienteService>();
            var mockCidadeCliente = new Mock<ICidadeService>();
            var mockMapper = new Mock<IMapper>();

            mockClienteService
                .Setup(service => service.ObterCliente(It.IsAny<int>()))
                .ReturnsAsync(ClienteFixture.ObterTesteClientes().FirstOrDefault(e => e.Id == 1));            

            var sut = new ClienteController(mockClienteService.Object, mockCidadeCliente.Object, mockMapper.Object);

            var id = 1;

            // Act
            var result = (ActionResult<ApiResponse>)await sut.Get(id);

            // Assert
            mockClienteService.Verify(service => service.ObterCliente(1), Times.Once());
        }

        //[Fact]
        //public async Task Get_OnSuccess_retorna_lista_clientes()
        //{
        //    // Arrange]
        //    var mockCadastroCliente = new Mock<IClienteService>();
        //    mockCadastroCliente
        //        .Setup(service => service.ObterTodosClientes())
        //        .ReturnsAsync(new List<Cliente>());
        //    var mockMapper = new Mock<IMapper>();

        //    var sut = new ClienteController(mockCadastroCliente.Object, mockMapper.Object);

        //    // Act
        //    var result = (OkObjectResult)await sut.Get(null);

        //    // Assert
        //    result.Should().BeOfType<OkObjectResult>();
        //    var objectResult = (OkObjectResult)result;
        //    objectResult.Value.Should().BeOfType<List<Cliente>>();
        //}

        //[Fact]
        //public async Task Get_OnSuccess_NaoEncontrado()
        //{
        //    // Arrange]
        //    var mockCadastroCliente = new Mock<IClienteService>();
        //    mockCadastroCliente
        //        .Setup(service => service.ObterTodosClientes())
        //        .ReturnsAsync(ClienteFixture.ObterUsuarios());
        //    var mockMapper = new Mock<IMapper>();

        //    var sut = new ClienteController(mockCadastroCliente.Object, mockMapper.Object);

        //    // Act
        //    var result = (OkObjectResult)await sut.Get(null);

        //    // Assert
        //    result.Should().BeOfType<NotFoundResult>();
        //}
    }
}
