using Grpc.Core;
using ReverseService.Generated;

namespace ReverseService
{
    public class ReverseServiceImplementation : Generated.ReverseService.ReverseServiceBase
    {
        private readonly ReverseServer _server;

        public ReverseServiceImplementation(ReverseServer server)
        {
            _server = server;
        }

        public override Task<Data> Reverse(Data request, ServerCallContext context)
        {
            var response = new Data() { Str = new string(request.Str.Reverse().ToArray()) };

            return Task.FromResult(response);
        }

        public override Task<ShutdownResponse> Shutdown(ShutdownRequest request, ServerCallContext context)
        {
            _server.SetShutdownRequested();
            var shutdownResponse = new ShutdownResponse();
            return Task.FromResult(shutdownResponse);
        }
    }
}
