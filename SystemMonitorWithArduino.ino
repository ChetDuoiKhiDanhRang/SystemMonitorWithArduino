#include <SPI.h>;
#include <Adafruit_GFX.h>;
#include <Adafruit_PCD8544.h>;
#include <avr/pgmspace.h>;

#include <Ethernet.h>
#include <EthernetClient.h>
#include <EthernetServer.h>

#define GND 7
#define LED 6
#define VCC 5
#define SCLK 4
#define DIN 3
#define DC 2
#define CS 1
#define RST 0


//IPAddress gateway(192, 168, 1, 1);
//IPAddress subnet(255, 255, 255, 0);

byte macArduino[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };       //Arduino MAC address
IPAddress ipArduino(192, 168, 1, 177);                            //IP tĩnh đặt cho Arduino - truy cập thông tin qua html

//MAC address của card mạng máy tính - dùng cho Wake On LAN (WOL - copy từ phần mềm trên PC và thay thế vào đây)
byte macComputer[] = {0xF4 , 0x8E , 0x38 , 0x9F , 0x09 , 0x64}; //INS3650
//byte macComputer[] = {0xA0 , 0xB3 , 0xCC , 0xE6 , 0xF5 , 0xC1}; //Webserver
//byte macComputer[] = {0x00 , 0x1E , 0x0B , 0x2C , 0x8F , 0x2F}; //HPXW4400
//byte macComputer[] = {0x20 , 0x47 , 0x47 , 0x1C , 0xB1 , 0x92}; //DELL Laptop
//byte macComputer[] = {0x00 , 0x26 , 0x22 , 0x58 , 0x00 , 0xB7}; //Acer Laptop

IPAddress ipComputer(192, 168, 1, 9);                             //IP máy tính
int ComputerPORT = 2401;                                          //Port giao tiếp trên máy tính
IPAddress ipBroadcast(255, 255, 255, 255);                        //Địa chỉ broadcast, dùng cho WOL


byte MGPackage[102]; //WOL package


int PowerSensor = 12;                                             //Chân Arduino theo dõi trạng thái điện lưới
bool PowerSource = false;                                         //trạng thái điện lưới, false - OFF, true - ON

bool connected2Computer = true;                                   //Trạng thái kết nối tới máy tính
char dataReceive[20] = {"[   ][   ][   ][   ]"};                  // 5 bytes cho mỗi trường dữ liệu x 4.


//html server;
EthernetServer server(80);

//LCD NOKIA 5110
Adafruit_PCD8544 lcd5110 = Adafruit_PCD8544(SCLK, DIN, DC, CS, RST);

static const unsigned char PROGMEM logo[] =
{
B01111111, B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00011111, B11100000,
B11110000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B11110000,
B11000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00110000,
B11000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00110000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00111000, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B01100100, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000001, B10001000, B00000000, B00000000, B00010000,
B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000011, B00010000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000100, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00001000, B01000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B00001111, B00000000, B00010000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B00010001, B00000000, B00100001, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000001, B00100001, B00000000, B01100010, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000001, B01000001, B00000000, B01000100, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000001, B10000001, B00000000, B11001000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000011, B00000010, B00000000, B10100000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000011, B00000110, B00000001, B10000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000010, B00000100, B00000011, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000110, B00001000, B00000101, B00110000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000100, B00010000, B00000001, B01010000, B00000000, B00000000, B00000111, B11100000,
B00000000, B00000000, B00000000, B00000100, B00010000, B00010001, B10100000, B00000000, B00001111, B11111000, B00000000,
B00000000, B00000000, B00000000, B00001000, B00100011, B00100001, B11000000, B00011111, B11110000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00001000, B00101111, B10000000, B01111111, B11100000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00010000, B00110111, B00111111, B11000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00010000, B00011111, B11000000, B10000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00111111, B11100100, B00000000, B10000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00011111, B11100000, B00001001, B00000001, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00011111, B11100000, B00000000, B00011000, B01000001, B00000000, B00000000, B00000000, B00000000, B00000000,
B00001111, B11100000, B00000000, B00000000, B00101000, B00100010, B00000000, B00000000, B00000000, B00000000, B00000000,
B01110000, B00000000, B00000000, B00000000, B01010000, B00010010, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B01010000, B00001010, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B10010000, B00001100, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B10100000, B00001100, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B10100000, B00011000, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B01000000, B00001000, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000,
B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00010000,
B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00010000,
B11000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00110000,
B11000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00110000,
B11110000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B11110000,
B01111111, B10000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00000000, B00011111, B11100000,
};



