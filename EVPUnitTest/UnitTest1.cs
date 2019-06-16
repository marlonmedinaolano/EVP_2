using System;
using System.ServiceModel;
using EVPUnitTest.AdministradorService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EVPUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                 var instChartLocal = new AdministradorService.AdministradorClient().Autenticar("12345676", "123456");

                if (instChartLocal != null)
                {
                    Assert.AreEqual("Marlon", instChartLocal.Nombre);
                    Assert.AreEqual("Medina", instChartLocal.Apellidos);
                }

            }
            catch (FaultException<RepetidoException> error)
            {
                Assert.AreEqual("NroDocumento no existe", error.Detail.Descripcion);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                var instChartLocal = new AdministradorService.AdministradorClient().Autenticar("12345678", "00000");

                if (instChartLocal != null)
                {
                    Assert.AreEqual("Marlon", instChartLocal.Nombre);
                    Assert.AreEqual("Medina", instChartLocal.Apellidos);
                }

            }
            catch (FaultException<RepetidoException> error)
            {
                Assert.AreEqual("Contraseña no es correcta", error.Detail.Descripcion);
            }
        }
    }
}
