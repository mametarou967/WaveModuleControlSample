using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WaveModuleControlSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serialPort = new SerialPort
            {
                PortName = "COM10",                    //ポート番号
                BaudRate = 115200,                   //ボーレート
                DataBits = 8,                      //データビット
                Parity = Parity.None,              //パリティ
                StopBits = StopBits.One,           //ストップビット
                Handshake = Handshake.None,
                Encoding = Encoding.UTF8,          //エンコード
                WriteTimeout = 100000,             //書き込みタイムアウト
                ReadTimeout = 100000,              //読み取りタイムアウト
                NewLine = "\r\n"                   //改行コード指定
            };

            serialPort.Open();

            string inputKey = null;

            while (true)
            {
                inputKey = Console.ReadLine();
                if (inputKey[0] == 'p')
                {
                    const string playCommand = "AT+PLAY";
                    if (inputKey.Length == 2) serialPort.WriteLine($"{playCommand}={inputKey[1]}");
                    if (inputKey.Length > 2) serialPort.WriteLine($"{playCommand}={inputKey[1]}{inputKey[2]}");
                }
                else if (inputKey[0] == 'v')
                {
                    const string volumeConfigCommand = "AT+VOLCONF";
                    if (inputKey.Length == 2) serialPort.WriteLine($"{volumeConfigCommand}={inputKey[1]}");
                    if (inputKey.Length > 2) serialPort.WriteLine($"{volumeConfigCommand}={inputKey[1]}{inputKey[2]}");
                }
                else if (inputKey == "quit")
                {
                    break;
                }
            }
        }
    }
}
