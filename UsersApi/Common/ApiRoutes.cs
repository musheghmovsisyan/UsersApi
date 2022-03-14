namespace UsersApi.Common;

public static class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class AuthorizationApi
    {
        public const string Login = Base + "/Authorization/login";
    }

    public static class UserApi
    {
        public const string Add = Base + "/User/Add";
        public const string Get = Base + "/User/Get";
        public const string Update = Base + "/User/Update";
        public const string Delete = Base + "/User/Delete";
        public const string GetUsers = Base + "/Client/GetUsers";
    }
}