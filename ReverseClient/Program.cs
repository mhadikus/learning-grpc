using Grpc.Core;

namespace ReverseClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a string to reverse: ");
            var stringToReverse = Console.ReadLine();

            var reversedString = ReverseAsync(stringToReverse ?? string.Empty).GetAwaiter().GetResult();

            Console.WriteLine(Environment.NewLine + reversedString + Environment.NewLine);
        }

        static async Task<string> ReverseAsync(string stringToReverse)
        {
            try
            {
                var channel = new Channel("localhost", 10001, ChannelCredentials.Insecure);
                var client = new ReverseService.Generated.ReverseService.ReverseServiceClient(channel);

                var data = new ReverseService.Generated.Data() { Str = stringToReverse };
                var retVal = await client.ReverseAsync(data);
                return retVal.Str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return string.Empty;
        }
    }
}