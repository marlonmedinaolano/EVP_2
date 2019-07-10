/*******************************************************
'* CREADO POR: COMPUTER SYSTEMS SOLUTION
'*			   Cristian Hernandez Villo
'* FECHA CREA: 19/12/2018
********************************************************/

namespace EVP.Security
{
    using EVP.Dominio;
    using System;
    using System.Web;

    public class SecurityLocal
    { 
        public static object Usuario
        {
            get
            {
                try
                {
                    var inst = System.Web.HttpContext.Current.Session["SessionUsuario"];
                    if (inst == null)
                    {
                        HttpContext.Current.Response.StatusCode = 401;
                        return null;
                    }
                    else
                        return System.Web.HttpContext.Current.Session["SessionUsuario"] ;
                }
                catch (Exception)
                {
                    HttpContext.Current.Response.StatusCode = 401;
                    throw;
                }
            }
        }
         
        public static bool IsAuthenticated
        {
            get
            {
                return Convert.ToBoolean(System.Web.HttpContext.Current.Session["SessionIsAuthenticated"] ?? false);
            }
        }
         
        public static void SignOut()
        {
            HttpContext.Current.Session["SessionUsuario"] = null;
            HttpContext.Current.Session["SessionIsAuthenticated"] = false;
        }
    }
}
