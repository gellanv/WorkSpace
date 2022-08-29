using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WorkSpace.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "https://localhost:44347/"; // издатель токена
        public const string AUDIENCE = "https://localhost"; // потребитель токена
        const string KEY = "diploma_super_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 600; // время жизни токена
        public const string ClientID = "824867412701-fgqpga536giig7p9uto5n7175q6d1195.apps.googleusercontent.com";
        //"824867412701-beluc82045n0hcko7pc1vp78mapd3fkm.apps.googleusercontent.com";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}