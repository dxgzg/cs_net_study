//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Network;

namespace StarForce
{
    public class PacketBase : Packet
    {

        public string msg;
        public override void Clear()
        {
          
        }

        public override string ToString()
        {
            return msg;
        }

        public override int Id { get; }
    }
}
