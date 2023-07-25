using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class CsvServer
{
    private const int port = 8000;
    private TcpListener server;
    private List<TcpClient> clients = new List<TcpClient>();

    public CsvServer()
    {
        // Start TCP listener
        server = new TcpListener(IPAddress.Any, port);
        server.Start();
        Console.WriteLine("Server started on port " + port);

        // Accept client connections
        AcceptConnections();
    }

    private async void AcceptConnections()
    {
        while (true)
        {
            TcpClient client = await server.AcceptTcpClientAsync();
            clients.Add(client);

            Console.WriteLine("Client connected: " + client.Client.RemoteEndPoint);

            // Handle client in separate thread
            await Task.Run(() => HandleClient(client));
        }
    }

    private void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();

        while (true)
        {
            // Receive CSV data from client
            string csvData = ReceiveCsv(stream);

            // Broadcast data to other clients
            BroadcastCsv(csvData, client);
        }
    }

    private string ReceiveCsv(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);

        // Convert to string
        string csv = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        Console.WriteLine("Received CSV: " + csv);

        return csv;
    }

    private void BroadcastCsv(string csv, TcpClient sender)
    {
        byte[] data = Encoding.UTF8.GetBytes(csv);

        foreach (TcpClient c in clients)
        {
            if (c != sender)
            {
                NetworkStream stream = c.GetStream();
                stream.Write(data, 0, data.Length);
            }
        }
    }

    public static void Main()
    {
        CsvServer server = new CsvServer();

        Console.ReadLine();
    }
}