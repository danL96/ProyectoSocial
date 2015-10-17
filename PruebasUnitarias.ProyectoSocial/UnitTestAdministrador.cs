<<<<<<< HEAD
﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

=======
﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
>>>>>>> Modificaciones-Pablo
using ProyectoSocial.LogicadeNegocio;
using ProyectoSocial.AccesoADatos;

namespace PruebasUnitarias.ProyectoSocial
{
<<<<<<< HEAD
    /// <summary>
    /// Descripción resumida de UnitTestAdministrador
    /// </summary>
    [TestClass]
    public class UnitTestAdministrador
    {
        public UnitTestAdministrador()
        {
            
        }
=======
    [TestClass]
    public class UnitTestAdministrador
    {
        //Todo: moquear estos tests
>>>>>>> Modificaciones-Pablo

        [TestMethod]
        public void TestAgregarAdministrador()
        {
<<<<<<< HEAD
            DataConexion _conexion = new DataConexion();
            AdministradorBL _administradorbl = new AdministradorBL();
            Administradore _administrador = new Administradore();

            _administrador.Nombre = "Papaya";
            _administrador.Apellido = "Papa";
            _administrador.Nick = "Pepo";
            _administrador.Pass = "Zapato";
            int expected = 1;
            int actual;
            actual = _administradorbl.AgregarAdministradores(_administrador);
            Assert.AreEqual(expected, actual);
               
              }
=======
            const int expected = 1;

            var administrador = new Administradore
            {
                Nombre = "Papaya",
                Apellido = "Papa",
                Nick = "Pepo",
                Pass = "Zapato"
            };

            var adminBl = new AdministradorBl();
            var actual = adminBl.Agregar(administrador);

            Assert.AreEqual(expected, actual);

        }
>>>>>>> Modificaciones-Pablo

        [TestMethod]
        public void TestModificarAdministrador()
        {
<<<<<<< HEAD
            DataConexion _conexion = new DataConexion();
            AdministradorBL _administradorbl = new AdministradorBL();
            Administradore _administrador = new Administradore();

            _administrador.Nombre = "Patata";
            _administrador.Apellido = "Popa";
            _administrador.Nick = "Pipo";
            _administrador.Pass = "Zeno";
            _administrador.Id = 1;
            int expected = 1;
            int actual;
            actual = _administradorbl.ModificarAdministradores(_administrador);
            Assert.AreEqual(expected, actual);
               
             }
=======
            const int expected = 1;

            var administrador = new Administradore
            {
                Nombre = "Patata",
                Apellido = "Popa",
                Nick = "Pipo",
                Pass = "Zeno",
                Id = 1
            };

            var adminBl = new AdministradorBl();
            var actual = adminBl.Modificar(administrador);

            Assert.AreEqual(expected, actual);

        }
>>>>>>> Modificaciones-Pablo

        [TestMethod]
        public void TestMostrarAdministrador()
        {
<<<<<<< HEAD
            DataConexion _conexion = new DataConexion();
            AdministradorBL _administradorbl = new AdministradorBL();
            Administradore _administrador = new Administradore();

            {
                List<Administradore> _ListaAdministrador = _administradorbl.ObtenerAdministradores();
                int expected = 0;
                int actual = _ListaAdministrador.Count;
                Assert.AreNotEqual(expected, actual);
            }
=======
            const int expected = 0;

            var adminBl = new AdministradorBl();
            var actual = adminBl.ObtenerTodos().Count();

            Assert.AreNotEqual(expected, actual);
>>>>>>> Modificaciones-Pablo

        }


        [TestMethod]
        public void TestEliminarrAdministrador()
        {
<<<<<<< HEAD
            DataConexion _conexion = new DataConexion();
            AdministradorBL _administradorbl = new AdministradorBL();


            {
                Administradore _administrador = new Administradore();
                _administrador.Id = 1;
                int expected = 1;
                int actual = _administradorbl.EliminarAdministradores(_administrador);
                Assert.AreEqual(actual, expected);

            }
        }

        

        }
    }
=======
            const int expected = 1;

            var adminBl = new AdministradorBl();
            var actual = adminBl.Eliminar(new Administradore { Id = 1 });

            Assert.AreEqual(actual, expected);
        }

    }
}
>>>>>>> Modificaciones-Pablo

