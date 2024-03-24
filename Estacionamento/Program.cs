namespace Estacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region variaveis
            int opcao = -1, vagasMoto, vagasCarro, vagasVan, vagasTotal, restanteMoto, restanteCarro, restanteVan;
            string? nome;
            Estacionamento estacionamento = new Estacionamento()
            {
                VagasPequenas = new List<int>(3),
                VagasGrandes = new List<int>(3),
                VagasMedias = new List<int>(3)
            };
            EstacionamentoRepositorio estacionamentoRepositorio = new EstacionamentoRepositorio();
            #endregion

            while (opcao != 0)
            {
                do
                {
                    Console.WriteLine("Insira o seu nome aqui: ");
                    nome = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(nome));

                Console.WriteLine($"Bem vindo ao Estacionamento Savassi {nome}!");

                if (!estacionamentoRepositorio.Disponibilidade(estacionamento))
                {
                    Console.WriteLine("Estacionamento cheio no momento.");
                    return;
                }

                vagasMoto = estacionamentoRepositorio.RetornarVagasMoto(estacionamento.VagasPequenas.Capacity,
                    estacionamento.VagasPequenas.Count);
                vagasCarro = estacionamentoRepositorio.RetornarVagasCarro(estacionamento.VagasMedias.Capacity,
                    estacionamento.VagasMedias.Count);
                vagasVan = estacionamentoRepositorio.RetornarVagasVan(estacionamento.VagasGrandes.Capacity,
                    estacionamento.VagasGrandes.Count);

                vagasTotal = vagasMoto + vagasVan + vagasCarro;

                vagasMoto = vagasTotal;
                vagasCarro = vagasCarro + vagasVan;
                for (int i = 1; i <= (vagasCarro - vagasVan); i++)
                {
                    if (i % 3 == 0)
                    {
                        vagasVan += 1;
                    }
                }

                 restanteMoto = estacionamento.VagasPequenas.Where(x => x == 1).Count() +
                     estacionamento.VagasMedias.Where(x => x == 1).Count() +
                     estacionamento.VagasGrandes.Where(x => x == 1).Count();

                 restanteCarro = estacionamento.VagasMedias.Where(x => x == 2).Count() +
                     estacionamento.VagasGrandes.Where(x => x == 2).Count();

                 restanteVan = estacionamento.VagasMedias.Where(x => x == 3).Count() +
                     estacionamento.VagasGrandes.Where(x => x == 3).Count();

                Console.WriteLine($"Total simples de vagas restantes {vagasTotal}\n\n" +
                    $"{vagasMoto} vagas restantes para motos.\n" +
                    $"{restanteMoto} vagas ocupadas por motos\n\n" +
                    $"{vagasCarro} vagas restantes para carro.\n" +
                    $"{restanteCarro} vagas ocupadas por carros\n\n" +
                    $"{vagasVan} vagas restantes para van.\n\n" +
                    $"{restanteVan} vagas ocupadas por carros\n\n");

                do
                {
                    Console.WriteLine(@"Informe o número correspondente ao tipo de veículo que deseja estacionar:\n" +
                        "1: Moto\n" +
                        "2: Carro\n" +
                        "3: Van\n" +
                        "0: Sair"
                        );
                }
                while (int.TryParse(Console.ReadLine(), out opcao) || opcao > 3 || opcao < 0);

                switch (opcao)
                {
                    case 1:
                        if(vagasMoto > 0)
                        {
                            estacionamento.VagasPequenas.Add(opcao);
                            Console.WriteLine("Vaga registrada, bem vindo(a)!");
                        }

                        else if(vagasCarro > 0)
                        {
                            estacionamento.VagasMedias.Add(opcao);
                            Console.WriteLine("Vaga registrada, bem vindo(a)!");
                        }

                        else if(vagasVan > 0)
                        {
                            estacionamento.VagasGrandes.Add(opcao);
                            Console.WriteLine("Vaga registrada, bem vindo!");
                        }

                        Console.WriteLine("Todas as vagas de moto estão ocupadas.");
                        break;

                    case 2:
                        if (vagasCarro > 0)
                        {
                            estacionamento.VagasMedias.Add(opcao);
                            Console.WriteLine("Vaga registrada, bem vindo!");
                        }

                        else if(vagasVan > 0)
                        {
                            estacionamento.VagasGrandes.Add(opcao);
                            Console.WriteLine("Vaga registrada, bem vindo!");
                        }

                        Console.WriteLine("Todas as vagas de carro estão ocupadas.");
                        break;

                    case 3:
                        if(vagasVan > 0)
                        {
                            estacionamento.VagasGrandes.Add(opcao);
                            Console.WriteLine("Vaga registrada, bem vindo!");
                        }

                        else if(vagasCarro >= 3)
                        {
                            estacionamento.VagasMedias.Add(opcao);
                            estacionamento.VagasMedias.Add(opcao);
                            estacionamento.VagasMedias.Add(opcao);
                            Console.WriteLine("Vaga registrada, bem vindo!");
                        }

                        Console.WriteLine("Todas as vagas de van estão ocupadas.");
                        break;
                }
            }
        }
    }
}
