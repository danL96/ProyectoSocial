using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProyectoSocial.LogicadeNegocio;
using ProyectoSocial.AccesoADatos;

namespace PruebasUnitarias.ProyectoSocial
{
    /// <summary>
    /// Descripción resumida de UnitTestMiembrosAdescos
    /// </summary>
    [TestClass]
    public class UnitTestMiembrosAdescos
    {
       
        [TestMethod]
        public void TestAgregarMiembrosdeAdescos()
        {
            DataConexion _conexion = new DataConexion();
            MiembrosADESCOSBL _miembrosadescosbl = new MiembrosADESCOSBL();
            MiembrosADESCO _miembrosdeadescos = new MiembrosADESCO();

            _miembrosdeadescos.Nombre = "Juan Manuel";
            _miembrosdeadescos.Apellido = "Marquez Valdez";
            _miembrosdeadescos.Cargo = "Presidente";
            int expected = 1;
            int actual;
            actual = _miembrosadescosbl.AgregarMiembrosADESCOS(_miembrosdeadescos);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestModificarMiembrosdeAdescos()
        {
            DataConexion _conexion = new DataConexion();
            MiembrosADESCOSBL _miembrosadescosbl = new MiembrosADESCOSBL();
            MiembrosADESCO _miembrosdeadescos = new MiembrosADESCO();

            _miembrosdeadescos.Nombre = "Marcos";
            _miembrosdeadescos.Apellido = "Avelar";
            _miembrosdeadescos.Cargo = "Vocal";
            _miembrosdeadescos.Id = 1;
            int expected = 1;
            int actual; 
            actual = _miembrosadescosbl.ModificarMiembrosADESCOS(_miembrosdeadescos);
            Assert.AreEqual(expected, actual);


            }

        [TestMethod]
        public void TestMostrarMiembrosdeAdescos()
        {
            DataConexion _conexion = new DataConexion();
            MiembrosADESCOSBL _miembrosadescosbl = new MiembrosADESCOSBL();
            MiembrosADESCO _miembrosdeadescos = new MiembrosADESCO();

            {
                List<MiembrosADESCO> _ListaMiembrodeadesco = _miembrosadescosbl.ObtenerMiembrosADESCOS();
                int expected = 0;
                int actual = _ListaMiembrodeadesco.Count;
                Assert.AreNotEqual(expected, actual);

            }

        }

        [TestMethod]
        public void TestEliminarMiembrosadesco()
        {
            DataConexion _conexion = new DataConexion();
            MiembrosADESCOSBL _miembrosadescosbl = new MiembrosADESCOSBL();

            {
                MiembrosADESCO _miembrosdeadescos = new MiembrosADESCO();
                _miembrosdeadescos.Id = 1;
                int expected = 1;
                int actual;
                actual = _miembrosadescosbl.EliminarMiembrosADESCOS(_miembrosdeadescos);
                Assert.AreEqual(expected, actual);

            }

        }
                 

        

        }
    }

