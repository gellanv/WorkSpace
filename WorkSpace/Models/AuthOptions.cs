using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSpace.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "ISSUER"; //"http://localhost:49146" издатель токена
        public const string AUDIENCE = "AUDIENCE"; //"https://d7w55.csb.app" потребитель токена
        const string KEY = "SecretKey10325779374235322"; // ключ для шифрации
        public const int LIFETIME = 100; // время жизни токена - 5 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
