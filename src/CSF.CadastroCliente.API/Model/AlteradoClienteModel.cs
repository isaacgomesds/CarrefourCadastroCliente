using System;
using System.Collections.Generic;

namespace CSF.CadastroCliente.API.Model
{
    public class AlteradoClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CodEmpresa { get; set; }
        public List<AlteradoEnderecoModel> Enderecos { get; set; } = new List<AlteradoEnderecoModel>();
    }
}
