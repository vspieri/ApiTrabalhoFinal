namespace Api.Models
{
    public class CadastroModel
    {
        public int CadastroId { get; set; }

        public string CadastroNome { get; set; } = string.Empty;

        public string Cnpj { get; set; } = string.Empty;

        public int Telefone { get; set; }

        public string Localidade { get; set; } = string.Empty;

        public string Descrição { get; set; } = string.Empty;

        public string Foto { get; set; } = string.Empty;




        public static implicit operator List<object>(CadastroModel v)
        {
            throw new NotImplementedException();
        }
    }
}
