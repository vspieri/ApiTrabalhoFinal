namespace Api.Models
{
    public class LoginModel
    {
        public int LoginId { get; set; }

        public string LoginNome { get; set; } = string.Empty;

        public string LoginSenha { get; set; } = string.Empty;


        public static implicit operator List<object>(LoginModel v)
        {
            throw new NotImplementedException();
        }
    }
}
