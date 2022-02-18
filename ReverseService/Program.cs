using System;

namespace ReverseService
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseServer server = new ReverseServer();
            server.Start();
            Console.WriteLine("Reverse server is listening...");
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}
