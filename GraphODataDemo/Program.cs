using System;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace GraphODataDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var confidentialClientApplication = ConfidentialClientApplicationBuilder
               .Create("YOUR_CLIENT_ID")
               .WithTenantId("YOUR_TENANT_ID")
               .WithClientSecret("YOUR_APP_SECRET")
               .Build();

            var clientCredentialProvider = 
                new ClientCredentialProvider(confidentialClientApplication);
            
            var graphServiceClient = 
                new GraphServiceClient(clientCredentialProvider);

            var users = await graphServiceClient.Users.Request().Filter("displayName eq 'Hassan Habib'").GetAsync();

            foreach(var user in users)
            {
                Console.WriteLine(user.DisplayName);
            }
        }
    }
}
