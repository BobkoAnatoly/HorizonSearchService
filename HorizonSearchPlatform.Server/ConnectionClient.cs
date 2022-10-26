
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace HorizonSearchPlatform.Server
{
    public class ConnectionClient
    {
        private TcpListener Listener { get; set; }
        public ConnectionAddress ConnectionAddress { get; private set; }

        public ConnectionClient(ConnectionAddress сonnectionАddress)
        {
            ConnectionAddress = сonnectionАddress;
        }

        public TcpListener GetListener()
        {
            Listener = new TcpListener(IPAddress.Parse(ConnectionAddress.Ip), ConnectionAddress.Port);
            return Listener;
        }

        public void Process(object client)
        {
            
            NetworkStream stream = default;
            var _tcpClient = client as TcpClient;
            try
            {
                //Получение сетевого потока
                stream = _tcpClient.GetStream();

                byte[] buffer = new byte[_tcpClient.ReceiveBufferSize];

                StringBuilder response = new StringBuilder();
                int bytes = default;

                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    response.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (stream.DataAvailable);

                string json = response.ToString();

                //var query = JsonSerializer.Deserialize<ServerQuery>(json)!;

                //json = HandlerType.SearchType(query, _methodService);

                buffer = Encoding.Unicode.GetBytes(json);
                stream.Write(buffer, 0, buffer.Length);

            }

            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            finally
            {
                if (stream != null)
                    stream.Close();

                if (_tcpClient != null)
                    _tcpClient.Close();
            }
        }
    }
}
