using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
    public class PromotorBL
    {

        public int AgregarPromotores(Promotore pPromotore)
        {
            BDComun.Contexto.Promotores.Add(pPromotore);

            return BDComun.Contexto.SaveChanges();
        }

        public Promotore BuscarPromotores(Promotore pPromotore)
        {
            return BDComun.Contexto.Promotores.SingleOrDefault(c => c.Id == pPromotore.Id);
        }

        public int ModificarPromotores(Promotore pPromotore)
        {
            Promotore tmpPromotores = BuscarPromotores(pPromotore);
            tmpPromotores.Id = pPromotore.Id;
            tmpPromotores.Nombre = pPromotore.Nombre;
            tmpPromotores.Apellido = pPromotore.Apellido;
            tmpPromotores.Telefono = pPromotore.Telefono;
            tmpPromotores.Direccion = pPromotore.Direccion;


            return BDComun.Contexto.SaveChanges();
        }

        public int EliminarPromotores(Promotore pPromotore)
        {
            Promotore tmpPromotores = BuscarPromotores(pPromotore);

            BDComun.Contexto.Promotores.Remove(tmpPromotores);
            return BDComun.Contexto.SaveChanges();
        }

        public List<Promotore> ObtenerPromotores()
        {
            return BDComun.Contexto.Promotores.ToList();
        }

        public List<Promotore> ObtenerPromotoresPorNombre(Promotore pPromotore)
        {
            return BDComun.Contexto.Promotores.Where(c => c.Nombre.Contains(pPromotore.Nombre)).ToList();
        }

        public List<ReportePromotor> ObtenerPromotoresPorNombres()
        {
            return BDComun.Contexto.ReportePromotors.ToList();
        }

        public List<ReportePromotor> ObtenerPromotoresPorNombres(ReportePromotor pPromotore)
        {
            return BDComun.Contexto.ReportePromotors.ToList();



        }

        public List<ReportePromotor> ObtenerPromotoresPorFechasDeActividades(ReportePromotor pPromotore)
        {
            return BDComun.Contexto.ReportePromotors.Where(c => c.Fecha_Actividad == pPromotore.Fecha_Actividad).ToList();

        }
            

    }
}

   
