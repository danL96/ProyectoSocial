﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDProyeccionSocialEntities : DbContext
    {
        public BDProyeccionSocialEntities()
            : base("name=BDProyeccionSocialEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Actividade> Actividades { get; set; }
        public DbSet<ADESCO> ADESCOS { get; set; }
        public DbSet<Administradore> Administradores { get; set; }
        public DbSet<MiembrosADESCO> MiembrosADESCOes { get; set; }
        public DbSet<Promotore> Promotores { get; set; }
        public DbSet<PromotorProyecto> PromotorProyectoes { get; set; }
        public DbSet<PromotorZona> PromotorZonas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<ReportePromotor> ReportePromotors { get; set; }
    }
}