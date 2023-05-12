using CSF.CadastroCliente.Domain.Model;
using System;
using System.Collections.Generic;

namespace CSF.CadastroCliente.UnitTests.Fixtures
{
    public static class ClienteFixture
    {
        public static List<Cliente> ObterTesteClientes()
        {
            return new List<Cliente>
            {
                new Cliente
                {
                    Id = 1,
                    Nome = "Sarah Pinto Correia",
                    RG = "",
                    CPF = "430.920.821-50",
                    DataNascimento = new DateTime(1999, 10, 1),
                    Telefone = "(34) 2005-6802",
                    Email = "SarahPintoCorreia@rhyta.com",
                    CodEmpresa = CodEmpresaEnum.Carrefour,
                    Enderecos = new List<ClienteEndereco>
                    {
                        new ClienteEndereco
                        {
                            Endereco = new Endereco
                            {
                                Id = 1,
                                Rua = "Rua Alberto Mafredini",
                                Bairro = "",
                                Numero = "1447",
                                Complemento = "Casa",
                                Cep = "38056-667",
                                TipoEndereco = 1,
                                CidadeId = CodigoCidadeConstants.UBERABA,
                                Cidade = new Cidade(EstadoEnum.MG)
                                {
                                    Id = CodigoCidadeConstants.UBERABA,
                                    Nome = "UBERABA",
                                }                               
                            }
                        }
                    }

                },
                new Cliente
                {
                    Id = 2,
                    Nome = "Sarah Pinto Correia",
                    RG = "",
                    CPF = "430.920.821-50",
                    DataNascimento = new DateTime(1999, 10, 1),
                    Telefone = "(34) 2005-6802",
                    Email = "SarahPintoCorreia@rhyta.com",
                    CodEmpresa = CodEmpresaEnum.Carrefour,
                    Enderecos = new List<ClienteEndereco>
                    {
                        new ClienteEndereco
                        {
                            Endereco = new Endereco
                            {
                                Id = 2,
                                Rua = "Rua Alberto Mafredini",
                                Bairro = "",
                                Numero = "1447",
                                Complemento = "Casa",
                                Cep = "38056-667",
                                TipoEndereco = 1,
                                CidadeId = CodigoCidadeConstants.UBERABA,
                                Cidade = new Cidade(EstadoEnum.MG)
                                {
                                    Id = CodigoCidadeConstants.UBERABA,
                                    Nome = "UBERABA",
                                }
                            }
                        }
                    }

                }
            };
        }

        public static class CodigoCidadeConstants 
        {
            public const int UBERABA = 2388;
        }
    }
}
