using System;
using EVP.UnitTest.AdministradorService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EVP.UnitTest
{
    [TestClass]
    public class AdministradorServiceTes
    {
        [TestMethod]
        public void Autenticar()
        {
            try
            {
                var usuarioObject = new AdministradorClient().Autenticar("12345678", "123456");
                Assert.AreEqual("Marlon", usuarioObject.Nombre);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
