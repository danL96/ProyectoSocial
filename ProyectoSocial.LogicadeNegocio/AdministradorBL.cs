<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

=======
﻿using System.Collections.Generic;
using System.Linq;
>>>>>>> Modificaciones-Pablo
using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
<<<<<<< HEAD
    public class AdministradorBL
    {
        public int AgregarAdministradores(Administradore pAdministradore)
        {
            BDComun.Contexto.Administradores.Add(pAdministradore);
=======
    public interface IAdministradorBl
    {
        int Agregar(Administradore administrador);
        int Modificar(Administradore administrador);
        int Eliminar(Administradore administrador);
        Administradore ObtenerAdministradorPorId(long id);
        IEnumerable<Administradore> ObtenerAdministradoresPorNombre(string nombre);
        IEnumerable<Administradore> ObtenerTodos();
        bool ValidarAcceso(string userName, string password);
    }

    public class AdministradorBl : IAdministradorBl
    {
        public int Agregar(Administradore administrador)
        {
            BDComun.Contexto.Administradores.Add(administrador);
>>>>>>> Modificaciones-Pablo

            return BDComun.Contexto.SaveChanges();
        }

<<<<<<< HEAD
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
=======
        public int Modificar(Administradore administrador)
        {
            var admin = ObtenerAdministradorPorId(administrador.Id);
            admin.Nombre = administrador.Nombre;
            admin.Apellido = administrador.Apellido;
            admin.Nick = administrador.Nick;
            admin.Pass = administrador.Pass;
            admin.Confirmar = administrador.Confirmar;

            return BDComun.Contexto.SaveChanges();
        }

        public int Eliminar(Administradore administrador)
        {
            var admin = ObtenerAdministradorPorId(administrador.Id);

            BDComun.Contexto.Administradores.Remove(admin);
            return BDComun.Contexto.SaveChanges();
        }

        public Administradore ObtenerAdministradorPorId(long id)
        {
            return ObtenerTodos().FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Administradore> ObtenerAdministradoresPorNombre(string nombre)
        {
            return ObtenerTodos().Where(c => c.Nombre.Contains(nombre)).ToList();
        }

        public IEnumerable<Administradore> ObtenerTodos()
        {
            return BDComun.Contexto.Administradores.ToList();
        }

        public bool ValidarAcceso(string userName, string password)
        {
            var usuario = ObtenerTodos().FirstOrDefault(u => u.Nick == userName);

            if (usuario == null) return false;

            var pse = new ProyectoSocialEncrypter();

            var decryptedPassword = pse.DecryptString(usuario.Pass);

            return password == decryptedPassword;
>>>>>>> Modificaciones-Pablo
        }
    }
}
