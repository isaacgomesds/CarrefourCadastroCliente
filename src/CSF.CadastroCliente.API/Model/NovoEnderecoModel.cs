namespace CSF.CadastroCliente.API.Model
{
    public class NovoEnderecoModel
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int TipoEndereco { get; set; }
        public int CidadeId { get; set; }
    }
}
