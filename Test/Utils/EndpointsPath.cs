namespace Test.Utils
{
    public abstract class EndpointsPath
    {
        protected const string BASE_PATH = "https://localhost:7286/";
        protected const string API_VERSION = "api/v1";
        protected const string PATH = $"{BASE_PATH}{API_VERSION}";
}

    public class EndpointAutenticacao : EndpointsPath
    {
        public const string LOGIN_USUARIO = $"{PATH}/autenticacao/usuario";
        public const string LOGIN_EMPRESA = $"{PATH}/autenticacao/empresa";
    }

    public class EndpointUsuario : EndpointsPath
    {
        public const string USUARIO = $"{PATH}/usuario";
        public const string CATEGORIA_USUARIO = $"{USUARIO}/categoria/";
        public const string EMPRESAS_USUARIO = $"{USUARIO}/empresas/";
    }

    public class EndpointEmpresa : EndpointsPath
    {
        public const string EMPRESA = $"{PATH}/empresa";
        public const string CATEGORIA_USUARIO = $"{EMPRESA}/categoria/";
        public const string EMPRESAS_USUARIO = $"{EMPRESA}/usuarios/";
    }

}