using BCR.Business.Domain.Base;

namespace BCR.Business.Domain
{
    public class TipoIndicador : Entity
    {
        public string Nombre { get; set; }

        public string ProcedimientoAlmacenado { get; set; }
    }
}
