using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;

namespace _2da_parte_del_proyecto
{


    class Program
    {
        static SerialPort Arduino = new SerialPort("COM5", 9600);
        static void Main(string[] args)
        {
            //Nelly Odette Pérez Osoy, Caroline Mishell Saquic Rodas, Khaterine Jazmín Yanes Alvarado, Diego Pablo Huertas Guitierrez 
            //perdonenos la vida profe pero ni a fuerza se repite :c
            int e;

            Arduino.Open();
            Console.WriteLine("LUCESITA");
            Console.WriteLine("1. encender lucesita");
            Console.WriteLine("2. apagar lucesita");
            e = Convert.ToInt32(Console.ReadLine());
            while (e!=3)
            {
                if (Arduino.IsOpen) ;
            }

            while (e != 4)
            {
                if (Arduino.IsOpen)
                {


                    if (e == 1)
                    {
                        Console.WriteLine(("encendida"), Console.ForegroundColor = ConsoleColor.Yellow);
                        byte[] data = Encoding.ASCII.GetBytes("e");
                        Arduino.Write(data, 0, data.Length);
                        break;
                    }

                    else if (e == 2)
                    {
                        Console.WriteLine(("apagada"), Console.ForegroundColor = ConsoleColor.Yellow);
                        byte[] data = Encoding.ASCII.GetBytes("a");
                        Arduino.Write(data, 0, data.Length);
                        Arduino.Close();
                        //Console.WriteLine("apagada");
                    }



                }
                else
                {
                    break;

                }
            }


            Console.ReadKey();
        }
    }
}
    

