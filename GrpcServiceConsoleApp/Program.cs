using System;
using Grpc.Core;
using GrpcService.Protos;
using GrpcServiceConsoleApp.Services;

namespace GrpcServiceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var server = new Server
            {
                Services =
                {
                    User.BindService(new UserService())
                },
                Ports =
                {
                    // C-core benchmarks currently only support insecure (h2c)
                    { "0.0.0.0", 6003, ServerCredentials.Insecure }
                }

            };
            server.Start();

            Console.WriteLine("Started!");
            Console.ReadKey();
        }
    }
}
