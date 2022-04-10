using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Authentication.JWT
{
    internal class SharedSettings : Lib.Core.Web.SharedSettings
    {
        public static string SecretKey { get; set; } = "";
        public static string JWTIssuer { get; set; } = "";
        
    }
}
