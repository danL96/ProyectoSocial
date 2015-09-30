using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProyectoSocial.LogicadeNegocio;
using ProyectoSocial.AccesoADatos;

namespace PruebasUnitarias.ProyectoSocial
{
    /// <summary>
    /// Descripción resumida de UnitTestADESCOS
    /// </summary>
    [TestClass]
    public class UnitTestADESCOS
    {
        [TestMethod]
        public void TestAgregarAdesco()
        {
            DataConexion _conexion = new DataConexion();
            ADESCOBL _adescobl = new ADESCOBL();
            ADESCO _adesco = new ADESCO();

            _adesco.Nombre = "ADESCOMER";
            _adesco.TipoADESCO = "Urbana";
            int expected = 1;
            int actual;
            actual = _adescobl.AgregarADESCOS(_adesco);
            Assert.AreEqual(expected, actual);

            }


		[TestMethod]
		public void TestModificarAdesco()
		{
		DataConexion _conexion = new DataConexion();
            ADESCOBL _adescobl = new ADESCOBL();
            ADESCO _adesco = new ADESCO();
			_adesco.Nombre="Adescotur";
            _adesco.TipoADESCO = "Rural";
			_adesco.Id=2;
			int expected=1;
			int actual=_adescobl.ModificarADESCOS(_adesco);
			Assert.AreEqual(expected, actual);
		}

        [TestMethod]
        public void TestMostrarAdesco()
        {
            DataConexion _conexion = new DataConexion();
            ADESCOBL _adescobl = new ADESCOBL();
            ADESCO _adesco = new ADESCO();

            {
                List<ADESCO> _ListaADESCOS = _adescobl.ObtenerADESCOS();
                int expected = 0;
                int actual = _ListaADESCOS.Count;
                Assert.AreNotEqual(expected, actual);
            }

        }
        [TestMethod]
        public void TestEliminarAdesco()
        {
            DataConexion _conexion = new DataConexion();
            ADESCOBL _adescobl = new ADESCOBL();


            {
                ADESCO _adesco = new ADESCO();
                _adesco.Id = 8;
                int expected = 1;
                int actual = _adescobl.EliminarADESCOS(_adesco);
                Assert.AreEqual(actual,expected);


            }
        }


        }
             

        
    }

    

