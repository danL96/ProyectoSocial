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
    
    public partial class Promotore
    {
        public Promotore()
        {
            this.PromotorProyectoes = new HashSet<PromotorProyecto>();
            this.PromotorZonas = new HashSet<PromotorZona>();
            this.Proyectos = new HashSet<Proyecto>();
        }
    
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public long IdZona { get; set; }
    
        public virtual Zona Zona { get; set; }
        public virtual ICollection<PromotorProyecto> PromotorProyectoes { get; set; }
        public virtual ICollection<PromotorZona> PromotorZonas { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
