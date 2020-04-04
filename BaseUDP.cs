using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public struct Received
{
       public IPEndPoint Emisor;
       public string Mensaje;
}

abstract class BaseUDP
{
       protected UdpClient Cliente;

       protected BaseUDP()
       {
           Cliente = new UdpClient();
       }

       public async Task<Received> Receive()
       {
           var resultado = await Cliente.ReceiveAsync();
           return new Received()
           {
               Mensaje = Encoding.ASCII.GetString(resultado.Buffer, 0, resultado.Buffer.Length),
               Emisor = resultado.RemoteEndPoint
           };
       }
}