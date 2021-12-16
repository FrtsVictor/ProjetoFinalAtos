namespace Test.Utils
{
    public abstract class EndpointsPath
    {
        protected const string BasePath = "https://localhost:7286/";
        protected const string ApiVersion = "api/v1";
        protected const string Path = $"{BasePath}{ApiVersion}";
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
        public const string Empresa = $"{Path}/empresa";
        public const string CategoriaUsuario = $"{Empresa}/categoria/";
        public const string EmpresasUsuario = $"{Empresa}/usuarios/";
    }
}