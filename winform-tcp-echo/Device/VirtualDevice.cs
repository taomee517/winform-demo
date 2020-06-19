// 创建人：李鸢
// 创建时间：2020/06/18 13:57

using System;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using winform_demo.SDK;

namespace winform_demo.Device
{
    public class VirtualDevice : ChannelDuplexHandler
        {
            private string mac;
            private TerminalForm.ShowSendMsg showSend;
            private TerminalForm.ShowRecvMsg showRecv;
            private TerminalForm.OnlineStatusChange onlineStatusChange;
            private int index = 0;

            public VirtualDevice(string mac, 
                TerminalForm.ShowSendMsg showSend, 
                TerminalForm.ShowRecvMsg showRecv,
                TerminalForm.OnlineStatusChange onlineStatusChange)
            {
                this.mac = mac;
                this.showSend = showSend;
                this.showRecv = showRecv;
                this.onlineStatusChange = onlineStatusChange;
            }

            public override void ChannelActive(IChannelHandlerContext context)
            {
                Console.WriteLine("device active!");
                onlineStatusChange.DynamicInvoke(true);

            }

            public override void ChannelInactive(IChannelHandlerContext context)
            {
                Console.WriteLine("device inactive!");
                onlineStatusChange.DynamicInvoke(false);
                context.CloseAsync();
            }

            public override void ChannelRead(IChannelHandlerContext context, object message)
            {
                var msg = BytesUtil.Bytes2String(message as byte[]);
                Console.WriteLine($"收到消息：{msg}");
                showRecv.DynamicInvoke(msg);
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
                    showSend.DynamicInvoke(message);
                    var bytes = BytesUtil.String2Bytes(message as string);
                    var buffer = Unpooled.WrappedBuffer(bytes);
                    context.WriteAndFlushAsync(buffer);
                }

                return Task.CompletedTask;
            }


            public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
            {
                Console.WriteLine("Exception: " + exception);
                context.CloseAsync();
            }

            private byte[] GetAndLogHeartBeat()
            {
                var hbMsg = MessageBuilder.BuildHeartBeat(mac);
                var hbHex = BytesUtil.BytesToHexWithSeparator(hbMsg, "-");
                Console.WriteLine($"Time: {DateTime.Now} Mac: {mac} => 发送心跳消息：{hbHex}");
                return hbMsg;
            }
        }
}