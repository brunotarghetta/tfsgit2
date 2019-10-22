using BCR.Business.Domain.Base;
using System;

namespace BCR.Business.Domain.Configuracion
{
    public class ParametroConfiguracion : Aggregate
    {
        public string Nombre { get; set; }

        public string pr_ejecucion { get; set; }
        //
        public Int64 EscalaPrimera { get; set; } //100
        //
        public Int64 EscalaSegunda { get; set; } //200
        //
        public Int64 EscalaTercera { get; set; } //500
        //
        public bool Minimo { get; set; }

    }
}
