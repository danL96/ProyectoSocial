using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProyectoSocial.LogicadeNegocio;
using ProyectoSocial.AccesoADatos;

namespace PruebasUnitarias.ProyectoSocial
{
    /// <summary>
    /// Descripción resumida de UnitTestActividad
    /// </summary>
    [TestClass]
    public class UnitTestActividad
    {
      
        [TestMethod]
        public void TestAgregarActividad()
        {
            DataConexion _conexion = new DataConexion();
            ActividadBL _actividadbl = new ActividadBL();
            Actividade _actividad = new Actividade();

            _actividad.Nombre = "Reuniones";
            _actividad.Tipo = "Sociales";
            _actividad.Fecha = "12/09/14";
            int expected = 1;
            int actual;
            actual = _actividadbl.AgregarActividades(_actividad);
            Assert.AreEqual(expected, actual);

             }


        [TestMethod]
        public void TestModificarActividad()
        {
            DataConexion _conexion = new DataConexion();
            ActividadBL _actividadbl = new ActividadBL();
            Actividade _actividad = new Actividade();
            _actividad.Nombre = "Reunione";
            _actividad.Tipo = "Social";
            _actividad.Fecha = "09/09/14";
            _actividad.Id = 1;
            int expected = 1;
            int actual;
            actual = _actividadbl.ModificarActividades(_actividad);
            Assert.AreEqual(expected, actual);

            }

        [TestMethod]
        public void TestMostrarActividad()
        {
            DataConexion _conexion = new DataConexion();
            ActividadBL _actividadbl = new ActividadBL();
            Actividade _actividad = new Actividade();

             {
                List<Actividade> _ListaActividade = _actividadbl.ObtenerActividades();
                int expected = 0;
                int actual = _ListaActividade.Count;
                Assert.AreNotEqual(expected, actual);
            }

        }

        [TestMethod]
        public void TestEliminarActividad()
        {
            DataConexion _conexion = new DataConexion();
            ActividadBL _actividadbl = new ActividadBL();

            {

                Actividade _actividad = new Actividade();
                _actividad.Id = 4;
                int expected = 1;
                int actual;
                actual = _actividadbl.EliminarActividades(_actividad);
                Assert.AreEqual(expected, actual);


            }




        }

            
        }
    }

