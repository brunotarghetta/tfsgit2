using BCR.Business.Domain.Base;
using System;

namespace BCR.Business.Domain.Configuracion
{
    public class Escala : Entity
    {
        public Int64? Desde { get; set; }

        public Int64? Hasta { get; set; }

        public Semaforo Semaforo { get; set; }

        public Indicador Indicador { get; set; }

        public int Orden { get; set; }
    }
}
