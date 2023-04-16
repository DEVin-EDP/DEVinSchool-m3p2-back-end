namespace Domain.DTOs
{
    public class UsuarioResponse
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public int PerfilId { get; set; }
    }
}
