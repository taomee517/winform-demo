// 创建人：李鸢
// 创建时间：2020/06/18 13:57

using System;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using winform_demo.Utils;
using Windows;
using DotNetty.Transport.Channels.Sockets;

namespace winform_demo.Device
{
    public abstract class AbstractMockDevice : ChannelDuplexHandler
    {
            string mac;            

            Gateway.ShowMsgLog showMsgLog;
            Gateway.StatusChange statusChange;
            public ActionChannelInitializer<ISocketChannel> ChannelInitializer { get; set; }


        public AbstractMockDevice(string mac,
                Gateway.ShowMsgLog showMsgLog,
                Gateway.StatusChange statusChange)
            {
                this.mac = mac;
                this.showMsgLog = showMsgLog;
                this.statusChange = statusChange;
            }

            public override void ChannelActive(IChannelHandlerContext context)
            {
                Console.WriteLine("channel active!");
                statusChange.Invoke(true);
            }

            public override void ChannelInactive(IChannelHandlerContext context)
            {
                Console.WriteLine("channel inactive!");
                statusChange.Invoke(false);

                context.CloseAsync();
            }
            
            public void ShowReceiveMessage(IByteBuffer buffer)
            {
                var len = buffer.ReadableBytes;
                var raw = new byte[len];
                buffer.GetBytes(buffer.ReaderIndex, raw);

                var msg = BytesUtil.BytesToHexWithBlank(raw);
                Console.WriteLine($"收到消息：{msg}");
                showMsgLog.Invoke("Server", msg);
            }

            public override void UserEventTriggered(IChannelHandlerContext context, object evt)
            {
                if (evt is IdleStateEvent state)
                {
                    switch (state.State)
                    {
                        case IdleState.WriterIdle:
                            Console.WriteLine("writer idle time out!");
                            context.Channel.WriteAsync("heart beat(" + mac + ")");
                            break;
                        case IdleState.ReaderIdle:
                            Console.WriteLine("reader idle time out!");
                            break;
                        case IdleState.AllIdle:
                            Console.WriteLine("all idle time out!");
                            break;
                        default:
                            break;
                    }
                }

            }

            public override Task WriteAsync(IChannelHandlerContext context, object message)
            {
                if (message is string)
                {
                    Console.WriteLine($"发送消息:{message}");
                      

                    var bytes = BytesUtil.Hex2Bytes(message as string);
                    var buffer = Unpooled.WrappedBuffer(bytes);
                    context.WriteAndFlushAsync(buffer);

                    var sepHex = BytesUtil.HexInsertSpace(message as string);
                    showMsgLog.Invoke("Device", sepHex);
                }

                return Task.CompletedTask;
            }


            public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
            {
                Console.WriteLine("Exception: " + exception);
                context.CloseAsync();
            }            
        }
}