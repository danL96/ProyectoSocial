using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
    public class AdministradorBL
    {
        public int AgregarAdministradores(Administradore pAdministradore)
        {
            BDComun.Contexto.Administradores.Add(pAdministradore);

            return BDComun.Contexto.SaveChanges();
        }

        public Administradore BuscarAdministradores(Administradore pAdministradore)
        {
            return BDComun.Contexto.Administradores.SingleOrDefault(c => c.Id == pAdministradore.Id);
        }

        public int ModificarAdministradores(Administradore pAdministradore)
        {
            Administradore tmpAdministradores = BuscarAdministradores(pAdministradore);
            tmpAdministradores.Id = pAdministradore.Id;
            tmpAdministradores.Nombre = pAdministradore.Nombre;
            tmpAdministradores.Apellido = pAdministradore.Apellido;
            tmpAdministradores.Nick = pAdministradore.Nick;
            tmpAdministradores.Pass = pAdministradore.Pass;
            tmpAdministradores.Confirmar = pAdministradore.Confirmar;

            return BDComun.Contexto.SaveChanges();
        }

        public int EliminarAdministradores(Administradore pAdministradore)
        {
            Administradore tmpAdministradores = BuscarAdministradores(pAdministradore);

            BDComun.Contexto.Administradores.Remove(tmpAdministradores);
            return BDComun.Contexto.SaveChanges();
        }

        public List<Administradore> ObtenerAdministradores()
        {
            return BDComun.Contexto.Administradores.ToList();
        }

        public List<Administradore> ObtenerAdministradoresPorNombre(Administradore pAdministradore)
        {
            return BDComun.Contexto.Administradores.Where(c => c.Nombre.Contains(pAdministradore.Nombre)).ToList();
        }
        public bool ValidarAcceso(Administradore pAdministrador)
        {
            bool Aceptado = false;
            string claveBD = "";

            var usuario = BDComun.Contexto.Administradores.SingleOrDefault(u => u.Nick == pAdministrador.Nick);

            if (usuario != null)
            {
                claveBD = usuario.Pass;

                if (Utilidades.ValidarClave(pAdministrador.Pass, claveBD))
                    Aceptado = true;
                else
                    Aceptado = false;
            }
            else
                Aceptado = false;

            return Aceptado;
        }
    }
}
