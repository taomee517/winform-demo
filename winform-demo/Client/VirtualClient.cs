using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using winform_demo.Device;
using winform_demo.Handler;

namespace winform_demo.Client
{
    class VirtualClient
    {
        private string Host;
        private int Port;
        VirtualDevice Device;

        public VirtualClient(string host, int port, VirtualDevice device)
        {
            Host = host;
            Port = port;
            Device = device;
        }

        public async Task Start()
        {
            var bootstrap = new Bootstrap();
            var workers = new MultithreadEventLoopGroup();
            try
            {
                bootstrap.Group(workers)
                    .Channel<TcpSocketChannel>()
                    .Handler(new ActionChannelInitializer<ISocketChannel>(ch =>
                    {
                        var pipeline = ch.Pipeline;
                        pipeline.AddLast("split", new FrameSplitDecoder());
                        pipeline.AddLast("idle", new IdleStateHandler(0, 30, 0));
                        pipeline.AddLast("device", Device);
                    }));
                var addr = IPAddress.Parse(Host);
                var endPoint = new IPEndPoint(addr, Port);
                var channel = await bootstrap.ConnectAsync(endPoint);
                Console.WriteLine($"client started, connect to : {endPoint}");
                Console.ReadLine();
                await channel.CloseAsync();
            }
            catch (Exception e)
            {
                await Task.WhenAll(workers.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }
    }
}
