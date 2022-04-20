using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

namespace Webapi.Config
{
    public class JwtVerifier
    {
        public static Action<JwtBearerOptions> ConfigureOptions()
        {
            return (JwtBearerOptions options) =>
            {
                options.Authority = "https://login.microsoftonline.com/4d94074b-32c4-4a70-949c-c7bd7ff7af89";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudiences = new []
                    {
                        "api://be9d7a2b-167f-4cdd-931e-56f0a7c7c5fb",
                    },
                };

                options.SaveToken = true;

                // options.Events = new JwtBearerEvents
                // {
                //     OnTokenValidated = context =>
                //     {
                //         context.HttpContext.Items.Add("Auth", "Token");
                //         return Task.CompletedTask;
                //     },
                // };
            };
        }
    }
}