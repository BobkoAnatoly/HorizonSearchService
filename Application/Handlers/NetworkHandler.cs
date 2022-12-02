using System.Net.Sockets;
using System.Text;

namespace Application.Handlers
{
    public static class NetworkHandler
    {
        public static async Task<string> GetAsync(string jsonQuery)
        {
            TcpClient? client = null;

            string IP = "127.0.0.1";
            int PORT = Convert.ToInt32("5050");

            try
            {
                client = new TcpClient(IP, PORT);
                NetworkStream stream = client.GetStream();

                byte[] buffer = Encoding.Unicode.GetBytes(jsonQuery);

                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

                buffer = new byte[client.ReceiveBufferSize];
                int bytes = default;

                StringBuilder response = new StringBuilder();
                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    response.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (stream.DataAvailable);

                return response.ToString();
            }

            catch (Exception ex) { Console.WriteLine(ex.Message); }

            finally
            {
                if (client! is null)
                    client!.Close();
            }

            throw new Exception("Ошибка при подключении к серверу");
        }
    }
}

