namespace Test.Utils
{
    public abstract class EndpointsPath
    {
        private const string BASE_PATH = "https://localhost:7286/";
        private const string API_VERSION = "api/v1";
        protected const string Path = $"{BASE_PATH}{API_VERSION}";
    }

    public class EndpointAutenticacao : EndpointsPath
    {
        public const string LoginUsuario = $"{Path}/autenticacao/usuario";
        public const string LoginEmpresa = $"{Path}/autenticacao/empresa";
    }

    public class EndpointUsuario : EndpointsPath
    {
        public const string Usuario = $"{Path}/usuario";
        public const string CategoriaUsuario = $"{Usuario}/categoria/";
        public const string EmpresasUsuario = $"{Usuario}/empresas/";
    }

    public class EndpointEmpresa : EndpointsPath
    {
        private const string EMPRESA = $"{Path}/empresa";
        public const string CategoriaUsuario = $"{EMPRESA}/categoria/";
        public const string EmpresasUsuario = $"{EMPRESA}/usuarios/";
    }
}