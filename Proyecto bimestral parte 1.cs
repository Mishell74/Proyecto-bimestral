using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_bimestral
{

    class Program
    {
        static void Main(string[] args)
        {
            using System;

# include <SPI.h>
# include <Ethernet.h>  

            byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
            IPAddress ip();// informacion del arduino
            EthernetServer server(80);

            int led = ;//informacion de la led  
            String estado = "OFF";

            void setup()
            {
                Serial.begin(9600);


                Ethernet.begin(mac, ip);
                server.begin();
                Serial.print("server is at ");
                Serial.println(Ethernet.localIP());

                pinMode(led, OUTPUT);
            }

            void loop()
            {
                EthernetClient client = server.available();

                if (client)
                {
                    Serial.println("new client");
                    boolean currentLineIsBlank = true;
                    String cadena = "";
                    while (client.connected())
                    {
                        if (client.available())
                        {
                            char x = client.read();
                            Serial.write(x);
                            cadena.concat(x);
                            int posicion = cadena.indexOf("LED=");

                            if (cadena.substring(posicion) == "LED=ON")
                            {
                                digitalWrite(led, HIGH);
                                estado = "ON";
                            }
                            if (cadena.substring(posicion) == "LED=OFF")
                            {
                                digitalWrite(led, LOW);
                                estado = "OFF";
                            }


                            if (x == '\n' && currentLineIsBlank)
                            {


                                client.println("HTTP/1.1 200 OK");
                                client.println("Content-Type: text/html");
                                client.println();
                                client.println("<html>");
                                client.println("<head>");
                                client.println("</head>");
                                client.println("<body>");
                                client.println("<h1 align='center'>DIYMakers</h1><h3 align='center'>LED controlado por Servidor Web con Arduino</h3>");
                                client.println("<div style='text-align:center;'>");
                                client.println("<button onClick=location.href='./?LED=ON\' style='margin:auto;background-color: #84B1FF;color: snow;padding: 10px;border: 1px solid #3F7CFF;width:65px;'>");
                                client.println("ON");
                                client.println("</button>");
                                client.println("<button onClick=location.href='./?LED=OFF\' style='margin:auto;background-color: #84B1FF;color: snow;padding: 10px;border: 1px solid #3F7CFF;width:65px;'>");
                                client.println("OFF");
                                client.println("</button>");
                                client.println("<br /><br />");
                                client.println("<b>LED = ");
                                client.print(estado);
                                client.println("</b><br />");
                                client.println("</b></body>");
                                client.println("</html>");
                                break;
                            }
                            if (x == '\n')
                            {
                                currentLineIsBlank = true;
                            }
                            else if (x != '\r')
                            {
                                currentLineIsBlank = false;
                            }
                        }
                    }

                    delay(1);
                    client.stop();
                }
            }
        }
    }
}               Mishell Saquic;
                Katherine Jazmin
                Nelly Odette
                Diego Huertas
                 
 
