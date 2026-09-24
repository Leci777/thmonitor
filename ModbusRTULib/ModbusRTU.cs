using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Threading;

namespace ModbusRTULib
{
    /// <summary>
    /// ModbusRTU串口通信帮助类
    /// 封装串口连接、断开，后续可扩展Modbus报文发送、CRC校验、寄存器读写功能
    /// </summary>
    public class ModbusRTU
    {
        #region 【字段】
        /// <summary>
        /// 串口通信实例对象，私有，外部不能直接访问
        /// </summary>
        private SerialPort serialPort = null;
        #endregion


        #region 【构造方法】
        /// <summary>
        /// 默认构造函数：接收延迟使用默认值100ms
        /// </summary>
        public ModbusRTU() { }
        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="receiveDelay">发送报文后，等待下位机应答的延迟时间(ms)</param>
        public ModbusRTU(int receiveDelay)
        {
            this.ReceiveDelay = receiveDelay;
        }
        #endregion


        #region 【属性】
        /// <summary>
        /// 私有后端字段：接收延迟时间，默认100毫秒
        /// </summary>
        private int _receiveDelay = 100;
        /// <summary>
        /// 发送报文后等待下位机返回数据的延迟时间(单位ms)
        /// 范围限制：最小10ms，最大5000ms；超出范围自动重置为默认100ms
        /// </summary>
        public int ReceiveDelay
        {
            get { return _receiveDelay; }
            set
            {
                if (value < 10 || value > 5000)
                {
                    _receiveDelay = 100;
                }
                else
                {
                    _receiveDelay = value;
                }
            }
        }
        #endregion


        /// <summary>
        /// 串口是否已连接（只读）
        /// </summary>
        public bool IsConnected
        {
            get { return serialPort != null && serialPort.IsOpen; }
        }


        #region【方法】
        /// <summary>
        /// 打开串口，建立通信连接
        /// </summary>
        /// <param name="portName">串口名称，例如：COM5</param>
        /// <param name="baudRate">波特率，默认9600</param>
        /// <param name="parity">校验位，默认无校验Parity.None</param>
        /// <param name="dataBits">数据位，默认8</param>
        /// <param name="stopBits">停止位，默认StopBits.One</param>
        /// <exception cref="Exception">串口打开失败时抛出异常</exception>
        public void Connect(string portName, int baudRate = 9600, Parity parity = Parity.None,
            int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            // 已打开就先关，防止重复连接导致端口占用
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("串口打开失败，原因：" + ex.Message);
            }
        }
        /// <summary>
        /// 关闭串口，断开通信连接，释放串口资源
        /// </summary>
        public void DisConnect()
        {
            // 判断串口对象不为空，并且串口当前处于打开状态才执行关闭
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        /// <summary>
        /// 读取保持寄存器 Modbus 03H功能码
        /// </summary>
        /// <param name="slaveID">从站设备ID(1~247)</param>
        /// <param name="startAddress">寄存器起始地址</param>
        /// <param name="count">读取寄存器数量</param>
        /// <returns>成功：返回原始字节数组，失败：返回null</param>
        public byte[] ReadHoldingRegister(byte slaveID, int startAddress, int count)
        {
            // Modbus RTU 请求报文固定长度8字节：
            // [从站ID][功能码][起始地址高][起始地址低][数量高][数量低][CRC低][CRC高]
            byte[] sendByte = new byte[8];
            sendByte[0] = slaveID;// 报文第0字节：从站地址
            sendByte[1] = 0x03;// 报文第1字节：功能码03，读取保持寄存器
            //起始寄存器和寄存器数量转成16进制
            sendByte[2] = (byte)(startAddress / 256);
            sendByte[3] = (byte)(startAddress % 256);
            sendByte[4] = (byte)(count / 256);
            sendByte[5] = (byte)(count % 256);
            byte[] crc = CRC16(sendByte, 6);//封装crc校验校验前面6位
            sendByte[6] = crc[0];
            sendByte[7] = crc[1];
            byte[] receiveBytes = null;
            try
            {
                // 清空接收缓冲区，防止上次残留数据干扰本次读取
                serialPort.DiscardInBuffer();
                serialPort.Write(sendByte, 0, sendByte.Length);
                // 轮询等待应答：每隔10ms检查缓冲区，收到足够字节或超时就继续
                int elapsed = 0;
                int expectedLen = 5 + 2 * count;
                while (serialPort.BytesToRead < expectedLen && elapsed < ReceiveDelay)
                {
                    Thread.Sleep(10);
                    elapsed += 10;
                }
                receiveBytes = new byte[serialPort.BytesToRead];
                serialPort.Read(receiveBytes, 0, receiveBytes.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("发送和应答报文出现问题，详情：" + ex.Message);
            }
            //03功能正常应答报文结构：[从站ID(1)][功能码(1)][数据长度(1)][寄存器数据(N)][CRC(2)]
            //总长度 = 5 + 2*寄存器数量
            int byteLength = 2 * count;
            if (receiveBytes != null && receiveBytes.Length == 5 + byteLength)
            {
                if (CheckCRC(receiveBytes) && receiveBytes[1] == 0x03)
                {
                    byte[] returnDataArray = new byte[byteLength];
                    Array.Copy(receiveBytes, 3, returnDataArray, 0, byteLength);
                    return returnDataArray;
                }
                else return null;
            }
            else return null;

        }
        #endregion

        #region  CRC校验【查表法，速度很快】

        private static readonly byte[] aucCRCHi = {
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40
         };
        private static readonly byte[] aucCRCLo = {
             0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
             0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
             0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
             0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
             0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
             0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
             0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
             0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38,
             0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
             0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
             0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
             0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
             0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB,
             0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
             0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
             0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
             0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
             0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
             0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
             0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
             0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
             0x41, 0x81, 0x80, 0x40
         };
        private byte[] CRC16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            byte[] res = new byte[2] { 0xFF, 0xFF };
            ushort iIndex;
            while (usLen-- > 0)
            {
                iIndex = (ushort)(res[0] ^ pucFrame[i++]);
                res[0] = (byte)(res[1] ^ aucCRCHi[iIndex]);
                res[1] = aucCRCLo[iIndex];
            }
            return res;
        }

        private bool CheckCRC(byte[] value)
        {
            if (value == null) return false;

            if (value.Length <= 2) return false;

            int length = value.Length;
            byte[] buf = new byte[length - 2];
            Array.Copy(value, 0, buf, 0, buf.Length);

            byte[] CRCbuf = CRC16(buf, buf.Length);
            if (CRCbuf[0] == value[length - 2] && CRCbuf[1] == value[length - 1])
            {
                return true;
            }
            return false;
        }



        #endregion
    }
}
