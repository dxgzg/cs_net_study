using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using GameFramework.Network;
using StarForce;

class Program
{
    static void Main(string[] args)
    {
        var network_manger = new NetworkManager ();
        var channel_helper = new NetworkChannelHelper();

        var channel = network_manger.CreateNetworkChannel("test", ServiceType.Tcp, channel_helper);
        channel.SetDefaultHandler(handler);
        IPAddress  localIPAddress = IPAddress.Parse("127.0.0.1");
        channel.Connect(localIPAddress, 12345);
        var packet = new PacketBase();
        packet.msg =  "hello world!";
        Thread.Sleep(1000);
        channel.Send(packet);
        
        
        while (true)
        {
            network_manger.Update(1,1);
        }
    }
    
    public static void handler(object sender,Packet packet)
    {
        Console.WriteLine($"hello handler!!! {packet.ToString()}");
    }


}