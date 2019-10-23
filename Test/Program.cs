using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 测试1000次调用
            var test = new Test(1000);

            #region 循环调用
            var listGrpc = new List<long>();
            await test.TestGrpc(listGrpc);

            var listGrpcSingleConnection = new List<long>();
            await test.TestGrpcSingleConnection(listGrpcSingleConnection);

            var listGrpcConsoleApp = new List<long>();
            await test.TestGrpcConsoleApp(listGrpcConsoleApp);

            var listGrpcConsoleAppSingleConnection = new List<long>();
            await test.TestGrpcConsoleAppSingleConnection(listGrpcConsoleAppSingleConnection);

            var listWebApi = new List<long>();
            await test.TestWebApi(listWebApi);

            var listWebApiSingleConnection = new List<long>();
            await test.TestWebApiSingleConnection(listWebApiSingleConnection);

            Console.WriteLine("***** TEST RESULT gRPC Grpc.AspNetCore *****");
            Console.WriteLine("min:" + listGrpc.Min());
            Console.WriteLine("max:" + listGrpc.Max());
            Console.WriteLine("avg:" + listGrpc.Average());

            Console.WriteLine("***** TEST RESULT gRPC ConsoleApp *****");
            Console.WriteLine("min:" + listGrpcConsoleApp.Min());
            Console.WriteLine("max:" + listGrpcConsoleApp.Max());
            Console.WriteLine("avg:" + listGrpcConsoleApp.Average());

            Console.WriteLine("***** TEST RESULT WebApi *****");
            Console.WriteLine("min:" + listWebApi.Min());
            Console.WriteLine("max:" + listWebApi.Max());
            Console.WriteLine("avg:" + listWebApi.Average());

            Console.WriteLine("***** TEST RESULT gRPC SingleConnection Grpc.AspNetCore *****");
            Console.WriteLine("min:" + listGrpcSingleConnection.Min());
            Console.WriteLine("max:" + listGrpcSingleConnection.Max());
            Console.WriteLine("avg:" + listGrpcSingleConnection.Average());

            Console.WriteLine("***** TEST RESULT gRPC ConsoleApp SingleConnection *****");
            Console.WriteLine("min:" + listGrpcConsoleAppSingleConnection.Min());
            Console.WriteLine("max:" + listGrpcConsoleAppSingleConnection.Max());
            Console.WriteLine("avg:" + listGrpcConsoleAppSingleConnection.Average());

            Console.WriteLine("***** TEST RESULT WebApi SingleConnection *****");
            Console.WriteLine("min:" + listWebApiSingleConnection.Min());
            Console.WriteLine("max:" + listWebApiSingleConnection.Max());
            Console.WriteLine("avg:" + listWebApiSingleConnection.Average());

            #endregion

            #region 并发调用
            var listGrpcConcurrency = new ConcurrentBag<long>();
            await test.TestGrpcConcurrency(listGrpcConcurrency);

            var listGrpcConsoleAppConcurrency = new ConcurrentBag<long>();
            await test.TestGrpcConsoleAppConcurrency(listGrpcConsoleAppConcurrency);

            var listWebApiConcurrency = new ConcurrentBag<long>();
            await test.TestWebApiConcurrency(listWebApiConcurrency);

            Console.WriteLine("Show result(Y/N):");
            var showResult = Console.ReadLine();
            while (showResult.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("***** TEST RESULT gRPC Concurrency Grpc.AspNetCore *****");
                Console.WriteLine("count:" + listGrpcConcurrency.Count);
                if (listGrpcConcurrency.Count > 0)
                {
                    Console.WriteLine("min:" + listGrpcConcurrency.Min());
                    Console.WriteLine("max:" + listGrpcConcurrency.Max());
                    Console.WriteLine("avg:" + listGrpcConcurrency.Average());
                }

                Console.WriteLine("***** TEST RESULT gRPC ConsoleApp Concurrency *****");
                Console.WriteLine("count:" + listGrpcConsoleAppConcurrency.Count);
                if (listGrpcConsoleAppConcurrency.Count > 0)
                {
                    Console.WriteLine("min:" + listGrpcConsoleAppConcurrency.Min());
                    Console.WriteLine("max:" + listGrpcConsoleAppConcurrency.Max());
                    Console.WriteLine("avg:" + listGrpcConsoleAppConcurrency.Average());
                }

                Console.WriteLine("***** TEST RESULT WebApi Concurrency *****");
                Console.WriteLine("count:" + listWebApiConcurrency.Count);
                if (listWebApiConcurrency.Count > 0)
                {
                    Console.WriteLine("min:" + listWebApiConcurrency.Min());
                    Console.WriteLine("max:" + listWebApiConcurrency.Max());
                    Console.WriteLine("avg:" + listWebApiConcurrency.Average());
                }

                Console.WriteLine("Show result(Y/N):");
                showResult = Console.ReadLine();
            }
            #endregion

            Console.ReadKey();
        }
    }
}
