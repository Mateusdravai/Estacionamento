namespace Estacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region variaveis
            int opcao;
            string? nome
            Estacionamento estacionamento = new Estacionamento()
            {
                VagasPequenas = new List<int>(3),
                VagasGrandes = new List<int>(3),
                VagasMedias = new List<int>(3)
            };
            #endregion

            do
            {
                Console.WriteLine("Insira o seu nome aqui: ");
                nome = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(nome));

            Console.WriteLine($"Bem vindo ao Estacionamento Savassi {nome}!");

            for (int i = 0; i < estacionamento.VagasPequenas.Count; i++)
            {
                if (i == estacionamento.VagasPequenas.Capacity)
                    Console.WriteLine("Não temos mais vagas de moto.");

                if (i == estacionamento.VagasMedias.Capacity && i == estacionamento.VagasGrandes.Capacity &&
                     estacionamento.VagasMedias.Capacity < 3)
                    Console.WriteLine("Não temos mais vagas de carro ou van.");

                if (i == estacionamento.VagasPequenas.Capacity && i == estacionamento.VagasMedias.Capacity &&
                      i == estacionamento.VagasGrandes.Capacity && estacionamento.VagasMedias.Capacity < 3)
                {
                    Console.WriteLine("Não temos mais vagas nesse momento.\n");
                    return;
                }
            }

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
        }
    }

    public enum Veiculos
    {
        Moto = 1,
        Carro = 2,
        Van = 3,
    }

    public class Estacionamento
    {
        public required List<int> VagasPequenas { get; set; }
        public required List<int> VagasMedias { get; set; }
        public required List<int> VagasGrandes { get; set; }
    }
}
