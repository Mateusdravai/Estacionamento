using Estacionamento.Classes.Enum;

namespace Estacionamento.Classes
{
    public class Estacionamento
    {
        public required List<int> VagasPequenas { get; set; }
        public required List<int> VagasMedias { get; set; }
        public required List<int> VagasGrandes { get; set; }

        public bool Disponibilidade()
        {

            int vagasVan = 0;
            int vagasDisponiveisMoto = VagasPequenas.Capacity - VagasPequenas.Count + VagasGrandes.Capacity + VagasGrandes.Count + (VagasMedias.Capacity - VagasMedias.Count);
            int vagasDisponiveisCarro = VagasMedias.Capacity - VagasMedias.Count + VagasGrandes.Capacity + VagasGrandes.Count;
            for (int i = 1; i <= VagasMedias.Capacity - VagasMedias.Count; i++)
            {
                if (i % 3 == 0)
                    vagasVan = vagasVan + 1;
            }
            int vagasDisponiveisVan = VagasGrandes.Capacity - VagasGrandes.Count + vagasVan;

            if (vagasDisponiveisMoto == 0)
            {
                Console.WriteLine("Não temos mais vagas de moto disponíveis neste momento.");
                return false;
            }

            if (vagasDisponiveisCarro == 0)
            {
                Console.WriteLine("Não temos mais vagas disponíveis para carros ou vans neste momento.");
                return false;
            }

            if (vagasDisponiveisVan == 0)
            {
                Console.WriteLine("Não temos mais vagas disponíveis neste momento.");
                return false;
            }

            return true;
        }

        public void EstacionarVeiculo(TipoVeiculo veiculo)
        {
            switch (veiculo)
            {
                case TipoVeiculo.Moto:
                    if (VagasPequenas.Count < VagasPequenas.Capacity)
                    {
                        VagasPequenas.Add((int)veiculo);
                        Console.WriteLine("Vaga registrada, bem vindo(a)!");
                    }
                    else if (VagasGrandes.Count < VagasGrandes.Capacity)
                    {
                        VagasGrandes.Add((int)veiculo);
                        Console.WriteLine("Vaga registrada, bem vindo(a)!");
                    }
                    else if (VagasMedias.Count < VagasMedias.Capacity)
                    {
                        VagasMedias.Add((int)veiculo);
                        Console.WriteLine("Vaga registrada, bem vindo(a)!");
                    }
                    Console.WriteLine("Todas as vagas de moto estão ocupadas.");
                    break;

                case TipoVeiculo.Carro:
                    if (VagasMedias.Count < VagasMedias.Capacity)
                    {
                        VagasMedias.Add((int)veiculo);
                        Console.WriteLine("Vaga registrada, bem vindo!");
                    }
                    else if (VagasGrandes.Count < VagasGrandes.Capacity)
                    {
                        VagasGrandes.Add((int)veiculo);
                        Console.WriteLine("Vaga registrada, bem vindo!");
                    }
                    Console.WriteLine("Todas as vagas de carro estão ocupadas.");
                    break;

                case TipoVeiculo.Van:
                    if (VagasGrandes.Count < VagasGrandes.Capacity)
                    {
                        VagasGrandes.Add((int)veiculo);
                        Console.WriteLine("Vaga registrada, bem vindo!");
                    }
                    else if (VagasMedias.Capacity - VagasMedias.Count >= 3)
                    {
                        VagasMedias.Add((int)veiculo);
                        VagasMedias.Add((int)veiculo);
                        VagasMedias.Add((int)veiculo);
                        Console.WriteLine("Vaga registrada, bem vindo!");
                    }
                    Console.WriteLine("Todas as vagas de van estão ocupadas.");
                    break;
            }
        }


        public void EstadoAtualVagas()
        {
            int vagasTotal, restanteMoto, restanteCarro, restanteVan, vagasVan = 0;

            int vagasDisponiveisMoto = VagasPequenas.Capacity - VagasPequenas.Count +
                (VagasGrandes.Capacity - VagasGrandes.Count) +
                (VagasMedias.Capacity - VagasMedias.Count);

            int vagasDisponiveisCarro = VagasMedias.Capacity - VagasMedias.Count +
                (VagasGrandes.Capacity - VagasGrandes.Count);

            for (int i = 1; i <= VagasMedias.Capacity - VagasMedias.Count; i++)
            {
                if (i % 3 == 0)
                    vagasVan = vagasVan + 1;
            }

            int vagasDisponiveisVan = VagasGrandes.Capacity - VagasGrandes.Count + vagasVan;

            vagasTotal = VagasPequenas.Capacity + VagasMedias.Capacity + VagasGrandes.Capacity;

            restanteMoto = VagasPequenas.Where(x => x == (int)TipoVeiculo.Moto).Count() +
                VagasMedias.Where(x => x == (int)TipoVeiculo.Moto).Count() +
                VagasGrandes.Where(x => x == (int)TipoVeiculo.Moto).Count();

            restanteCarro = VagasMedias.Where(x => x == (int)TipoVeiculo.Carro).Count() +
                VagasGrandes.Where(x => x == (int)TipoVeiculo.Carro).Count();

            restanteVan = VagasMedias.Where(x => x == (int)TipoVeiculo.Van).Count() +
                VagasGrandes.Where(x => x == (int)TipoVeiculo.Van).Count() / 3;

            Console.WriteLine(@$"Total simples de vagas restantes {vagasTotal}
                {vagasDisponiveisMoto} vagas restantes para motos
                {restanteMoto} vagas ocupadas por motos
                {vagasDisponiveisCarro} vagas restantes para carro
                {restanteCarro} vagas ocupadas por carros
                {vagasDisponiveisVan} vagas restantes para van.
                {restanteVan} vagas ocupadas por carros");
        }

    }
}
