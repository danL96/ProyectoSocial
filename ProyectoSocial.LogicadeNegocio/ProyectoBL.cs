using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
    public class ProyectoBL
    {
        public int AgregarProyectos(Proyecto pProyecto)
        {
            BDComun.Contexto.Proyectos.Add(pProyecto);

            return BDComun.Contexto.SaveChanges();
        }

        public Proyecto BuscarProyectos(Proyecto pProyecto)
        {
            return BDComun.Contexto.Proyectos.SingleOrDefault(c => c.Id == pProyecto.Id);
        }

        public int ModificarProyectos(Proyecto pProyecto)
        {
            Proyecto tmpProyectos = BuscarProyectos(pProyecto);
            tmpProyectos.Id = pProyecto.Id;
            tmpProyectos.Nombre = pProyecto.Nombre;
            tmpProyectos.TipoProyecto = pProyecto.TipoProyecto;

            return BDComun.Contexto.SaveChanges();
        }

        public int EliminarProyectos(Proyecto pProyecto)
        {
            Proyecto tmpProyectos = BuscarProyectos(pProyecto);

            BDComun.Contexto.Proyectos.Remove(tmpProyectos);
            return BDComun.Contexto.SaveChanges();
        }

        public List<Proyecto> ObtenerProyectos()
        {
            return BDComun.Contexto.Proyectos.ToList();
        }

        public List<Proyecto> ObtenerProyectosPorNombre(Proyecto pProyecto)
        {
            return BDComun.Contexto.Proyectos.Where(c => c.Nombre.Contains(pProyecto.Nombre)).ToList();
        }
    }
}
