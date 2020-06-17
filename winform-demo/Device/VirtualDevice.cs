using DotNetty.Buffers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using System;
using winform_demo.SDK;
using winform_demo.SDK.Constant;

namespace winform_demo.Device
{
    class VirtualDevice : ChannelDuplexHandler
    {
        private string mac;
        private int index = 0;

        public VirtualDevice(string mac)
        {
            this.mac = mac;
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            //            var msg = GetAndLogHeartBeat();
            var msg = GetRealMsg();
            //            var msg = GetCrackDeviceMsg();
            //            var msg = GetSettleDeviceMsg();
            context.WriteAndFlushAsync(Unpooled.WrappedBuffer(msg));
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            base.ChannelInactive(context);
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            base.ChannelRead(context, message);
        }

        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            if (evt is IdleStateEvent state)
            {
                switch (state.State)
                {
                    case IdleState.WriterIdle:
                        //                        var hbMsg = GetAndLogHeartBeat();
                        //                        context.WriteAndFlushAsync(Unpooled.WrappedBuffer(hbMsg));

                        //                        var msg = GetSettleDeviceMsg();
                        //                        context.WriteAndFlushAsync(Unpooled.WrappedBuffer(msg));
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

        public override void Flush(IChannelHandlerContext context)
        {
            base.Flush(context);
        }


        private byte[] GetAndLogHeartBeat()
        {
            var hbMsg = MessageBuilder.BuildHeartBeat(mac);
            var hbHex = BytesUtil.BytesToHexWithSeparator(hbMsg, "-");
            Console.WriteLine($"Time: {DateTime.Now} Mac: {mac} => 发送心跳消息：{hbHex}");
            return hbMsg;
        }

        private byte[] GetRealMsg()
        {
            //线上数据
            //            var hex =
            //                "00 b8 a5 01 a5 2e 5d 00 82 5e d7 03 13 40 76 00 01 06 00 00 14 00 16 3e 12 5c 98 00 19 01 02 58 01 00 01 06 00 00 14 01 0b bf 5e d7 03 13 43 72 54 90 ee 96 76 99 7a 05 a5 01";
            //            var hex = "A502010082386B818040780E2015FBBA1300163E125C980019020E10010E2015FBBA13010BC2386B81809489001C4126C6B60CD6";
            var hex = "A502010082386B818040780E2015FBBA1300163E125C980019020258010E2015FBBA13010BC0386B8180BE1C3FFA420680000BEE";
            //            var mac = hex.Substring(32, 18).Replace(" ", "");
            //            var mac = hex.Substring(22, 12);
            //            Console.WriteLine($"Time: {DateTime.Now} Mac: {mac} => 发送消息：{hex}");
            //            var hex =
            //                "82-55-02-00-08-06-14-0f-15-15-03-00-17-01-00-00-00-00-9d-1a-00-00-41-e2-00-00-00-00-00-00-01-00-5c-00-e0-03-00-03-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-ad-01-31-39-30-31-c8-00-00-00-00-00-00-00-00-00-00-00-9b-00-00-00-e0-06-00-00-00-00-00-04-30-00-03-59-59-59-59-59-00-00-e2-04-bc-00-00-00-00-00-cc-03-f5-03-00-00-00-00-00-00-00-00-00-00-00-00-56-07-00-00-70-06-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-de-d9";
            hex = hex.Replace("-", "");
            hex = hex.Replace(" ", "");
            var msg = BytesUtil.Hex2Bytes(hex);
            return msg;
        }

        private byte[] GetCrackDeviceMsg()
        {
            var core = MessageBuilder.BuildCrackData(1005, 30f);
            var sensorMsg = MessageBuilder.BuildSensorMsg(mac, 1, SensorType.THLSD, core);
            var msg = MessageBuilder.BuildMessage(0, TransportType.GRPS, FunType.GatewayCacheDataBPublish, mac,
                sensorMsg);
            var hex = BytesUtil.BytesToHex(msg);
            Console.WriteLine($"Time: {DateTime.Now} Mac: {mac} => 发送消息：{hex}");
            return msg;
        }


        private byte[] GetSettleDeviceMsg()
        {
            var srcUnmarkHeight = 3000;
            var srcHeight = 10050.32f;
            var unmarkHeight = srcUnmarkHeight + index * 12;
            var height = srcHeight + index * 1.2f * (new Random().Next(10));
            var core = MessageBuilder.BuildSettleData(unmarkHeight, -3, height);
            var sensorMsg = MessageBuilder.BuildSensorMsg(mac, 1, SensorType.THSTC, core);
            var msg = MessageBuilder.BuildMessage(0, TransportType.GRPS, FunType.GatewayCacheDataBPublish, mac,
                sensorMsg);
            var hex = BytesUtil.HexInsertSpace(BytesUtil.BytesToHex(msg));
            Console.WriteLine($"Time: {DateTime.Now} Index : {index} Mac: {mac} => 发送消息：{hex}");
            index++;
            return msg;
        }
    }
}
