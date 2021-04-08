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
                // options.Authority = "https://sts.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // ValidIssuers = OspAadConstant.ValidTenants.Select(id => OspAadConstant.AADIssuer + $"{id.Value}/"),
                    ValidAudiences = new []
                    {
                        // "api://be9d7a2b-167f-4cdd-931e-56f0a7c7c5fb",
                        // "api://be9d7a2b-167f-4cdd-931e-56f0a7c7c5fb/api",
                        "api://20984d37-5817-4498-8f0b-73287c5fc974",
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