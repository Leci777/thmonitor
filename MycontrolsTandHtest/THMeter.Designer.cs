namespace MycontrolsTandHtest
{
    partial class THMeter
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(THMeter));
            this.panelBg = new System.Windows.Forms.Panel();
            this.lblBar = new System.Windows.Forms.Label();
            this.panelBg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBg
            // 
            this.panelBg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBg.BackgroundImage")));
            this.panelBg.Controls.Add(this.lblBar);
            this.panelBg.Location = new System.Drawing.Point(3, 3);
            this.panelBg.Name = "panelBg";
            this.panelBg.Size = new System.Drawing.Size(73, 204);
            this.panelBg.TabIndex = 0;
            // 
            // lblBar
            // 
            this.lblBar.BackColor = System.Drawing.Color.White;
            this.lblBar.Location = new System.Drawing.Point(20, 24);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(9, 133);
            this.lblBar.TabIndex = 1;
            // 
            // THMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBg);
            this.Name = "THMeter";
            this.Size = new System.Drawing.Size(79, 210);
            this.panelBg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBg;
        private System.Windows.Forms.Label lblBar;
    }
}
