// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using TCPServer.Models;

Console.WriteLine("Hello, World!");
TcpListener listener = null;
try
{
    // Set the TCP IP address and port number
    IPAddress ip = IPAddress.Parse("127.0.0.1");
    int port = 9794;

    // Create a TCP listener object
    listener = new TcpListener(ip, port);

    // Start listening for client requests
    listener.Start();

    Console.WriteLine("Server started...");
    int speedMult = 0;
    while (true)
    {
        Console.WriteLine("Waiting for a client to connect...");

        // Accept client requests
        TcpClient client = listener.AcceptTcpClient();

        Console.WriteLine("Client connected...");

        // Get the client stream
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytes;

        // Loop to receive client data
        while ((bytes = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in buffer)
            {
                sb.Append($" {b}");
            }
            String byteString = sb.ToString().Trim();
            // Convert client data to string
            string data = Encoding.ASCII.GetString(buffer, 0, bytes);

            Console.WriteLine("Received: {0}", byteString.Trim());
            //string hexString = BitConverter.ToString(buffer);
            //Console.WriteLine("Received HEX: {0}", hexString);
            Console.WriteLine("Send message");

            // Send response back to the client
            //byte[] msg = Encoding.ASCII.GetBytes($"ASTAIRE_SYS003\r\n68-27-19-E1-48-4C\r\n4.10.4.1\r\nAstaire 880-014\r\n");
            //stream.Write(buffer, 0, buffer.Length);
             
            if (buffer[0]==17)
            {
            Random rand = new Random();
            int temp=rand.Next(0,10);
            GetState getState = new GetState(temp, temp, temp, temp,temp, temp, temp, temp, temp, temp, temp, temp, (byte)temp, (byte)temp, (byte)temp, (byte)temp, (ushort)temp, (byte)temp);
            int size = Marshal.SizeOf(getState);
            byte[] byteArray = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(getState, ptr, true);
            Marshal.Copy(ptr, byteArray, 0, size);
            Marshal.FreeHGlobal(ptr);
            stream.Write(byteArray, 0, size);
            }
            else if (buffer[0] == 16&& buffer[1] == 48)
            {
                Random rand = new Random();
                int temp = rand.Next(20, 30);
                GetState getState = new GetState(temp, temp, temp, temp, temp, temp, temp, temp, temp, temp, temp, temp, (byte)temp, (byte)temp, (byte)temp, (byte)temp, (ushort)temp, (byte)temp);
                int size = Marshal.SizeOf(getState);
                byte[] byteArray = new byte[size];
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(getState, ptr, true);
                Marshal.Copy(ptr, byteArray, 0, size);
                Marshal.FreeHGlobal(ptr);
                stream.Write(byteArray, 0, size);
            }
            else if (buffer[0] == 4 && buffer[1] == 32)
            {
                //speedMult++;
                ////speedMult = (speedMult == 100) ? 0 : speedMult;
                //speedMult = 50;
                //SetSpeedMultInput setSpeedMultInput = new SetSpeedMultInput(speedMult);
                SetSpeedMultAnswer setSpeedMultOutput = new SetSpeedMultAnswer();
                int size = Marshal.SizeOf(setSpeedMultOutput);
                byte[] byteArray = new byte[64];
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(setSpeedMultOutput, ptr, true);
                Marshal.Copy(ptr, byteArray, 0, size);
                Marshal.FreeHGlobal(ptr);
                stream.Write(byteArray, 0, 64);
            }
            string hexString = BitConverter.ToString(buffer);
           // Console.WriteLine($"Response sent : {hexString}");
        }
       
        // Close client connection
        client.Close();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    // Stop listening for client requests
    listener.Stop();
    Console.WriteLine("Server stopped.");
}
