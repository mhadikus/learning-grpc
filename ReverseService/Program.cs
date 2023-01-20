using System;

namespace ReverseService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            ReverseServer server = new ();
            server.Start();
            
            Console.WriteLine("Reverse server is listening...");

            await server.ShutdownRequested;
            Console.WriteLine(Environment.NewLine + "Shutdown requested by client.");

            await server.ShutdownAsync();
        }
    }
}
