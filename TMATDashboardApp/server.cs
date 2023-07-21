using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class CsvFileServer
{
    private const int port = 1234; // Server listening port number
    private TcpListener listener;
    private List<TcpClient> connectedClients = new List<TcpClient>();

    public CsvFileServer()
    {
        // Start the server and listen for incoming connections
        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine("Server started. Listening for incoming connections...");
        AcceptClientsAsync();
    }

    private async Task AcceptClientsAsync()
    {
        try
        {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                connectedClients.Add(client);
                Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                // Handle the new client in a separate task
                _ = HandleClientAsync(client); // Using _ to suppress the "not awaited" warning
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while accepting clients: " + ex.Message);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        try
        {
            NetworkStream networkStream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                // Deserialize the received data into a CSV string
                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Process the received CSV data here (e.g., write to a CSV file or display it)
                ProcessReceivedCsv(receivedData);

                // Broadcast the received data to all connected clients except the sender
                foreach (TcpClient connectedClient in connectedClients)
                {
                    if (connectedClient != client)
                    {
                        await connectedClient.GetStream().WriteAsync(buffer, 0, bytesRead);
                    }
                }
            }

            // When a client disconnects, remove it from the list of connected clients
            connectedClients.Remove(client);
            Console.WriteLine($"Client disconnected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while handling client: {((IPEndPoint)client.Client.RemoteEndPoint).Address}. {ex.Message}");
            connectedClients.Remove(client);
        }
    }


    private void ProcessReceivedCsv(string receivedCsv)
    {
        // Implement your logic to handle the received CSV data here
        // For example, you can save it to a file or display it in the console
        Console.WriteLine("Received CSV data:");
        Console.WriteLine(receivedCsv);
    }
}

public class Program
{
    static void Main()
    {
        // Start the server
        CsvFileServer server = new CsvFileServer();

        // Keep the server running
        Console.ReadLine();
    }
}
