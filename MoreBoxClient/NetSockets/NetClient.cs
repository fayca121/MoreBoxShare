using System.Net;
using System.Net.Sockets;

namespace NetSockets
{
    public class NetClient : NetBaseClient<byte[]>
    {
        protected override NetBaseStream<byte[]> CreateStream(NetworkStream ns, EndPoint ep)
        {
            return new NetStream(ns, ep);
        }
    }
}
