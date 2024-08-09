//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace GameFramework.Network
{
    /// <summary>
    /// 网络消息包头接口。
    /// </summary>
    public class IPacketHeader
    {
        /// <summary>
        /// 获取网络消息包长度。
        /// </summary>
        public int PacketLength
        {
            get;
        }
    }
}
