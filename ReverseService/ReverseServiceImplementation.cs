using Grpc.Core;
using ReverseService.Generated;

namespace ReverseService
{
    public class ReverseServiceImplementation : Generated.ReverseService.ReverseServiceBase
    {
        public override Task<Data> Reverse(Data request, ServerCallContext context)
        {
            var response = new Data() { Str = new string(request.Str.Reverse().ToArray()) };

            return Task.FromResult(response);
        }
    }
}