static const unsigned char PROGMEM line[] = { B01111111, B11111111, B11111111, B11111111, B11111111, B11111111, B11111111, B11111111, B11111111, B11111111, B11100000 };


static const unsigned char PROGMEM CPU[] =
{
  B00000000, B00000000,
  B00000101, B10100000,
  B00000101, B10100000,
  B00011111, B11111000,
  B00011111, B11111000,
  B01111000, B00011110,
  B00011011, B11011000,
  B01111011, B11011110,
  B01111011, B11011110,
  B00011011, B11011000,
  B01111000, B00011110,
  B00011111, B11111000,
  B00011111, B11111000,
  B00000101, B10100000,
  B00000101, B10100000,
  B00000000, B00000000,
};

static const unsigned char PROGMEM RAM[] =
{
  B00000000, B00000000,
  B00000000, B00000000,
  B00000000, B00000000,
  B00000000, B00000000,
  B01111111, B11111110,
  B01010101, B10101010,
  B01010101, B10101010,
  B01010101, B10101010,
  B01110111, B11101110,
  B01110111, B11101110,
  B01111111, B11111110,
  B01111111, B11111110,
  B00000000, B00000000,
  B00000000, B00000000,
  B00000000, B00000000,
  B00000000, B00000000,
};

void setup()
{
  //initial lcd
  pinMode(GND, OUTPUT);
  pinMode(VCC, OUTPUT);
  pinMode(LED, OUTPUT);
  pinMode(PowerSensor, INPUT);

  digitalWrite(GND, LOW);
  digitalWrite(VCC, HIGH);
  digitalWrite(LED, HIGH); //LED on/off


  lcd5110.begin();
  lcd5110.setContrast(60);
  lcd5110.clearDisplay();
  lcd5110.drawBitmap(0, 0, logo, 84, 48, 1);
  lcd5110.display();
  delay(2000);

  lcd5110.clearDisplay();
  lcd5110.drawBitmap(0, 3, CPU, 16, 16, 1); //CPU icon
  lcd5110.setCursor(16, 2);
  lcd5110.print("Load:");
  lcd5110.setCursor(16, 12);
  lcd5110.print("Temp:");

  lcd5110.drawBitmap(0, 24, line, 84, 1, 1);
  lcd5110.drawBitmap(0, 25, line, 84, 1, 1);

  lcd5110.drawBitmap(0, 30, RAM, 16, 16, 1);//RAM icon
  lcd5110.setCursor(16, 30);
  lcd5110.print("Used:");
  lcd5110.setCursor(16, 40);
  lcd5110.print("Free:");
  lcd5110.display();

  Ethernet.begin(macArduino, ipArduino);//, gateway, subnet);
  server.begin();
  delay(500);
  digitalWrite(LED, LOW); //LED on/off
}

