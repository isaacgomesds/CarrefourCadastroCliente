using System;

namespace CSF.CadastroCliente.Domain.Model
{
    public class Cidade
    {
        public Cidade()
        {
        }

        public Cidade(EstadoEnum estado)
        {
            Estado = Enum.GetName(typeof(EstadoEnum), estado);
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; private set; }
    }
}
