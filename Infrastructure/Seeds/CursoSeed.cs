using Domain.Abstract;
using Domain.Models;

namespace Infrastructure.Seeds
{
    internal static class CursoSeed
    {
        public static List<Curso> Seed { get; set; } = new List<Curso>()
        {
            new Curso
            {
                Id = 1,
                Nome= "Curso de Java",
                Informacao = "Curso de Java para iniciantes",
                Resumo = "Introdução ao Java",
                Link = "https://w7.pngwing.com/pngs/961/251/png-transparent-java-runtime-environment-programming-language-programmer-computer-programming-java-text-logo-software-developer.png",
                CargaHoraria = 60,
                CategoriaCursoId = 1,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 2,
                Nome= "Adm de Empresas",
                Informacao = "Administração de Empresas para iniciantes",
                Resumo = "Introdução a Administração de Empresas",
                Link = "https://i.pinimg.com/originals/8a/1a/5c/8a1a5c0186881d4a51783bd72b764f9f.png",
                CargaHoraria = 12546,
                CategoriaCursoId = 2,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 3,
                Nome= "Marketing de Redes Sociais",
                Informacao = "Introdução a marketing utilizando redes sociais",
                Resumo = "aprenda utilizar redes sociais para alavancar o seu negócio",
                Link = "https://w7.pngwing.com/pngs/702/844/png-transparent-social-media-marketing-digital-marketing-digital-media-social-media-text-service-social-media-marketing.png",
                CargaHoraria = 120,
                CategoriaCursoId = 3,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 4,
                Nome= "Introdução ao Design Gráfico",
                Informacao = "Técnicas de Designer gráfico.",
                Resumo = "Aprenda técnicas essenciais para ser um Designer gráfico.",
                Link = "https://e7.pngegg.com/pngimages/850/473/png-clipart-logo-graphic-design-graphics-product-design-logo-graphic-design.png",
                CargaHoraria = 60,
                CategoriaCursoId = 4,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 5,
                Nome= "Tecnologia em Banco de Dados",
                Informacao = "Técnicas de Banco de Dados.",
                Resumo = "Aprenda aprenderá como trabalhar com grande quantidade de informações e dados que entram no banco de dados de uma empresa, como por exemplo, salários, lista de clientes e fornecedores, relatórios, dentre outros. É uma atividade muito minuciosa, na qual o profissional a desenvolverá sendo incumbido de organizar tais dados, de modo a deixá-los sempre atualizados, realizando a manutenção dos mesmos.",
                Link = "https://w7.pngwing.com/pngs/108/671/png-transparent-database-administrator-computer-icons-others-orange-logo-data.png",
                CargaHoraria = 100,
                CategoriaCursoId = 1,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 6,
                Nome= "Tecnologia em rede de Computadores",
                Informacao = "Rede de Computadores para iniciantes",
                Resumo = "O estudante aprenderá como disponibilizar várias redes e gerenciar todas elas para a empresa, como intranet, bluetooth, WI-FI, internet e LAN, além de sistemas de seguranças para não haver prejuízos.",
                Link = "https://e7.pngegg.com/pngimages/863/566/png-clipart-computer-network-computer-icons-local-area-network-information-technology-internet-computer-computer-network-computer.png",
                CargaHoraria = 60,
                CategoriaCursoId = 1,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 7,
                Nome= "Sistema de Informação",
                Informacao = "Faculdade contendo tudo que engloba sistema de informação.",
                Resumo = "curso em que se aprende a trabalhar com redes de computadores podendo administrar, criar, garantir a segurança das redes, instalar e configurar sistemas de softwares, dentre outros aprendizados.",
                Link = "https://w7.pngwing.com/pngs/435/773/png-transparent-information-system-sao-paulo-state-technological-college-technology-technology.png",
                CargaHoraria = 900,
                CategoriaCursoId = 1,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 8,
                Nome= "Administração de Comércio exterior.",
                Informacao = "As atividades que este profissional realiza em seu cotidiano dependem do setor da economia.",
                Resumo = "O profissional que atua na área de Comércio Exterior é o responsável por realizar a compra e venda de produtos e serviços entre instituições de diferentes países. É por isso que ele sempre precisa estar atento ao que acontece no mundo todo, principalmente nos assuntos econômicos, sociais e políticos do país em que se está negociando.",
                Link = "https://w7.pngwing.com/pngs/335/1019/png-transparent-logistics-international-trade-export-transport-others-freight-transport-service-cargo.png",
                CargaHoraria = 124,
                CategoriaCursoId = 2,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 9,
                Nome= "Master em Marketing e Comunicação Digital",
                Informacao = "Quando falamos de profissionais de nível avançado, estamos nos referindo a especialistas.",
                Resumo = "tem como principal objetivo oferecer conhecimentos e habilidades para que o profissional esteja capacitado a utilizar a internet em processos de vendas empresariais, com o intuito de aumentar a competitividade da organização no mercado de trabalho.",
                Link = "https://w7.pngwing.com/pngs/48/230/png-transparent-digital-marketing-mass-media-marketing-text-computer-logo.png",
                CargaHoraria = 120,
                CategoriaCursoId = 3,
                CursoAtivo = true
            },
            new Curso
            {
                Id = 10,
                Nome= "Design de Games",
                Informacao = "Habilitado para criar, projetar e realizar a execução de jogos eletrônicos para diversos aparelhos, como smartphones, tablets ou computadores.",
                Resumo = "O profissional da área de Design de Games precisa compreender o público-alvo e as tendências do mercado que ele está inserido. Dentro do processo de produção, o Designer de Games tomará decisões com o objetivo de tornar o seu produto atraente e operante.",
                Link = "https://w7.pngwing.com/pngs/50/329/png-transparent-video-game-development-computer-icons-video-game-developer-design.png",
                CargaHoraria = 60,
                CategoriaCursoId = 4,
                CursoAtivo = true
            },

        };
    }
}
