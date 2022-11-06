using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Projet_RIO71_app
{
    public class Crypto
    { 
        //Cryptage
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }
    }
}