using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UdpSendor
{
    class Program
    {
        static void Main(string[] args)
        {
            // server IP address 
            UdpClient UdpSendor = new UdpClient("127.0.0.1", 9999);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            int number = 0;
            try
            {                
                while(true)
                {
                    Console.WriteLine("Insert your sentence!....");
                    string sentence = Console.ReadLine();
                    // here are I am converting my simple message into byte of stream
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("The number is " + sentence);
                    // Sending message part :..send bytes to host machine 
                    UdpSendor.Send(sendBytes, sendBytes.Length);

                    // Recieved bytes from host machine 
                    Byte[] recievedBytes = UdpSendor.Receive(ref iPEndPoint);
                    string rvdData = Encoding.ASCII.GetString(recievedBytes);
                    Console.WriteLine("The Data comes from Server" + rvdData);

                    number++;
                    Console.WriteLine(" " + number);
                    Thread.Sleep(100);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
