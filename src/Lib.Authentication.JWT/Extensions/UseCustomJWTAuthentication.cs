using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

#if NET5_0_OR_GREATER
using Microsoft.AspNetCore.Builder;

#endif

public static partial class Extensions
{
    public static void UseCustomJWTAuthentication<TUser>(this IServiceCollection @this,Action<Lib.Authentication.JWT.Builders.AuthenticationBuilder> builder)
    {
        builder.Invoke(new Lib.Authentication.JWT.Builders.AuthenticationBuilder());

        @this.AddSession();
        @this.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = Lib.Authentication.JWT.SharedSettings.JWTIssuer,
               ValidAudience = Lib.Authentication.JWT.SharedSettings.JWTIssuer,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Lib.Authentication.JWT.SharedSettings.SecretKey)),
               ClockSkew = TimeSpan.Zero
           };
       });
    }

#if NETCOREAPP3_1 || NET5_0
    public static void UseCustomJWTAuthentication<TUser>(this IApplicationBuilder @this)
    {
        @this.UseSession();
        @this.Use(async (context, next) =>
        {
            var JWToken = context.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(JWToken))
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                    context.Request.Headers["Authorization"] = "Bearer " + JWToken;
                else
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
            }
            else
            {
            }
            await next();
        });
        @this.UseMiddleware<Lib.Authentication.JWT.Middlewares.JWTMiddleware<TUser>>();
        @this.UseAuthentication();
    }
#endif

#if NET6_0
 public static void UseCustomJWTAuthentication<TUser>(this IApplicationBuilder @this)
    {
        @this.UseSession();
        @this.Use(async (context, next) =>
        {
            var JWToken = context.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(JWToken))
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                    context.Request.Headers["Authorization"] = "Bearer " + JWToken;
                else
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
            }
            else
            {
            }
            await next();
        });
        @this.UseMiddleware<Lib.Authentication.JWT.Middlewares.JWTMiddleware<TUser>>();
        @this.UseAuthentication();
    }
#endif



}
