using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Authentication.JWT.Builders
{
    public class AuthenticationBuilder
    {
        public void SetSecretKey(string value)
            => SharedSettings.SecretKey = value;
        public void SetJWTIssuer(string value)
            => SharedSettings.JWTIssuer = value;
        public void SetUserDataAccessMethod<TUserService,TDtoUser>(Func<TUserService,TDtoUser> func)
        {
            var userService = SharedSettings.ServiceProvider.GetService<TUserService>();
        }
    }
}
