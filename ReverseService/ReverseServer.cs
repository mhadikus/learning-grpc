using Grpc.Core;

namespace ReverseService
{
    public class ReverseServer
    {
        private Server? _server;
        private readonly TaskCompletionSource<bool> shutdownRequested = new ();

        public Task ShutdownRequested => shutdownRequested.Task;

        public void Start()
        {
            _server = new Server()
            {
                Services = { Generated.ReverseService.BindService(new ReverseServiceImplementation(this)) },
                Ports = { new ServerPort("localhost", 10001, ServerCredentials.Insecure) }
            };

            _server.Start();
        }

        public async Task ShutdownAsync()
        {
            if (_server != null)
            {
                await _server.ShutdownAsync();
            }
            _server = null;
        }

        internal void SetShutdownRequested()
        {
            shutdownRequested.TrySetResult(true);
        }
    }
}
