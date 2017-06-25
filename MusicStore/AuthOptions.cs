using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer"; 
        public const string AUDIENCE = "http://localhost/";
        const string KEY = "sggh63458utdffgfh324effggf_secretkey!123"; 
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
