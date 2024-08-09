//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace StarForce
{
    public class NetworkChannelHelper : INetworkChannelHelper
    {
        private readonly Dictionary<int, Type> m_ServerToClientPacketTypes = new Dictionary<int, Type>();
        private readonly MemoryStream m_CachedStream = new MemoryStream(1024 * 8);
        private INetworkChannel m_NetworkChannel = null;

        /// <summary>
        /// 获取消息包头长度。
        /// </summary>
        public int PacketHeaderLength
        {
            get
            {
                return sizeof(int);
            }
        }

        /// <summary>
        /// 初始化网络频道辅助器。
        /// </summary>
        /// <param name="networkChannel">网络频道。</param>
        public void Initialize(INetworkChannel networkChannel)
        {
            m_NetworkChannel = networkChannel;
        }

        /// <summary>
        /// 关闭并清理网络频道辅助器。
        /// </summary>
        public void Shutdown()
        {

        }

        /// <summary>
        /// 准备进行连接。
        /// </summary>
        public void PrepareForConnecting()
        {
            m_NetworkChannel.Socket.ReceiveBufferSize = 1024 * 64;
            m_NetworkChannel.Socket.SendBufferSize = 1024 * 64;
        }

        /// <summary>
        /// 发送心跳消息包。
        /// </summary>
        /// <returns>是否发送心跳消息包成功。</returns>
        public bool SendHeartBeat()
        {
            // m_NetworkChannel.Send(ReferencePool.Acquire<CSHeartBeat>());
            return true;
        }

        /// <summary>
        /// 序列化消息包。
        /// </summary>
        /// <typeparam name="T">消息包类型。</typeparam>
        /// <param name="packet">要序列化的消息包。</param>
        /// <param name="destination">要序列化的目标流。</param>
        /// <returns>是否序列化成功。</returns>
        public bool Serialize<T>(T packet, Stream destination) where T : Packet
        {
            Console.WriteLine($"1111111{packet.ToString()}"); 
            
            destination.Write( Encoding.UTF8.GetBytes(packet.ToString()));
            return true;
        }

        /// <summary>
        /// 反序列化消息包头。
        /// </summary>
        /// <param name="source">要反序列化的来源流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包头。</returns>
        public IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
        {
            customErrorData = null;
            SCPacketHeader scPacketHeader = new SCPacketHeader();

            scPacketHeader.Id = 2;
            scPacketHeader.PacketLength = 12;
            return scPacketHeader;
            
            // 注意：此函数并不在主线程调用！
            // customErrorData = null;
            // return (IPacketHeader)RuntimeTypeModel.Default.Deserialize(source, ReferencePool.Acquire<SCPacketHeader>(), typeof(SCPacketHeader));
        }

        /// <summary>
        /// 反序列化消息包。
        /// </summary>
        /// <param name="packetHeader">消息包头。</param>
        /// <param name="source">要反序列化的来源流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包。</returns>
        public Packet DeserializePacket(IPacketHeader packetHeader,Stream source, out object customErrorData)
        {
            SCPacketHeader scPacketHeader = packetHeader as SCPacketHeader;
            PacketBase b = new PacketBase(scPacketHeader.Id);
            customErrorData = null;
            // 注意：此函数并不在主线程调用！
            // customErrorData = null;
            //
            // SCPacketHeader scPacketHeader = packetHeader as SCPacketHeader;
            // if (scPacketHeader == null)
            // {
            //     Log.Warning("Packet header is invalid.");
            //     return null;
            // }
            //
            // Packet packet = null;
            // if (scPacketHeader.IsValid)
            // {
            //     Type packetType = GetServerToClientPacketType(scPacketHeader.Id);
            //     if (packetType != null)
            //     {
            //         packet = (Packet)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(source, ReferencePool.Acquire(packetType), packetType, PrefixStyle.Fixed32, 0);
            //     }
            //     else
            //     {
            //         Log.Warning("Can not deserialize packet for packet id '{0}'.", scPacketHeader.Id.ToString());
            //     }
            // }
            // else
            // {
            //     Log.Warning("Packet header is invalid.");
            // }
            //
            // ReferencePool.Release(scPacketHeader);
            b.msg = "hello deserialize packet";
            var memoSource = source as MemoryStream;
            b.msg = Encoding.UTF8.GetString(memoSource.ToArray());

            // TODO 确认
             // b.Id = 2;
            return b;
        }

       
    }
}
