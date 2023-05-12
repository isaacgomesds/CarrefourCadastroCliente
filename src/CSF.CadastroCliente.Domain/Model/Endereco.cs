namespace CSF.CadastroCliente.Domain.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int TipoEndereco { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public ClienteEndereco ClienteEndereco { get; set; }
    }
}
