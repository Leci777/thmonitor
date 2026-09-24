namespace THProjectMain
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.panelLine = new System.Windows.Forms.Panel();
            this.panelMeter = new System.Windows.Forms.Panel();
            this.thMeter_T = new MycontrolsTandHtest.THMeter();
            this.thMeter_H = new MycontrolsTandHtest.THMeter();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_H = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_T = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_slaveId = new System.Windows.Forms.NumericUpDown();
            this.cmb_BaudRate = new System.Windows.Forms.ComboBox();
            this.cmb_ProtName = new System.Windows.Forms.ComboBox();
            this.btn_OpenandClose = new System.Windows.Forms.Button();
            this.lb_Status = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer_Read = new System.Windows.Forms.Timer(this.components);
            this.panelTop.SuspendLayout();
            this.panelMeter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slaveId)).BeginInit();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lbl_Title);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(700, 54);
            this.panelTop.TabIndex = 11;
            //
            // lbl_Title
            //
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(700, 54);
            this.lbl_Title.TabIndex = 10;
            this.lbl_Title.Text = "温湿度实时监测系统";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelLine
            //
            this.panelLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.panelLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLine.Location = new System.Drawing.Point(0, 54);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(700, 3);
            this.panelLine.TabIndex = 12;
            //
            // panelMeter
            //
            this.panelMeter.BackColor = System.Drawing.Color.White;
            this.panelMeter.Controls.Add(this.thMeter_H);
            this.panelMeter.Controls.Add(this.thMeter_T);
            this.panelMeter.Controls.Add(this.label1);
            this.panelMeter.Controls.Add(this.label3);
            this.panelMeter.Controls.Add(this.lb_H);
            this.panelMeter.Controls.Add(this.lb_T);
            this.panelMeter.Controls.Add(this.label4);
            this.panelMeter.Controls.Add(this.label5);
            this.panelMeter.Location = new System.Drawing.Point(24, 76);
            this.panelMeter.Name = "panelMeter";
            this.panelMeter.Size = new System.Drawing.Size(330, 340);
            this.panelMeter.TabIndex = 13;
            //
            // thMeter_T
            //
            this.thMeter_T.Location = new System.Drawing.Point(200, 25);
            this.thMeter_T.MaxValue = 70D;
            this.thMeter_T.Name = "thMeter_T";
            this.thMeter_T.SetBackColor = MycontrolsTandHtest.ColorBack.Red;
            this.thMeter_T.SetHTValue = 0D;
            this.thMeter_T.Size = new System.Drawing.Size(82, 225);
            this.thMeter_T.TabIndex = 1;
            //
            // thMeter_H
            //
            this.thMeter_H.Location = new System.Drawing.Point(40, 25);
            this.thMeter_H.MaxValue = 70D;
            this.thMeter_H.Name = "thMeter_H";
            this.thMeter_H.SetBackColor = MycontrolsTandHtest.ColorBack.Green;
            this.thMeter_H.SetHTValue = 0D;
            this.thMeter_H.Size = new System.Drawing.Size(95, 225);
            this.thMeter_H.TabIndex = 0;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(67, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "湿度";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(220, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "温度";
            //
            // lb_H
            //
            this.lb_H.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lb_H.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_H.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lb_H.Location = new System.Drawing.Point(40, 278);
            this.lb_H.Name = "lb_H";
            this.lb_H.Size = new System.Drawing.Size(80, 34);
            this.lb_H.TabIndex = 2;
            this.lb_H.Text = "0";
            this.lb_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(122, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "％";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(280, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "°C";
            //
            // lb_T
            //
            this.lb_T.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.lb_T.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_T.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lb_T.Location = new System.Drawing.Point(200, 278);
            this.lb_T.Name = "lb_T";
            this.lb_T.Size = new System.Drawing.Size(80, 34);
            this.lb_T.TabIndex = 2;
            this.lb_T.Text = "0";
            this.lb_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // groupBox1
            //
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.nud_slaveId);
            this.groupBox1.Controls.Add(this.cmb_BaudRate);
            this.groupBox1.Controls.Add(this.cmb_ProtName);
            this.groupBox1.Controls.Add(this.btn_OpenandClose);
            this.groupBox1.Controls.Add(this.lb_Status);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.groupBox1.Location = new System.Drawing.Point(378, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 340);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备连接";
            //
            // nud_slaveId
            //
            this.nud_slaveId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.nud_slaveId.Location = new System.Drawing.Point(115, 145);
            this.nud_slaveId.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.nud_slaveId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_slaveId.Name = "nud_slaveId";
            this.nud_slaveId.Size = new System.Drawing.Size(160, 29);
            this.nud_slaveId.TabIndex = 5;
            this.nud_slaveId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // cmb_BaudRate
            //
            this.cmb_BaudRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.cmb_BaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_BaudRate.FormattingEnabled = true;
            this.cmb_BaudRate.Location = new System.Drawing.Point(115, 95);
            this.cmb_BaudRate.Name = "cmb_BaudRate";
            this.cmb_BaudRate.Size = new System.Drawing.Size(160, 31);
            this.cmb_BaudRate.TabIndex = 4;
            //
            // cmb_ProtName
            //
            this.cmb_ProtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.cmb_ProtName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_ProtName.FormattingEnabled = true;
            this.cmb_ProtName.Location = new System.Drawing.Point(115, 45);
            this.cmb_ProtName.Name = "cmb_ProtName";
            this.cmb_ProtName.Size = new System.Drawing.Size(160, 31);
            this.cmb_ProtName.TabIndex = 4;
            //
            // btn_OpenandClose
            //
            this.btn_OpenandClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(83)))));
            this.btn_OpenandClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OpenandClose.FlatAppearance.BorderSize = 0;
            this.btn_OpenandClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OpenandClose.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OpenandClose.ForeColor = System.Drawing.Color.White;
            this.btn_OpenandClose.Location = new System.Drawing.Point(45, 252);
            this.btn_OpenandClose.Name = "btn_OpenandClose";
            this.btn_OpenandClose.Size = new System.Drawing.Size(150, 50);
            this.btn_OpenandClose.TabIndex = 3;
            this.btn_OpenandClose.Text = "连 接 设 备";
            this.btn_OpenandClose.UseVisualStyleBackColor = false;
            this.btn_OpenandClose.Click += new System.EventHandler(this.btn_OpenandClose_Click);
            //
            // lb_Status
            //
            this.lb_Status.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lb_Status.Location = new System.Drawing.Point(205, 252);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(50, 50);
            this.lb_Status.TabIndex = 2;
            this.lb_Status.Text = "●";
            this.lb_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(25, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "站地址：";
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(25, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 24);
            this.label8.TabIndex = 2;
            this.label8.Text = "波特率：";
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(25, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "端口号：";
            //
            // timer_Read
            //
            this.timer_Read.Interval = 1000;
            this.timer_Read.Tick += new System.EventHandler(this.timer_Read_Tick);
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(700, 436);
            this.Controls.Add(this.panelMeter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelLine);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "温湿度实时监测系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.panelTop.ResumeLayout(false);
            this.panelMeter.ResumeLayout(false);
            this.panelMeter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slaveId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.Panel panelMeter;
        private System.Windows.Forms.Label lbl_Title;
        private MycontrolsTandHtest.THMeter thMeter_H;
        private MycontrolsTandHtest.THMeter thMeter_T;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_H;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_T;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nud_slaveId;
        private System.Windows.Forms.ComboBox cmb_BaudRate;
        private System.Windows.Forms.ComboBox cmb_ProtName;
        private System.Windows.Forms.Button btn_OpenandClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Timer timer_Read;
    }
}
