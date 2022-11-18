using Application.Models;
using AutoMapper;
using HorizonSearchPlatform.Integration.Octokit;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HorizonSearchPlatform.Server
{
    public class ConnectionClient
    {
        private TcpListener Listener { get; set; }
        private readonly IMapper _mapper;
        public ConnectionClient(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TcpListener GetListener(ConnectionAddress connectionAddress)
        {
            Listener = new TcpListener(IPAddress.Parse(connectionAddress.Ip), connectionAddress.Port);
            return Listener;
        }

        public async void Process(object client)
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

                var query = JsonConvert.DeserializeObject<SearchRequest>(json)!;
                json = await RepositoryHandler.GetRepositoriesAsync(query, _mapper);

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
