using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace THProjectMain
{
    public partial class FrmMain : Form
    {
        ModbusRTULib.ModbusRTU modbusRTU=new ModbusRTULib.ModbusRTU();
        public FrmMain()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            string[] allBaudRate = new string[]
            {
                "2400",
                "4800",
                "9600",
                "19200",
                "38400",
                "57600",
                "115200"
            };
            this.cmb_BaudRate.Items.AddRange(allBaudRate);
            //默认选中9600（数组下标2）
            this.cmb_BaudRate.SelectedIndex = 2;
            //获取电脑当前可用端口号
            this.cmb_ProtName.DataSource=SerialPort.GetPortNames();
            // 温湿度计量程不同：湿度0~100%，温度0~50°C
            this.thMeter_H.MaxValue = 100;
            this.thMeter_T.MaxValue = 50;
        }
        private bool _isConnected=false;
        public bool IsConnected
        {
            get { return _isConnected; }
            set 
            {
                _isConnected = value;
                if (value)
                {
                    this.btn_OpenandClose.Text = "断 开 连 接";
                    this.btn_OpenandClose.BackColor = Color.FromArgb(220, 53, 69);
                    this.btn_OpenandClose.ForeColor = Color.White;
                    this.lb_Status.ForeColor = Color.Green;
                }
                else
                {
                    this.btn_OpenandClose.Text = "连 接 设 备";
                    this.btn_OpenandClose.BackColor = Color.FromArgb(33, 150, 83);
                    this.btn_OpenandClose.ForeColor = Color.White;
                    this.lb_Status.ForeColor = Color.Red;
                }
            }
        }
        //打开和关闭连接按钮
        private void btn_OpenandClose_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                try
                {
                    this.timer_Read.Start();
                    modbusRTU.Connect(cmb_ProtName.Text,Convert.ToInt32(cmb_BaudRate.Text));
                    // 设置连接状态，自动刷新界面样式
                    IsConnected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.timer_Read.Stop();
                modbusRTU.DisConnect();
                IsConnected = false;
                this.lb_H.Text = "0";
                this.lb_T.Text = "0";
                this.thMeter_H.SetHTValue = 0;
                this.thMeter_T.SetHTValue = 0;
            }
        }

        private void timer_Read_Tick(object sender, EventArgs e)
        {
            try
            {
                //读取数据从0开始，两个数据
                byte[] result = modbusRTU.ReadHoldingRegister(Convert.ToByte(nud_slaveId.Value), 0, 2);
                if (result != null && result.Length == 4)
                {
                    int humidity = result[0] * 256 + result[1];
                    int temperature = result[2] * 256 + result[3];
                    this.lb_H.Text = (humidity * 0.1).ToString("F1");
                    this.lb_T.Text = (temperature * 0.1).ToString("F1");
                    this.thMeter_H.SetHTValue = humidity * 0.1;
                    this.thMeter_T.SetHTValue = temperature * 0.1;
                }
            }
            catch
            {
                // 读取异常不崩程序，静默跳过本次
            }
        }

        // 窗体关闭事件：停止定时器，防止后台继续读取串口
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer_Read.Stop();
            modbusRTU.DisConnect();
        }
    }
}
