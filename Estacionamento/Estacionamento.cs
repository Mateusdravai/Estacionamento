using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    public class Estacionamento
    {
        public required List<int> VagasPequenas { get; set; }
        public required List<int> VagasMedias { get; set; }
        public required List<int> VagasGrandes { get; set; }
    }
}
