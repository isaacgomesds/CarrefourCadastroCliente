using System.ComponentModel.DataAnnotations;

namespace CSF.CadastroCliente.API.Model
{
    public class FiltroClienteModel
    {
        [Required]
        public int CodEmpresa { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int CidadeId { get; set; }
        public string Estado { get; set; }
    }
}
