using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using TXC.Proto.Tenant;

namespace ProtoTester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:9090");
            var client = new TenantConfig.TenantConfigClient(channel);
            
            var tenantConfig = await GetTenantConfig(client);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static async Task<object> GetTenantConfig(TenantConfig.TenantConfigClient client)
        {
            var request = new GetTenantConfigRequest
            {
                TenantId = 7,
            };

            var reply = await client.GetTenantConfigAsync(request);

            return reply.Data;
        }
    }
}
