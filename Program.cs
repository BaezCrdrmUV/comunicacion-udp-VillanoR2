using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace comunicacion_udp_VillanoR2
{
    class Program
    {
        static void Main(string[] args)
        {
            var servidor = new ServerUDP();

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var receptor = await servidor.Receive();
                    servidor.Repetir("copia " + receptor.Mensaje, receptor.Emisor);
                    if (receptor.Mensaje == "bye")
                        break;
                }
            });

            var cliente = ClienteUDP.ConnectTo("127.0.0.1", 8080);

            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var receptor = await cliente.Receive();
                        Console.WriteLine(receptor.Mensaje);
                        if (receptor.Mensaje.Contains("bye"))
                            break;
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                }
            });

            //type ahead :-)
            string leer;
            do
            {
                leer = Console.ReadLine();
                cliente.Enviar(leer);
            } while (leer != "bye");
        }
    }
}
