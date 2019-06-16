namespace WCF_GestionarPermisoService
{
    internal class Local
    {
        public static string ClavePrivada = "1024|<RSAKeyValue><Modulus>w7RmiIXIOQGIoVcaSffNyVszOLnM/FMVYZYH2gc4nfrwVO9gt/n3QmYW7MOdXAprYVDk2v0fvgdkqRb3ayxWHOXuNboddaGffCtsNdxZxg5Ss/nOB7Tj321eJwiAxCM7XV/dIjgrlB8bqoRPk1TN/RPmmGAsahQkBnnB5IU/AYU=</Modulus><Exponent>AQAB</Exponent><P>5pP/I7s2yhWp3Ak78P67Qj/4vcmDjRKdNjS53yWy8UEMYNZkQ+S9Sw9EXafpNRDjyhHgmsR+PZuyjWMCuolE7Q==</P><Q>2Ugcdx5aPESNamoqTOabjUNY0y/8ggsMN3hiHBpfq3FfI4rwApGm89DtBdavlVCLMWhqdNBvm9ggWtoCIsbz+Q==</Q><DP>wyNtQigm7k/3OSj3ebWbdS3+rV/l3XZrZnyo8ZlOH68Vcr7+jBcBvIxnJ3v7edWZcmI+27x/ulQSgGXS4Vta4Q==</DP><DQ>z/VxsRyu1sHx66jC5alNte2AZVinP7vdLHYeyLEBYfB3U2hWAM9w0CjlwlHQ6YMWReqfAUDBoZJAnVPM+YYb2Q==</DQ><InverseQ>OH4SLnhDLLeBVkvBHBqPlxzNd7e0p/+EU6OaSm3dIzTiYTcu5wXBoBW93frUMXQJ7j98zyr7yaLOWW4vxK2UFQ==</InverseQ><D>CTvml5v6W8g4/mXZ+XH+DXlmZA+OPryb1mgqFC1BjGC1/MfzsBKVCla/T6oWL2zVbrjOp4+IcyKtqvXItE+Z+3tzILTncu6pmMvV+pPfKg2UYvAP0RuvC8a1/4+/RPEUXpcM0yWLt0fU/ozgF2Y3I4g++fHqx+OMA07jLlth3qk=</D></RSAKeyValue>";
        public static string ClavePublica = "1024|<RSAKeyValue><Modulus>w7RmiIXIOQGIoVcaSffNyVszOLnM/FMVYZYH2gc4nfrwVO9gt/n3QmYW7MOdXAprYVDk2v0fvgdkqRb3ayxWHOXuNboddaGffCtsNdxZxg5Ss/nOB7Tj321eJwiAxCM7XV/dIjgrlB8bqoRPk1TN/RPmmGAsahQkBnnB5IU/AYU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        //public static string ConnectionString_Seguridad { get { return @"Data Source= sql2019.ddns.net, 11433; DataBase=BD_Seguridad; User Id=sa; Password=123456789*"; } }
        public static string ConnectionString_Seguridad { get { return @"Data Source= amdbs01.database.windows.net; DataBase=BD_Seguridad; User Id=amdbsadmin; Password=abcDEF123"; } }
    }
}