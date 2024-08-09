//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Network;

namespace StarForce
{
    public abstract class PacketHeaderBase : IPacketHeader, IReference
    {

        public int Id
        {
            get;
            set;
        }

        public int PacketLength
        {
            get;
            set;
        }
        

        public void Clear()
        {
            Id = 0;
            PacketLength = 0;
        }
    }
}
