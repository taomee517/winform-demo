// 创建人：李鸢
// 创建时间：2020/06/18 13:57

using System;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using SDK.STD.Constant;
using SDK.STD;
using winform_demo.Utils;

namespace winform_demo.Device
{
    public class VirtualDevice : ChannelDuplexHandler
        {
            private string mac;            
            private TerminalForm.ShowSendMsg showSend;
            private TerminalForm.ShowRecvMsg showRecv;
            private TerminalForm.OnlineStatusChange onlineStatusChange;

            private Gateway.ShowMsgLog showMsgLog;
            private Gateway.StatusChange statusChange;


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


            public VirtualDevice(string mac,
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

            public override void ChannelRead(IChannelHandlerContext context, object message)
            {
                var buffer = message as IByteBuffer;
                var len = buffer.ReadableBytes;
                var raw = new byte[len];
                buffer.GetBytes(buffer.ReaderIndex, raw);

                var msg = BytesUtil.BytesToHexWithBlank(raw);
                Console.WriteLine($"收到消息：{msg}");
                showMsgLog.Invoke("Server", msg);

                //帧头
                byte start = buffer.ReadByte();
                //imei
                byte[] srcImei = new byte[8];
                buffer.ReadBytes(srcImei);
                var gatewayNo = MessageBuilder.Bytes2GatewayNo(srcImei);

                /**属性-start*/
                byte[] attr = new byte[3];
                buffer.ReadBytes(attr);
                //协议版本
                var version = Convert.ToString(attr[0]);

                //响应状态码
                int srcStatusCode = attr[1];

                int multiInfo = attr[2];
                //环境
                int envCode = multiInfo >> 0x7 & 1;

                //数据类型
                int dataTypeCode = multiInfo >> 4 & 0x7;
                
                //请求方式
                int requestCode = multiInfo & 0xf;
            
                /**属性-end*/

                //功能号
                int funId = buffer.ReadUnsignedShort();
                
                //流水号-设备端
                int serial = buffer.ReadShort();
                //流水号-原请求端
                int requestSerial = buffer.ReadShort();
                //消息长度
                int length = buffer.ReadShort();
                //消息内容
                byte[] coreContent = new byte[length];
                buffer.ReadBytes(coreContent);

                //校验
                byte[] crc = new byte[2];
                buffer.ReadBytes(crc);

                switch (funId)
                {
                    case DefaultValue.REGISTER:
                        var coreBuffer = Unpooled.WrappedBuffer(coreContent);
                        var paramIndex = coreBuffer.ReadShort();
                        int paramLen = coreBuffer.ReadShort();
                        var tempPwd = coreBuffer.ReadCharSequence(paramLen, System.Text.Encoding.UTF8).ToString();
                        if (!DefaultValue.PWD_MAP.ContainsKey(gatewayNo)) {     
                            DefaultValue.PWD_MAP.Add(gatewayNo, tempPwd);
                        }
                    break;
                }

                //帧尾
                byte end = buffer.ReadByte();
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

            //private byte[] GetAndLogHeartBeat()
            //{
            //    var hbMsg = MessageBuilder.BuildHeartBeat(mac);
            //    var hbHex = BytesUtil.BytesToHexWithSeparator(hbMsg, "-");
            //    Console.WriteLine($"Time: {DateTime.Now} Mac: {mac} => 发送心跳消息：{hbHex}");
            //    return hbMsg;
            //}

            
        }
}