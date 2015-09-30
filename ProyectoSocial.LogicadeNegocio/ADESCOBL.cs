using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
    public class ADESCOBL
    {
        public int AgregarADESCOS(AccesoADatos.ADESCO pADESCO)
        {
            BDComun.Contexto.ADESCOS.Add(pADESCO);

            return BDComun.Contexto.SaveChanges();
        }

        public ADESCO BuscarADESCOS(ADESCO pADESCO)
        {
            return BDComun.Contexto.ADESCOS.SingleOrDefault(c => c.Id == pADESCO.Id);
        }

        public int ModificarADESCOS(ADESCO pADESCO)
        {
            ADESCO tmpADESCOS = BuscarADESCOS(pADESCO);
            tmpADESCOS.Id = pADESCO.Id;
            tmpADESCOS.Nombre = pADESCO.Nombre;
            tmpADESCOS.TipoADESCO = pADESCO.TipoADESCO;

            return BDComun.Contexto.SaveChanges();
        }

        public int EliminarADESCOS(ADESCO pADESCOS)
        {
            ADESCO tmpADESCOS = BuscarADESCOS(pADESCOS);

            BDComun.Contexto.ADESCOS.Remove(tmpADESCOS);
            return BDComun.Contexto.SaveChanges();
        }

        public List<ADESCO> ObtenerADESCOS()
        {
            return BDComun.Contexto.ADESCOS.ToList();
        }

        public List<ADESCO> ObtenerADESCOSPorNombre(ADESCO pADESCO)
        {
            return BDComun.Contexto.ADESCOS.Where(c => c.Nombre.Contains(pADESCO.Nombre)).ToList();
        }
    }
}

    

