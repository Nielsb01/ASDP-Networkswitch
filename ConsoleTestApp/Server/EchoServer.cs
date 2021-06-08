using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    class EchoServer {
        public void Start(int port = 9000) {
            var endPoint = new IPEndPoint(IPAddress.Loopback, port);

            var socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            //How many pending connections are allowed
            socket.Listen(128);

            _ = Task.Run(() => DoEcho(socket));
        }

        private async Task DoEcho( Socket socket ) {
            do
            {
                var clientSocket = await Task.Factory.FromAsync(
                    new Func<AsyncCallback, object, IAsyncResult>(socket.BeginAccept),
                    new Func<IAsyncResult, Socket>(socket.EndAccept),
                    null).ConfigureAwait(false);

                Console.WriteLine("ECHO SERVER :: CLIENT CONNECTED");

                using var stream = new NetworkStream(clientSocket);
                var buffer = new Byte[1024];
                do
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);

                    //client connection is gone but socket is not closed
                    if (bytesRead == 0)
                        break;

                    await stream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
                } while (true);
            } while (true);
        }

    }
}
