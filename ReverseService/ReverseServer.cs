using Grpc.Core;

namespace ReverseService
{
    public class ReverseServer
    {
        private readonly Server _server;

        public ReverseServer()
        {
            _server = new Server()
            {
                Services = { Generated.ReverseService.BindService(new ReverseServiceImplementation()) },
                Ports = { new ServerPort("localhost", 10001, ServerCredentials.Insecure) }
            };
        }

        public void Start()
        {
            _server.Start();
        }

        public async Task ShutDownAsync()
        {
            await _server.ShutdownAsync();
        }
    }
}
