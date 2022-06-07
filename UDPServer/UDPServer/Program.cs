using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using EnergyLib;

namespace UDPServer{
    internal class Program{
        static void Main(string[] args){
                using (UdpClient socket = new UdpClient()){

                    socket.Client.Bind(new IPEndPoint(IPAddress.Any, 6000));

                    IPEndPoint clientEndPoint = null;
                    while (true){
                        string reply = "Result is ";

                        byte[] data = socket.Receive(ref clientEndPoint);

                        string message = Encoding.UTF8.GetString(data);

                        string[] values = message.Split(" ");
                        if (values.Length > 1){
                            double result;
                            double convertData = Convert.ToDouble(values[1]);
                            if (values[0] == "Joule"){
                                result = EnergyConverter.ToCalorie(convertData);
                                reply = "Result is " + result;
                            }

                            if (values[0] == "Calorie"){
                                result = EnergyConverter.ToJoule(convertData);
                                reply = "Result is " + result;
                            }

                        }


                        byte[] replyMessage = Encoding.UTF8.GetBytes(reply);
                        socket.Send(replyMessage, replyMessage.Length, clientEndPoint);

                    }
                }
            }
    }
}
