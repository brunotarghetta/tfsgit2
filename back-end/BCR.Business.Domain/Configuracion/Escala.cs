using BCR.Business.Domain.Base;

namespace BCR.Business.Domain
{
    public class Escala : Entity
    {
        public int? Desde { get; set; }

        public int? Hasta { get; set; }

        public Semaforo Semaforo { get; set; }

        public Indicador Indicador { get; set; }

        public int Orden { get; set; }
    }
}
