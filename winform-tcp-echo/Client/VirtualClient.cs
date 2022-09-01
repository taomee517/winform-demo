using System;
using System.Net;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using SDK.STD.Protocol;
using winform_demo.Device;
using winform_demo.Handler;
using winform_demo.SDK;

namespace winform_demo.Client
{
    class VirtualClient
    {
        private string Host;
        private int Port;
        private bool HeartbeatSwitch;
        private int Interval;
        VirtualDevice Device;
        private static IChannel _channel;

        public VirtualClient(string host, int port, bool heartbeatSwitch, int interval, VirtualDevice device)
        {
            Host = host;
            Port = port;
            HeartbeatSwitch = heartbeatSwitch;
            Interval = interval;
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
                        //pipeline.AddLast("split", new FrameSplitDecoder());
                        pipeline.AddLast("split", new StdFrameSplitHandler());
                        pipeline.AddLast("unescape", new StdUnescapeHandler());
                        if (HeartbeatSwitch)
                        {
                            var idleHandle = new IdleStateHandler(0, Interval, 0);
                            pipeline.AddLast("idle", idleHandle);
                        }
                        pipeline.AddLast("device", Device);
                    }));
                var addr = IPAddress.Parse(Host);
                var endPoint = new IPEndPoint(addr, Port);
                _channel = await bootstrap.ConnectAsync(endPoint);
                Console.WriteLine($"client started, connect to : {endPoint}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                await Task.WhenAll(workers.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }

        public bool Active()
        {
            return _channel!=null && _channel.Active;
        }

        public void Send(string msg)
        {
            _channel.WriteAndFlushAsync(msg);
        }

        public void AddInterval(int interval)
        {
           var pipeline = _channel.Pipeline;
           var idleHandle = new IdleStateHandler(0, interval, 0);
           pipeline.AddBefore("device", "idle", idleHandle);
        }
        
        public void RemoveInterval()
        {
            var pipeline = _channel.Pipeline;
            pipeline.Remove("idle");
        }


        public Task Disconnect()
        {
            return _channel.DisconnectAsync();
        }
    }
}
