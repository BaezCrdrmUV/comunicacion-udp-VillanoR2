using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace comunicacion_udp_VillanoR2
{
    class ServerUDP : BaseUDP
    {
        private IPEndPoint EscucharEncendido;

        public ServerUDP() : this(new IPEndPoint(IPAddress.Any, 8080))
        {
        }

        public ServerUDP(IPEndPoint endpoint)
        {
            EscucharEncendido = endpoint;
            Cliente = new UdpClient(EscucharEncendido);
        }

        public void Repetir(string mensaje, IPEndPoint puntofinal)
        {
            var datagrama = Encoding.ASCII.GetBytes(mensaje);
            Cliente.Send(datagrama, datagrama.Length, puntofinal);
        }

    }
}