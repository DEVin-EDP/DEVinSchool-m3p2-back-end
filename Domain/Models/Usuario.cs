using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Usuario : _BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }
        [Column("cpf")]
        public string CPF { get; set; }
        [Column("idade")]
        public int Idade { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("foto")]
        public string Foto { get; set; }
        [Column("ativo")]
        public bool UsuarioAtivo { get; set; }
        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        [Column("perfil_funcao")]
        [ForeignKey("IdPerfil")]
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
