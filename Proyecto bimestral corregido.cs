using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Proyecto_bismestral_correjido_1
{
    class Program
    {
        static SerialPort Arduino = new SerialPort("COM27", 9600);
        static void Main(string[] args)
        {
            Arduino.Parity = Parity.None;
            Arduino.StopBits = StopBits.One;
            Arduino.DataBits = 8;
            Arduino.Handshake = Handshake.None;
            Arduino.RtsEnable = true;

            Arduino.Open();
            
            if (Arduino.IsOpen)
            {
                Console.WriteLine("com abierto");
                byte[] data = Encoding.ASCII.GetBytes("o");
                Arduino.Write(data, 0, data.Length);
                byte[] datal = Encoding.ASCII.GetBytes("h");
                Arduino.Write(datal, 0, datal.Length);

            }
            else
            {
                Console.WriteLine("com cerrado");
            }
            Console.ReadKey();
        }
    }
}  /*Mishell Saquic
    *Katherine Jazmin
    *Nelly Pérez
    *Diego Huertas
    */
