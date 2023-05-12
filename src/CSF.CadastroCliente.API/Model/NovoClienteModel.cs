using System;
using System.Collections.Generic;

namespace CSF.CadastroCliente.API.Model
{
    public class NovoClienteModel
    {
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CodEmpresa { get; set; }
        public List<NovoEnderecoModel> Enderecos { get; set; } = new List<NovoEnderecoModel>();
    }
}