void loop()
{  
  PowerSource = (digitalRead(PowerSensor) == HIGH); 

  EthernetClient client;  
  client.connect(ipComputer, ComputerPORT);

  //báo trạng thái nguồn điện lưới về máy tính=====
  connected2Computer = false;
  if (client.connected())
  {
    connected2Computer = true;
    byte powerbyte = 0xFF;
    if (PowerSource)
    {
      digitalWrite(LED, LOW);
      powerbyte = 0xFF;
    }
    else
    {
      digitalWrite(LED, HIGH);
      powerbyte = 0x00;
    }
    client.write(powerbyte);
  }
  //-----------------------------------------------
  
  delay(10);
  //Nhận thông tin trạng thái CPU và RAM===========
  if (client.available())
  {
    for (int i = 0; i < 20; i++)
    {
      dataReceive[i] = char(client.read());
    }
  }
  client.stop();
  //-----------------------------------------------

  //Send wake on lan===============================
  if ((PowerSource) & (!connected2Computer))
  {
    //int j;
    for (int i = 0; i < 102; i++)
    {
      if (i < 6)
      {
        MGPackage[i] = 0xFF;
      }
      else
      {
        MGPackage[i] = macComputer[i % 6];
      }
    }
    
    EthernetUDP sender;
    sender.begin(ComputerPORT);
    sender.beginPacket(ipBroadcast, ComputerPORT);
    sender.write(MGPackage, 102);
    sender.endPacket();
    sender.stop();
  }
  //-----------------------------------------------

  //Erase pixels (old value)=======================
  for (int i = 46; i < 84; i++)
  {
    for (int j = 2; j < 48; j++)
    {
      lcd5110.drawPixel(i, j, 0);
    }
  }
  //-----------------------------------------------

  //Display new values=============================
  //Display CPU Load
  lcd5110.setCursor(46, 2);
  for (int i = 0; i < 5; i++)
  {
    lcd5110.print(dataReceive[i]);
  }
  lcd5110.println("%");

  //Display CPU Temp
  lcd5110.setCursor(46, 12);
  for (int i = 5; i < 10; i++)
  {
    lcd5110.print(dataReceive[i]);
  }
  lcd5110.println("C");

  lcd5110.drawBitmap(0, 24, line, 84, 1, 1);
  lcd5110.drawBitmap(0, 25, line, 84, 1, 1);

  //Display RAM Used
  lcd5110.setCursor(46, 30);
  for (int i = 10; i < 15; i++)
  {
    lcd5110.print(dataReceive[i]);
  }
  lcd5110.println("G");

  //Display RAM Avai
  lcd5110.setCursor(46, 40);
  for (int i = 15; i < 20; i++)
  {
    lcd5110.print(dataReceive[i]);
  }
  lcd5110.println("G");

  lcd5110.display();
  //-----------------------------------------------


  //truy cập thông tin qua html====================
  EthernetClient webclient;
  webclient = server.available();
  if (webclient)
  {
    webclient.println("HTTP/1.1 200 OK");
    webclient.println("Content-Type: text/html charset=utf-8");
    webclient.println("Connection: close");
    webclient.println("Refresh: 5");
    webclient.println();
    webclient.println("<!DOCTYPE HTML>");
    webclient.println("<html>");
    webclient.print("<font face =\"Consolas\">");
    webclient.print("<p align=\"center\">www.lce.edu.vn</p>");

    if (connected2Computer)
    {
      //Table and header
      webclient.print("<table align=\"center\" border=\"1\">");
      webclient.print("<tr>");
      webclient.print("<th>Property</th><th>Value</th>");
      webclient.print("</tr>");
      //------------

      //CPU Load row
      webclient.print("<tr>");
      webclient.print("<td>CPU Load</td>");
      webclient.print("<td>");
      for (int i = 0; i < 5; i++)
      {
        webclient.print(dataReceive[i]);
      }
      webclient.print(" % ");
      webclient.print("</td >");
      webclient.print("</tr>");
      //------------

      //CPU Temperature row
      webclient.print("<tr>");
      webclient.print("<td>CPU Temperature</td>");
      webclient.print("<td>");
      for (int i = 5; i < 10; i++)
      {
        webclient.print(dataReceive[i]);
      }
      webclient.print(" <sup>o</sup>C");
      webclient.print("</td>");
      webclient.print("</tr>");
      //------------

      //RAM Used row
      webclient.print("<tr>");
      webclient.print("<td>RAM Used</td>");
      webclient.print("<td>");
      for (int i = 10; i < 15; i++)
      {
        webclient.print(dataReceive[i]);
      }
      webclient.print(" GB");
      webclient.print("</td>");
      webclient.print("</tr>");
      //------------

      //RAM Available row
      webclient.print("<tr>");
      webclient.print("<td>RAM Available</td>");
      webclient.print("<td>");
      for (int i = 15; i < 20; i++)
      {
        webclient.print(dataReceive[i]);
      }
      webclient.print(" GB");
      webclient.print("</td>");
      webclient.print("</tr>");
      //------------


      webclient.print("</table>");
    }
    else
    {
      webclient.print("<p align=\"center\"><b>Computer has been shutdown</b></p>");
    }
    webclient.print("</table></font></html>");
  }
  webclient.stop();
  //-----------------------------------------------
  delay(50);
}
