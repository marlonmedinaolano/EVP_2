using System;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsuarioServiceUnitTest.UsuarioService;

namespace UsuarioServiceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var inst = new UsuarioService.Service1Client().Crear(new UsuarioService.Usuario()
                {
                    Nombre = "Alumno",
                    ApeMaterno = "ApeMaterno",
                    ApePaterno = "ApePaterno",
                    Direccion = "Lima",
                    Email = "alumno@gmail.com",
                    FechaNacimiento = "25/04/2019",
                    TipoDocumento = "D",
                    NroDocumento = "12547854",
                    TipoUsuario = "A",
                    Sexo = "M",
                    Contrasenia = "123456"
                });
                if (inst != null)
                {
                    Assert.AreEqual("Alumno", inst.Nombre);
                    Assert.AreEqual("ApePaterno", inst.ApePaterno);
                }

            }
            catch (FaultException<RepetidoException> error)
            {
                Assert.AreEqual("El NroDocumento ya existe", error.Detail.Descripcion);
            }


        }
    }
}
