using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
   public class PromotorProyectoBL
    {
        public int AgregaPromotoresProyecto(PromotorProyecto pPromotorProyecto)
        {
            BDComun.Contexto.PromotorProyectoes.Add(pPromotorProyecto);

            return BDComun.Contexto.SaveChanges();
        }

        public PromotorProyecto BuscarPromotoresProyecto(PromotorProyecto pPromotorProyecto)
        {
            return BDComun.Contexto.PromotorProyectoes.SingleOrDefault(c => c.Id == pPromotorProyecto.Id);
        }

        public int ModificarPromotoresProyecto(PromotorProyecto pPromotorProyecto)
        {
            PromotorProyecto tmpPromotorProyecto = BuscarPromotoresProyecto(pPromotorProyecto);
            tmpPromotorProyecto.Id = pPromotorProyecto.Id;
            tmpPromotorProyecto.Actividade = pPromotorProyecto.Actividade;
            tmpPromotorProyecto.ADESCO = pPromotorProyecto.ADESCO;
            tmpPromotorProyecto.Promotore = pPromotorProyecto.Promotore;
            tmpPromotorProyecto.Proyecto = pPromotorProyecto.Proyecto;
            tmpPromotorProyecto.Zona = pPromotorProyecto.Zona;


            return BDComun.Contexto.SaveChanges();
        }

        public int EliminarPromotoresproyecto(PromotorProyecto pPromotorProyecto)
        {
            PromotorProyecto tmpPromotorProyecto = BuscarPromotoresProyecto(pPromotorProyecto);

            BDComun.Contexto.PromotorProyectoes.Remove(tmpPromotorProyecto);
            return BDComun.Contexto.SaveChanges();
        }

        public List<PromotorProyecto> ObtenerPromotoresProyecto()
        {
            return BDComun.Contexto.PromotorProyectoes.ToList();
        }

        public List<PromotorProyecto> ObtenerPromotoresProyectoPorNombre(PromotorProyecto pPromotorProyecto)
        {
            return BDComun.Contexto.PromotorProyectoes.Where(p => p.Promotore.Nombre.Contains(pPromotorProyecto.Promotore.Nombre)).ToList();
        }
    }
}
