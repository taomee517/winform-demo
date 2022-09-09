// 创建人：罗涛
// 创建时间：2020/06/18 13:57

using System;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using SDK.STD.Constant;
using SDK.STD;
using winform_demo.Utils;
using Windows;
using winform_demo.Device;
using DotNetty.Transport.Channels.Sockets;
using SDK.STD.Protocol;

namespace SDK.STD.Device
{
    public class AeroVMMockDevice : AbstractMockDevice
    {
            private Gateway.PwdGetter pwdGetter;

            public AeroVMMockDevice(string mac,
                Gateway.ShowMsgLog showMsgLog,
                Gateway.StatusChange statusChange,
                Gateway.PwdGetter pwdGetter)
            :base(mac,showMsgLog, statusChange)
            {
                this.pwdGetter = pwdGetter;
                base.ChannelInitializer = new ActionChannelInitializer<ISocketChannel>(ch =>
                {
                    var pipeline = ch.Pipeline;
                    pipeline.AddLast("split", new StdFrameSplitHandler());
                    pipeline.AddLast("unescape", new StdUnescapeHandler());
                        //if (HeartbeatSwitch)
                        //{
                        //    var idleHandle = new IdleStateHandler(0, Interval, 0);
                        //    pipeline.AddLast("idle", idleHandle);
                        //}
                        pipeline.AddLast("device", this);
                });
            }


            public override void ChannelRead(IChannelHandlerContext context, object message)
            {
                var buffer = message as IByteBuffer;
                var len = buffer.ReadableBytes;
                base.ShowReceiveMessage(buffer);

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
                        pwdGetter.Invoke(tempPwd);
                        if (!DefaultValue.PWD_MAP.ContainsKey(gatewayNo)) {     
                            DefaultValue.PWD_MAP.Add(gatewayNo, tempPwd);
                        }
                    break;
                }

                //帧尾
                byte end = buffer.ReadByte();
            }
        
        }
}