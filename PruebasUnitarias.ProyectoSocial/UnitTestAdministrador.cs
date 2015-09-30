using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProyectoSocial.LogicadeNegocio;
using ProyectoSocial.AccesoADatos;

namespace PruebasUnitarias.ProyectoSocial
{
    /// <summary>
    /// Descripción resumida de UnitTestAdministrador
    /// </summary>
    [TestClass]
    public class UnitTestAdministrador
    {
        public UnitTestAdministrador()
        {
            
        }

        [TestMethod]
        public void TestAgregarAdministrador()
        {
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

        [TestMethod]
        public void TestModificarAdministrador()
        {
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

        [TestMethod]
        public void TestMostrarAdministrador()
        {
            DataConexion _conexion = new DataConexion();
            AdministradorBL _administradorbl = new AdministradorBL();
            Administradore _administrador = new Administradore();

            {
                List<Administradore> _ListaAdministrador = _administradorbl.ObtenerAdministradores();
                int expected = 0;
                int actual = _ListaAdministrador.Count;
                Assert.AreNotEqual(expected, actual);
            }

        }


        [TestMethod]
        public void TestEliminarrAdministrador()
        {
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

