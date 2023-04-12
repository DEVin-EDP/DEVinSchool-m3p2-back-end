using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Perfil
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }

        public Perfil() { }

        public Perfil(int id, string nome) 
        {
            Id = id;
            Nome = nome;
        }
    }
}
