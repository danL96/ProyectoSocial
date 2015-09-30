using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
   public class ActividadBL
    {
       public int AgregarActividades(Actividade pActividade)
        {
            BDComun.Contexto.Actividades.Add(pActividade);

            return BDComun.Contexto.SaveChanges();
        }

       public Actividade BuscarActividades(Actividade pActividade)
        {
            return BDComun.Contexto.Actividades.SingleOrDefault(c => c.Id == pActividade.Id);
        }

       public int ModificarActividades(Actividade pActividade)
        {
            Actividade tmpActividades = BuscarActividades(pActividade);
            tmpActividades.Id = pActividade.Id;
            tmpActividades.Nombre = pActividade.Nombre;
            tmpActividades.Tipo = pActividade.Tipo;
            tmpActividades.Fecha = pActividade.Fecha;

            return BDComun.Contexto.SaveChanges();
        }

       public int EliminarActividades(Actividade pActividade)
        {
            Actividade tmpActividades = BuscarActividades(pActividade);

            BDComun.Contexto.Actividades.Remove(tmpActividades);
            return BDComun.Contexto.SaveChanges();
        }

       public List<Actividade> ObtenerActividades()
        {
            return BDComun.Contexto.Actividades.ToList();
        }

       public List<Actividade> ObtenerActividadesPorNombre(Actividade pActividade)
        {
            return BDComun.Contexto.Actividades.Where(c => c.Nombre.Contains(pActividade.Nombre)).ToList();
        }
    }
}
