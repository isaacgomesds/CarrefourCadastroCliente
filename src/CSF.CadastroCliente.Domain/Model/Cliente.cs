using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSF.CadastroCliente.Domain.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public CodEmpresaEnum CodEmpresa { get; set; }
        public List<ClienteEndereco> Enderecos { get; set; } = new List<ClienteEndereco>();

        public bool ExisteTipoEnderecoDuplicado()
        {
            return Enderecos.GroupBy(e => e.Endereco.TipoEndereco).Any(e => e.Count() > 1);
        }
    }
}
