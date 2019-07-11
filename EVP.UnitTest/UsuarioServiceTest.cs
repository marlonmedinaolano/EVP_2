using EVP.UnitTest.Dominio;
using EVP.UnitTest.Errores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace EVP.UnitTest
{
    [TestClass]
    public class UsuarioServiceTest
    {
        UsuarioDOM instUsuarioDOM = new UsuarioDOM()
        {
            Nombre = "Marlon 3",
            Apellidos = "Medina 3",
            Celular = "123456789",
            Contrasenia = "123",
            Direccion = "LIMA PERÚ",
            NumDocumento = "987765412",
            Tipo = "D"
        };

        [TestMethod]
        public void CreacionUsuario()
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string postdata = js.Serialize(instUsuarioDOM);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario");
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                var UsuarioRetorno = js.Deserialize<UsuarioDOM>(tramaJson);

                if (UsuarioRetorno != null)
                {
                    Assert.AreEqual("Marlon 3", UsuarioRetorno.Nombre);
                    Assert.AreEqual("Medina 3", UsuarioRetorno.Apellidos);
                }

            }
            catch (WebException e)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpStatusCode codigo = ((HttpWebResponse)e.Response).StatusCode;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                var error = js.Deserialize<RepetidoException>(tramaJson);
                Assert.AreEqual("101", error.Codigo);
                Assert.AreEqual("El Número documento ya existe", error.Descripcion);
            }


        }

        [TestMethod]
        public void CreacionUsuarioDuplicado()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(instUsuarioDOM);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                var UsuarioRetorno = js.Deserialize<UsuarioDOM>(tramaJson);
                Assert.AreEqual("Marlon 3", UsuarioRetorno.Nombre);
                Assert.AreEqual("Medina 3", UsuarioRetorno.Apellidos);
            }
            catch (WebException e)
            {
                HttpStatusCode codigo = ((HttpWebResponse)e.Response).StatusCode;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                var error = js.Deserialize<RepetidoException>(tramaJson);
                Assert.AreEqual("101", error.Codigo);
                Assert.AreEqual("El Número documento ya existe", error.Descripcion);
            }


        }

        [TestMethod]
        public void ObtenerUsuario()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sharedcss.com/evp/application/UsuarioService/Usuario.svc/Usuario/12345678");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var UsuarioRetorno = js.Deserialize<UsuarioDOM>(tramaJson);

            Assert.AreEqual("Marlon", UsuarioRetorno.Nombre);
            Assert.AreEqual("Medina", UsuarioRetorno.Apellidos);
        }
    }
}
