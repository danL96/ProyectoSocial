using System.Collections.Generic;
using System.Linq;
using ProyectoSocial.AccesoADatos;

namespace ProyectoSocial.LogicadeNegocio
{
    public interface IAdministradorBl
    {
        int Agregar(Administradore administrador);
        int Modificar(Administradore administrador);
        int Eliminar(Administradore administrador);
        Administradore ObtenerAdministradorPorId(long id);
        IEnumerable<Administradore> ObtenerAdministradoresPorNombre(string nombre);
        IEnumerable<Administradore> ObtenerTodos();
        bool ValidarAcceso(Administradore administrador);
    }

    public class AdministradorBl : IAdministradorBl
    {
        public int Agregar(Administradore administrador)
        {
            BDComun.Contexto.Administradores.Add(administrador);

            return BDComun.Contexto.SaveChanges();
        }

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

        public bool ValidarAcceso(Administradore administrador)
        {
            var usuario = ObtenerTodos().FirstOrDefault(u => u.Nick == administrador.Nick);

            return usuario != null && Utilidades.ValidarClave(administrador.Pass, usuario.Pass);
        }
    }
}
