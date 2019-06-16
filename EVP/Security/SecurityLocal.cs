/*******************************************************
'* CREADO POR: COMPUTER SYSTEMS SOLUTION
'*			   Cristian Hernandez Villo
'* FECHA CREA: 19/12/2018
********************************************************/

namespace EVP.Security
{
    using EVP.AdministradorService;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;

    public class SecurityLocal
    { 
        public static AdministradorDOM Usuario
        {
            get
            {
                try
                {
                    var inst = System.Web.HttpContext.Current.Session["SessionUsuario"];
                    if (inst == null)
                    {
                        HttpContext.Current.Response.StatusCode = 401;
                        return new AdministradorDOM() { IdAdministrador = -1 };
                    }
                    else
                        return System.Web.HttpContext.Current.Session["SessionUsuario"] as AdministradorDOM;
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
