using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

namespace InterprocessCommunication
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var one = Task.Run(async () =>
            {
                var server = new NamedPipeServerStream("testPipe", PipeDirection.InOut);

                string clientExePath = "NamedPipeClientService.exe";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = clientExePath,
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;

                    process.Start();

                    Console.WriteLine("Server -- NamedPipeServerStream object created.\n");

                    Console.WriteLine("Server -- Waiting for client connection...\n");

                    server.WaitForConnection();

                    Console.WriteLine("Server -- Client connected.\n");

                    byte[] data = new byte[4];

                    await server.ReadAsync(data, 0, 4);

                    var lenght = BitConverter.ToInt32(data, 0);

                    Console.WriteLine($"Server -- Received the size of the byte array from the Client.({lenght})\n");

                    byte[] realData = new byte[lenght];

                    await server.ReadAsync(realData, 0, lenght);

                    Console.WriteLine("Server -- Receive the actual message in a byte array from the Client.\n");

                    var str = Encoding.UTF8.GetString(realData);

                    Console.WriteLine($"Server -- The message from the Client is : {str}.\n");

                    await server.WriteAsync(new byte[] { 0 }, 0, 1);

                    process.WaitForExit();
                }
            });
            Task.WaitAll(one);
        }
    }
}