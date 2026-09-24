using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Threading;

namespace ModbusBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 创建串口对象
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = "COM5";
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            // 无限循环：一直重复【打开串口→发报文→读数据→关闭串口】，每轮间隔3秒
            while (true) 
            {
                Thread.Sleep(3000);

                serialPort.Open();// 打开串口通道

                // 2.组装Modbus RTU 03功能码报文
                // 读取从站1号，起始地址0，读取2个寄存器（温度、湿度）
                List<byte> sendByte = new List<byte>();
                sendByte.Add(0x01);
                sendByte.Add(0x03);
                sendByte.Add(0x00);
                sendByte.Add(0x00);
                sendByte.Add(0x00);
                sendByte.Add(0x02);
                sendByte.Add(0xC4);
                sendByte.Add(0x0B);

                // 3.把 List 集合里面的 Modbus 报文，转成字节数组，通过串口发送出去。
                // 从集合的第 0 号位置（第一个字节）开始发,集合用Count
                serialPort.Write(sendByte.ToArray(), 0, sendByte.Count);

                // 暂停100ms，留给下位机时间回复数据
                Thread.Sleep(1000);

                // 获取串口缓冲区收到多少字节
                int len = serialPort.BytesToRead;
                // 创建数组存放接收数据
                byte[] recelveBytes = new byte[len];
                // 读取字节到数组
                serialPort.Read(recelveBytes, 0, recelveBytes.Length);
                // 判断收到报文第一个字节是不是从站ID=1
                if (recelveBytes[0] == 0x01)
                {
                    StringBuilder result = new StringBuilder();
                    // 高字节*256 + 低字节，拼接16位寄存器原始值
                    double humidity = recelveBytes[3] * 256 + recelveBytes[4];
                    double temperature = recelveBytes[5] * 256 + recelveBytes[6];
                    // 原始值乘0.1得到真实温湿度
                    Console.WriteLine($"\r湿度为：{humidity * 0.1}%，温度为{temperature * 0.1}°C");
                    // 循环打印收到的所有字节（十进制），后面加上x2则表示输出十六进制字符串
                    foreach (var item in recelveBytes)
                    {
                        result.Append(item + " ");
                        Console.Write($"{item} ");
                    }
                }
                // 关闭串口，本轮结束
                serialPort.Close();
            }

            //Console.ReadLine();
        }
    }
}
