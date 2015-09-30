using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
   public class ZonaBL
    {
       public int AgregarZonas(Zona pZona)
        {
            BDComun.Contexto.Zonas.Add(pZona);

            return BDComun.Contexto.SaveChanges();
        }

       public Zona BuscarZonas(Zona pZona)
        {
            return BDComun.Contexto.Zonas.SingleOrDefault(c => c.Id == pZona.Id);
        }

       public int ModificarZonas(Zona pZona)
        {
            Zona tmpZonas = BuscarZonas(pZona);
            tmpZonas.Id = pZona.Id;
            tmpZonas.Nombre = pZona.Nombre;
           

            return BDComun.Contexto.SaveChanges();
        }

       public int EliminarZonas(Zona pZona)
        {
            Zona tmpZonas = BuscarZonas(pZona);

            BDComun.Contexto.Zonas.Remove(tmpZonas);
            return BDComun.Contexto.SaveChanges();
        }

       public List<Zona> ObtenerZonas()
        {
            return BDComun.Contexto.Zonas.ToList();
        }

       public List<Zona> ObtenerZonasPorNombre(Zona pZona)
        {
            return BDComun.Contexto.Zonas.Where(c => c.Nombre.Contains(pZona.Nombre)).ToList();
        }

       //VERIFICAR EXISTENCIA DE DATOS
       public int VerificarDatos(Zona pZona)
       {
           Int32 Resultado = 0;
           List<Zona> ListaZona = BDComun.Contexto.Zonas.Where(Z => Z.Nombre == pZona.Nombre).ToList() as List<Zona>;

           if (ListaZona.Count() > 0)
           {
               Resultado = 1;
           }
           else
           {
               Resultado = 0;
           }
           return Resultado;

       }
    }
}
