namespace CSF.CadastroCliente.Domain.Model
{
    public class ClienteEndereco
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
