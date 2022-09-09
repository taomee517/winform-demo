// 创建人：罗涛
// 创建时间：2020/06/18 13:57

using System;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using SDK.MEASURE.Protocol;
using SDK.STD.Protocol;
using Windows;
using winform_demo.Device;

namespace SDK.MEASURE.Device
{
    public class MeasureMockDevice : AbstractMockDevice
    {
            public MeasureMockDevice(string mac,
                Gateway.ShowMsgLog showMsgLog,
                Gateway.StatusChange statusChange)
            :base(mac,showMsgLog, statusChange)
            {
                base.ChannelInitializer = new ActionChannelInitializer<ISocketChannel>(ch =>
                {
                    var pipeline = ch.Pipeline;
                    pipeline.AddLast("split", new MeasureFrameSplitHandler());
                    pipeline.AddLast("validate", new MeasureValidateHandler());
                    pipeline.AddLast("device", this);
                });
            }


            public override void ChannelRead(IChannelHandlerContext context, object message)
            {
                base.ShowReceiveMessage(message as IByteBuffer);
            }
        
        }
}