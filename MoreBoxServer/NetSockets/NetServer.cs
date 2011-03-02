using System.Net;
using System.Net.Sockets;

namespace NetSockets
{
    public class NetServer : NetBaseServer<byte[]>
    {
        protected override NetBaseStream<byte[]> CreateStream(NetworkStream ns, EndPoint ep)
        {
            return new NetStream(ns, ep);
        }
    }
}
