using Domain.Models;

namespace Infrastructure.Seeds
{
    internal static class UsuarioSeed
    {
        public static List<Usuario> Seed { get; set; } = new List<Usuario>()
        {
            new Usuario
            {
                Id = 1,
                Nome= "teste",
                Email = "teste@gmail.com",
                Idade = 30,
                Senha = "teste123",
                CPF = "11122233308",
                DataCadastro = DateTime.Now,
                Foto = "https://i.pinimg.com/236x/37/01/e7/3701e763f6ded4234b68d8fac1a9fa85.jpg",
                UsuarioAtivo = true,
                PerfilId = 2
            },
            new Usuario
            {
                Id = 2,
                Nome= "Tiago",
                Email = "tiago@gmail.com",
                Idade = 22,
                Senha = "tester12345678",
                CPF = "11122233308",
                DataCadastro = DateTime.Now,
                Foto = "https://i.pinimg.com/236x/05/0b/72/050b721378546e519bd6e33c4ccf9630.jpg",
                UsuarioAtivo = true,
                PerfilId = 1
            },
            new Usuario
            {
                Id = 3,
                Nome= "José",
                Email = "josé@gmail.com",
                Idade = 55,
                Senha = "tester12345678",
                CPF = "11122233308",
                DataCadastro = DateTime.Now,
                Foto = "https://pbs.twimg.com/profile_images/1268204267749494788/az__pHAX_400x400.jpg",
                UsuarioAtivo = true,
                PerfilId = 1
            },
            new Usuario
            {
                Id = 5,
                Nome= "Ana Martha",
                Email = "ana@mail.com",
                Idade = 32,
                Senha = "ana12345",
                CPF = "12345278412",
                DataCadastro = DateTime.Now,
                Foto = "https://example.com/myphoto.jpg",
                UsuarioAtivo = true,
                PerfilId = 1
            },
            new Usuario
            {
                Id = 6,
                Nome= "Maria Callas",
                Email = "callas@mail.com",
                Idade = 30,
                Senha = "123asdfg",
                CPF = "78945612345",
                DataCadastro = DateTime.Now,
                Foto = "https://example.com/myphoto.jpg",
                UsuarioAtivo = true,
                PerfilId = 1
            },
            new Usuario
            {
                Id = 7,
                Nome= "Rita Lee",
                Email = "rita@mail.com\"",
                Idade = 82,
                Senha = "rita1234",
                CPF = "23456242189",
                DataCadastro = DateTime.Now,
                Foto = "https://example.com/myphoto.jpg",
                UsuarioAtivo = true,
                PerfilId = 1
            }
        };
    }
}
