using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Playground.Config
{
    public class ConfigUtils
    {
        public static void Run()
        {
            var secret = ReadFromJsonFile<AuthenticationConfig>("resources/secret.json");
            Console.WriteLine(secret);
        }

        public static T ReadFromJsonFile<T>(string path)
        {
            IConfigurationRoot Configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path);

            Configuration = builder.Build();
            return Configuration.Get<T>();
        }

        public class AuthenticationConfig
        {
            /// <summary>
            /// instance of Azure AD, for example public Azure or a Sovereign cloud (Azure China, Germany, US government, etc ...)
            /// </summary>
            public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";

            /// <summary>
            /// Graph API endpoint, could be public Azure (default) or a Sovereign cloud (US government, etc ...)
            /// </summary>
            public string[] Scopes { get; set; }

            /// <summary>
            /// The Tenant is:
            /// - either the tenant ID of the Azure AD tenant in which this application is registered (a guid)
            /// or a domain name associated with the tenant
            /// - or 'organizations' (for a multi-tenant application)
            /// </summary>
            public string Tenant { get; set; }

            /// <summary>
            /// Guid used by the application to uniquely identify itself to Azure AD
            /// </summary>
            public string ClientId { get; set; }

            /// <summary>
            /// URL of the authority
            /// </summary>
            public string Authority
            {
                get { return String.Format(CultureInfo.InvariantCulture, Instance, Tenant); }
            }


            /// <summary>
            /// Client secret (application password)
            /// </summary>
            /// <remarks>Daemon applications can authenticate with AAD through two mechanisms: ClientSecret
            /// (which is a kind of application password: this property)
            /// or a certificate previously shared with AzureAD during the application registration 
            /// (and identified by the CertificateName property belows)
            /// <remarks> 
            public string ClientSecret { get; set; }

            /// <summary>
            /// Name of a certificate in the user certificate store
            /// </summary>
            /// <remarks>Daemon applications can authenticate with AAD through two mechanisms: ClientSecret
            /// (which is a kind of application password: the property above)
            /// or a certificate previously shared with AzureAD during the application registration 
            /// (and identified by this CertificateName property)
            /// <remarks> 
            public string CertificateName { get; set; }

            public override string ToString()
            {
                return $"{Tenant}, {ClientId}, {ClientSecret}";
            }
        }
    }
}