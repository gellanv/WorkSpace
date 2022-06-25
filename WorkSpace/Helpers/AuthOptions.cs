using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WorkSpace.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "WorkSpaceServer"; // издатель токена
        public const string AUDIENCE = "WorkSpaceClient"; // потребитель токена
        const string KEY = "diploma_super_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 10; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}