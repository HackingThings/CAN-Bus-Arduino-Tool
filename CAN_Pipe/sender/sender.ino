// demo: CAN-BUS Shield, send data
#include <mcp_can.h>
#include <SPI.h>

// the cs pin of the version after v1.1 is default to D9
// v0.9b and v1.0 is default D10
const int SPI_CS_PIN = 9;
const int ledHIGH    = 1;
const int ledLOW     = 0;

MCP_CAN CAN(SPI_CS_PIN);                                    // Set CS pin

void setup()
{
    Serial.begin(115200);

    while (CAN_OK != CAN.begin(CAN_500KBPS))              // init can bus : baudrate = 500k
    {
        Serial.println("CAN BUS Shield init fail");
        Serial.println(" Init CAN BUS Shield again");
        delay(100);
    }
    Serial.println("CAN BUS Shield init ok!");
}

unsigned char stmp[8] = {ledHIGH, 1, 2, 3, ledLOW, 5, 6, 7};

void loop()
{   
    String readString = "";
    while (Serial.available() > 0)
    {
        delay(1);
        char recieved = Serial.read();
        if (recieved!=' ') readString += recieved; 
        // Process message when new line character is recieved
        if (recieved == '\n')
        {
            int addr =0;
            //Parse address to bytes
            int marker = readString.indexOf(',');
            //Serial.print(readString.substring(0,marker));
            addr = (int)strtol(readString.substring(0,marker).c_str(), 0, 16);
            //Serial.println(addr); 
            String dataString = readString.substring(readString.indexOf(',')+1);
            byte data[dataString.length()-1]; //-1 bacause of \n
            for (int i=0; i<dataString.length()-1; i++)
            {
                //parse rest of data to bytes
                char c = dataString[i];
                data[i]= htoi(c);
            }
            CAN.sendMsgBuf(addr,0, dataString.length()-1, data);
            Serial.println(addr+","+dataString);
            readString = ""; // Clear recieved buffer
        }
    }
}
int htoi (char c) {  //does not check that input is valid
   if (c<='9')
       return c-'0';
   if (c<='F')
       return c-'A'+10;
   if (c<='f')
       return c-'a'+10;
   return 0;
}
/*********************************************************************************************************
  END FILE
*********************************************************************************************************/
