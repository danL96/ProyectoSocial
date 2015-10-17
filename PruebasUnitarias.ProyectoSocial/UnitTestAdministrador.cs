using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoSocial.LogicadeNegocio;
using ProyectoSocial.AccesoADatos;

namespace PruebasUnitarias.ProyectoSocial
{
    [TestClass]
    public class UnitTestAdministrador
    {
        //Todo: moquear estos tests

        [TestMethod]
        public void TestAgregarAdministrador()
        {
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

        [TestMethod]
        public void TestModificarAdministrador()
        {
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

        [TestMethod]
        public void TestMostrarAdministrador()
        {
            const int expected = 0;

            var adminBl = new AdministradorBl();
            var actual = adminBl.ObtenerTodos().Count();

            Assert.AreNotEqual(expected, actual);

        }


        [TestMethod]
        public void TestEliminarrAdministrador()
        {
            const int expected = 1;

            var adminBl = new AdministradorBl();
            var actual = adminBl.Eliminar(new Administradore { Id = 1 });

            Assert.AreEqual(actual, expected);
        }

    }
}

