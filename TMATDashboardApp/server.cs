using System;
using System.Collections.Generic;
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

    private async void AcceptClientsAsync()
    {
        try
        {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                connectedClients.Add(client);
                Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                // Handle the new client in a separate task
                Task.Run(() => HandleClientAsync(client));
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