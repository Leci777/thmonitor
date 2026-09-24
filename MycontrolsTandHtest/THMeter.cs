using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MycontrolsTandHtest
{
    public partial class THMeter : UserControl
    {
        public THMeter()
        {
            InitializeComponent();
        }


        //【1】设置温湿度柱状显示和实际温湿度数值（属性）
        // 柱状条总高度（温度计有效区域像素高度）
        private int barHeight = 133;
        // 当前显示的数值
        private double _currentValue = 0;
        // 量程上限，温度和湿度可以设不同的值
        public double MaxValue { get; set; } = 70;
        // 对外暴露属性：设置/读取温湿度数值
        public double SetHTValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;
                // 超出范围就钳制到 0~MaxValue，不弹窗
                if (value < 0) value = 0;
                if (value > MaxValue) value = MaxValue;
                // 实际值对应的液柱高度
                double reValue = (barHeight / MaxValue) * value;
                // 白色遮罩label高度 = 总高度 - 液柱高度
                this.lblBar.Height = Convert.ToInt32(barHeight - reValue);
            }
        }
        //【2】设计温湿度计背景颜色（属性）
        //后台存储变量，用来记住当前选中的颜色状态
        private ColorBack _colorBack;
        public ColorBack SetBackColor
        {
            get { return _colorBack; }
            set
            {
                if (value == ColorBack.Green)
                {
                    this.panelBg.BackgroundImage = Properties.Resources.green_all;
                }
                else
                {
                    this.panelBg.BackgroundImage = Properties.Resources.red_all;
                }
                _colorBack = value;
            }
        }
    }
    //颜色枚举
    public enum ColorBack
    {
        Green,
        Red
    }
}
