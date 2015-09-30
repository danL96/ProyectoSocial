using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;


namespace ProyectoSocial.LogicadeNegocio
{
   public class PromotorZonaBL
    {
        public int AgregaPromotoresZona(PromotorZona pPromotorZona)
        {
            BDComun.Contexto.PromotorZonas.Add(pPromotorZona);

            return BDComun.Contexto.SaveChanges();
        }

        public PromotorZona BuscarPromotoresZona(PromotorZona pPromotorZona)
        {
            return BDComun.Contexto.PromotorZonas.SingleOrDefault(c => c.Id == pPromotorZona.Id);
        }

        public int ModificarPromotoresZona(PromotorZona pPromotorZona)
        {
            PromotorZona tmpPromotorZona = BuscarPromotoresZona(pPromotorZona);
            tmpPromotorZona.Id = pPromotorZona.Id;
            tmpPromotorZona.Actividade = pPromotorZona.Actividade;
            tmpPromotorZona.ADESCO = pPromotorZona.ADESCO;
            tmpPromotorZona.Promotore = pPromotorZona.Promotore;
            tmpPromotorZona.Proyecto = pPromotorZona.Proyecto;
            tmpPromotorZona.Zona = pPromotorZona.Zona;


            return BDComun.Contexto.SaveChanges();
        }

        public int EliminarPromotoresZona(PromotorZona pPromotorZona)
        {
            PromotorZona tmpPromotorZona = BuscarPromotoresZona(pPromotorZona);

            BDComun.Contexto.PromotorZonas.Remove(tmpPromotorZona);
            return BDComun.Contexto.SaveChanges();
        }

        public List<PromotorZona> ObtenerPromotoresZona()
        {
            return BDComun.Contexto.PromotorZonas.ToList();
        }

        public List<PromotorZona> ObtenerPromotoresZonaPorNombre(PromotorZona pPromotorZona)
        {
            return BDComun.Contexto.PromotorZonas.Where(p => p.Promotore.Nombre.Contains(pPromotorZona.Promotore.Nombre)).ToList();
        }
    }
}
