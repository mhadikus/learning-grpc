using Grpc.Core;
using ReverseService.Generated;
using static ReverseService.Generated.ReverseService;

namespace ReverseClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var channel = new Channel("localhost", 10001, ChannelCredentials.Insecure);
            var client = new ReverseServiceClient(channel);

            Console.Write("Enter a string to reverse: ");
            var stringToReverse = Console.ReadLine();

            var reversedString = await ReverseAsync(client, stringToReverse ?? string.Empty);
            Console.WriteLine(Environment.NewLine + reversedString + Environment.NewLine);

            Console.WriteLine("Press S to shutdown the server or any other key to exit the client...");
            var keyInfo = Console.ReadKey();
            if (keyInfo.KeyChar == 'S')
            {
                await ShutdownServerAsync(client);
            }
        }

        static async Task<string> ReverseAsync(ReverseServiceClient client, string stringToReverse)
        {
            try
            {
                var data = new Data() { Str = stringToReverse };
                var retVal = await client.ReverseAsync(data);
                return retVal.Str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return string.Empty;
        }

        static async Task ShutdownServerAsync(ReverseServiceClient client)
        {
            try
            {
                await client.ShutdownAsync(new ShutdownRequest());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}