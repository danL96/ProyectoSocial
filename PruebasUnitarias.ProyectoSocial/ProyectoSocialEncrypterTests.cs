using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoSocial.LogicadeNegocio;

namespace PruebasUnitarias.ProyectoSocial
{
    [TestClass]
    public class ProyectoSocialEncrypterTests
    {

        [TestMethod]
        [ExpectedException(typeof(ProyectoSocialException))]
        public void DecryptString_WrongData_ThrowsException()
        {
            const string encrypted = "rtgfs+Jj8=";

            var pse = new ProyectoSocialEncrypter();
            pse.DecryptString(encrypted);

        }

        [TestMethod]
        public void TestDecryptString()
        {
            const string encrypted = "7MxiL1v+Jj8=";
            const string expected = "text";

            var actual = new ProyectoSocialEncrypter().DecryptString(encrypted);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEncryptString()
        {
            const string text = "text";
            const string expected = "7MxiL1v+Jj8=";

            var actual = new ProyectoSocialEncrypter().EncryptString(text);

            Assert.AreEqual(expected, actual);
        }
    }
}
