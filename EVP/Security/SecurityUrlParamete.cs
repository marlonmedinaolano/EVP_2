using System.Linq;
using System.Web;

namespace EVP.Security
{
    public static class SecurityUrlParamete
    {
        public static string GetUrlParameter(this HttpRequestBase request, string parName)
        {
            string result = string.Empty; 
            var urlParameters = HttpUtility.ParseQueryString(request.Url.Query);
            if (urlParameters.AllKeys.Contains(parName))
            {
                result = urlParameters.Get(parName);
            }

            return result;
        }
    }
}