using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace comunicacion_udp_VillanoR2
{
    class ClienteUDP : BaseUDP
    {
        private ClienteUDP() { }

        public static ClienteUDP ConnectTo(string hostname, int puerto)
        {
            var conexion = new ClienteUDP();
            conexion.Cliente.Connect(hostname, puerto);
            return conexion;
        }

        public void Enviar(string mensaje)
        {
            var datagrama = Encoding.ASCII.GetBytes(mensaje);
            Cliente.Send(datagrama, datagrama.Length);
        }

    }
}

