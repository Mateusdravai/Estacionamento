using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    public class EstacionamentoRepositorio
    {
        public bool Disponibilidade(Estacionamento estacionamento)
        {
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
                    return false;
                }
            }
            return true;
        }

       public int RetornarVagasMoto(int capacidadeMoto, int vagasOcupadas)
        {
            return capacidadeMoto - vagasOcupadas;
        }

        public int RetornarVagasCarro(int capacidadeCarro, int vagasOcupadas)
        {
            return capacidadeCarro - vagasOcupadas;
        }

        public int RetornarVagasVan(int capacidadeCarro, int vagasOcupadas)
        {
            return capacidadeCarro - vagasOcupadas;
        }
    }
}
