using Estacionamento.Classes.Enum;

namespace Estacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region variaveis

            string? nome;
            TipoVeiculo veiculo;
            Estacionamento estacionamento = new Estacionamento()
            {
                VagasPequenas = new List<int>(3),
                VagasGrandes = new List<int>(3),
                VagasMedias = new List<int>(3)
            };

            #endregion

            while (true)
            {
                do
                {
                    Console.WriteLine("Insira o seu nome aqui: ");
                    nome = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(nome));

                Console.WriteLine($"Bem vindo ao Estacionamento Savassi {nome}!");

                if (!estacionamento.Disponibilidade())
                {
                    Console.WriteLine("Estacionamento cheios no momento.");
                    return;
                }

                estacionamento.EstadoAtualVagas();

                do
                {
                    Console.WriteLine(@"Informe o número correspondente ao tipo de veículo que deseja estacionar:\n
                        0: Moto
                        1: Carro
                        2: Van
                        3: Sair"
                        );
                }
                while (!Enum.TryParse(Console.ReadLine(), out veiculo));

                if (veiculo == TipoVeiculo.Sair)
                {
                    Console.WriteLine("Obrigado pelo seu tempo conosco, volte sempre!");
                    return;
                }

                estacionamento.EstacionarVeiculo(veiculo);
            }
        }
    }
}
