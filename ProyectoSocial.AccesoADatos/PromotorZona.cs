//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoSocial.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromotorZona
    {
        public long Id { get; set; }
        public long IdProyecto { get; set; }
        public long IdPromotor { get; set; }
        public long IdZona { get; set; }
        public long IdActividad { get; set; }
        public long IdADESCO { get; set; }
    
        public virtual Actividade Actividade { get; set; }
        public virtual ADESCO ADESCO { get; set; }
        public virtual Promotore Promotore { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual Zona Zona { get; set; }
    }
}
