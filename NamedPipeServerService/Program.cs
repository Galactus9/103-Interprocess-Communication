using System.IO.Pipes;
using System.Text;
using System.Xml;

namespace NamedPipeServerService
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            var client = new NamedPipeClientStream(".", "testPipe", PipeDirection.InOut, PipeOptions.Asynchronous);

            Console.WriteLine("Client -- Attempting to connect to pipe...\n");

            await client.ConnectAsync();

            Console.WriteLine("Client -- Connected to pipe.\n");

            string someText = "Some text from the client";

            var data = Encoding.UTF8.GetBytes(someText);

            var lenghtData = BitConverter.GetBytes(data.Length);

            Console.WriteLine("Client -- Send the size of the byte array to the server.\n");

            await client.WriteAsync(lenghtData, 0, 4);

            Console.WriteLine("Client -- Send the actual of the byte array to the server.\n");

            await client.WriteAsync(data, 0, data.Length);

            var a = new byte[1];

            await client.ReadAsync(a, 0, 1);
        }
    }
}