namespace ShortcutKeyRecord
{
    partial class Form1
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
            this.lbl_currentProcess = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_SKMap = new System.Windows.Forms.Label();
            this.lbl_SKText = new System.Windows.Forms.Label();
            this.lbl_SKGroupName = new System.Windows.Forms.Label();
            this.tb_SKMap = new System.Windows.Forms.TextBox();
            this.tb_SKText = new System.Windows.Forms.TextBox();
            this.btn_addSK = new System.Windows.Forms.Button();
            this.cb_SKProcessName = new System.Windows.Forms.ComboBox();
            this.cms_mouseBtnRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.始终置顶ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_t_close = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_mouseBtnRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_currentProcess
            // 
            this.lbl_currentProcess.AutoSize = true;
            this.lbl_currentProcess.Location = new System.Drawing.Point(13, 13);
            this.lbl_currentProcess.Name = "lbl_currentProcess";
            this.lbl_currentProcess.Size = new System.Drawing.Size(41, 12);
            this.lbl_currentProcess.TabIndex = 0;
            this.lbl_currentProcess.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.ContextMenuStrip = this.cms_mouseBtnRight;
            this.panel1.Location = new System.Drawing.Point(15, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 109);
            this.panel1.TabIndex = 1;
            // 
            // lbl_SKMap
            // 
            this.lbl_SKMap.AutoSize = true;
            this.lbl_SKMap.Location = new System.Drawing.Point(13, 430);
            this.lbl_SKMap.Name = "lbl_SKMap";
            this.lbl_SKMap.Size = new System.Drawing.Size(65, 12);
            this.lbl_SKMap.TabIndex = 2;
            this.lbl_SKMap.Text = "添加快捷键";
            // 
            // lbl_SKText
            // 
            this.lbl_SKText.AutoSize = true;
            this.lbl_SKText.Location = new System.Drawing.Point(49, 458);
            this.lbl_SKText.Name = "lbl_SKText";
            this.lbl_SKText.Size = new System.Drawing.Size(29, 12);
            this.lbl_SKText.TabIndex = 3;
            this.lbl_SKText.Text = "说明";
            // 
            // lbl_SKGroupName
            // 
            this.lbl_SKGroupName.AutoSize = true;
            this.lbl_SKGroupName.Location = new System.Drawing.Point(26, 402);
            this.lbl_SKGroupName.Name = "lbl_SKGroupName";
            this.lbl_SKGroupName.Size = new System.Drawing.Size(53, 12);
            this.lbl_SKGroupName.TabIndex = 4;
            this.lbl_SKGroupName.Text = "特定程序";
            // 
            // tb_SKMap
            // 
            this.tb_SKMap.Location = new System.Drawing.Point(84, 427);
            this.tb_SKMap.Name = "tb_SKMap";
            this.tb_SKMap.Size = new System.Drawing.Size(188, 21);
            this.tb_SKMap.TabIndex = 5;
            // 
            // tb_SKText
            // 
            this.tb_SKText.Location = new System.Drawing.Point(84, 455);
            this.tb_SKText.Name = "tb_SKText";
            this.tb_SKText.Size = new System.Drawing.Size(188, 21);
            this.tb_SKText.TabIndex = 6;
            // 
            // btn_addSK
            // 
            this.btn_addSK.Location = new System.Drawing.Point(84, 482);
            this.btn_addSK.Name = "btn_addSK";
            this.btn_addSK.Size = new System.Drawing.Size(189, 23);
            this.btn_addSK.TabIndex = 8;
            this.btn_addSK.Text = "保存";
            this.btn_addSK.UseVisualStyleBackColor = true;
            this.btn_addSK.Click += new System.EventHandler(this.btn_addSK_Click);
            // 
            // cb_SKProcessName
            // 
            this.cb_SKProcessName.FormattingEnabled = true;
            this.cb_SKProcessName.Location = new System.Drawing.Point(85, 399);
            this.cb_SKProcessName.Name = "cb_SKProcessName";
            this.cb_SKProcessName.Size = new System.Drawing.Size(187, 20);
            this.cb_SKProcessName.TabIndex = 9;
            // 
            // cms_mouseBtnRight
            // 
            this.cms_mouseBtnRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.始终置顶ToolStripMenuItem,
            this.cms_t_close});
            this.cms_mouseBtnRight.Name = "cms_mouseBtnRight";
            this.cms_mouseBtnRight.Size = new System.Drawing.Size(125, 48);
            // 
            // 始终置顶ToolStripMenuItem
            // 
            this.始终置顶ToolStripMenuItem.CheckOnClick = true;
            this.始终置顶ToolStripMenuItem.Name = "始终置顶ToolStripMenuItem";
            this.始终置顶ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.始终置顶ToolStripMenuItem.Text = "始终置顶";
            // 
            // cms_t_close
            // 
            this.cms_t_close.Name = "cms_t_close";
            this.cms_t_close.Size = new System.Drawing.Size(124, 22);
            this.cms_t_close.Text = "关闭";
            this.cms_t_close.Click += new System.EventHandler(this.cms_t_close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 567);
            this.ContextMenuStrip = this.cms_mouseBtnRight;
            this.ControlBox = false;
            this.Controls.Add(this.cb_SKProcessName);
            this.Controls.Add(this.btn_addSK);
            this.Controls.Add(this.tb_SKText);
            this.Controls.Add(this.tb_SKMap);
            this.Controls.Add(this.lbl_SKGroupName);
            this.Controls.Add(this.lbl_SKText);
            this.Controls.Add(this.lbl_SKMap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_currentProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cms_mouseBtnRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_currentProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_SKMap;
        private System.Windows.Forms.Label lbl_SKText;
        private System.Windows.Forms.Label lbl_SKGroupName;
        private System.Windows.Forms.TextBox tb_SKMap;
        private System.Windows.Forms.TextBox tb_SKText;
        private System.Windows.Forms.Button btn_addSK;
        private System.Windows.Forms.ComboBox cb_SKProcessName;
        private System.Windows.Forms.ContextMenuStrip cms_mouseBtnRight;
        private System.Windows.Forms.ToolStripMenuItem 始终置顶ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cms_t_close;
    }
}

