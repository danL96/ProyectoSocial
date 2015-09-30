using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSocial.AccesoADatos
{
   public class BDComun
    {
       private static BDProyeccionSocialEntities _contexto;
       

        public static BDProyeccionSocialEntities Contexto
        {
            get
            {
                if (_contexto == null)
                {
                    _contexto = new BDProyeccionSocialEntities();
                }

                return _contexto;
            }
        }
    }
}
