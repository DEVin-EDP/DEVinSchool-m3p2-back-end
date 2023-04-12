namespace Domain.DTOs
{
    public class UsuarioPutRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Senha { get; set; }
    }
}