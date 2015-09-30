using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
    public class MiembrosADESCOSBL
    {
        public int AgregarMiembrosADESCOS(MiembrosADESCO pMiembrosADESCO)
        {
            BDComun.Contexto.MiembrosADESCOes.Add(pMiembrosADESCO);

            return BDComun.Contexto.SaveChanges();
        }

        public MiembrosADESCO BuscarMiembrosADESCOS(MiembrosADESCO pMiembrosADESCO)
        {
            return BDComun.Contexto.MiembrosADESCOes.SingleOrDefault(c => c.Id == pMiembrosADESCO.Id);
        }

        public int ModificarMiembrosADESCOS(MiembrosADESCO pMiembrosADESCO)
        {
            MiembrosADESCO tmpMiembrosADESCOS = BuscarMiembrosADESCOS(pMiembrosADESCO);
            tmpMiembrosADESCOS.Id = pMiembrosADESCO.Id;
            tmpMiembrosADESCOS.Nombre = pMiembrosADESCO.Nombre;
            tmpMiembrosADESCOS.Cargo = pMiembrosADESCO.Cargo;

            return BDComun.Contexto.SaveChanges();
        }

        public int EliminarMiembrosADESCOS(MiembrosADESCO pMiembrosADESCO)
        {
            MiembrosADESCO tmpMiembrosADESCOS = BuscarMiembrosADESCOS(pMiembrosADESCO);

            BDComun.Contexto.MiembrosADESCOes.Remove(tmpMiembrosADESCOS);
            return BDComun.Contexto.SaveChanges();
        }

        public List<MiembrosADESCO> ObtenerMiembrosADESCOS()
        {
            return BDComun.Contexto.MiembrosADESCOes.ToList();
        }

        public List<MiembrosADESCO> ObtenerMiembrosADESCOSPorNombre(MiembrosADESCO pMiembrosADESCO)
        {
            return BDComun.Contexto.MiembrosADESCOes.Where(c => c.Nombre.Contains(pMiembrosADESCO.Nombre)).ToList();
        }
    }
}
