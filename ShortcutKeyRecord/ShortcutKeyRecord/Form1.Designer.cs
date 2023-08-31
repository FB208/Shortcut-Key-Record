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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_currentProcess = new System.Windows.Forms.Label();
            this.cms_mouseBtnRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_t_fixedTop = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_t_close = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_SKMap = new System.Windows.Forms.Label();
            this.lbl_SKText = new System.Windows.Forms.Label();
            this.lbl_SKGroupName = new System.Windows.Forms.Label();
            this.tb_SKMap = new System.Windows.Forms.TextBox();
            this.tb_SKText = new System.Windows.Forms.TextBox();
            this.btn_addSK = new System.Windows.Forms.Button();
            this.cb_SKProcessName = new System.Windows.Forms.ComboBox();
            this.pic_move = new System.Windows.Forms.PictureBox();
            this.gb_currentProcess = new System.Windows.Forms.GroupBox();
            this.p_currentProcess = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.p_allProcess = new System.Windows.Forms.Panel();
            this.cms_mouseBtnRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_move)).BeginInit();
            this.gb_currentProcess.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_currentProcess
            // 
            this.lbl_currentProcess.AutoSize = true;
            this.lbl_currentProcess.BackColor = System.Drawing.Color.Transparent;
            this.lbl_currentProcess.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_currentProcess.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_currentProcess.Location = new System.Drawing.Point(10, 333);
            this.lbl_currentProcess.Name = "lbl_currentProcess";
            this.lbl_currentProcess.Size = new System.Drawing.Size(55, 16);
            this.lbl_currentProcess.TabIndex = 0;
            this.lbl_currentProcess.Text = "label1";
            // 
            // cms_mouseBtnRight
            // 
            this.cms_mouseBtnRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_t_fixedTop,
            this.cms_t_close});
            this.cms_mouseBtnRight.Name = "cms_mouseBtnRight";
            this.cms_mouseBtnRight.Size = new System.Drawing.Size(125, 48);
            // 
            // cms_t_fixedTop
            // 
            this.cms_t_fixedTop.CheckOnClick = true;
            this.cms_t_fixedTop.Name = "cms_t_fixedTop";
            this.cms_t_fixedTop.Size = new System.Drawing.Size(124, 22);
            this.cms_t_fixedTop.Text = "始终置顶";
            this.cms_t_fixedTop.CheckedChanged += new System.EventHandler(this.cms_t_fixedTop_CheckedChanged);
            // 
            // cms_t_close
            // 
            this.cms_t_close.Name = "cms_t_close";
            this.cms_t_close.Size = new System.Drawing.Size(124, 22);
            this.cms_t_close.Text = "关闭";
            this.cms_t_close.Click += new System.EventHandler(this.cms_t_close_Click);
            // 
            // lbl_SKMap
            // 
            this.lbl_SKMap.AutoSize = true;
            this.lbl_SKMap.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SKMap.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_SKMap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_SKMap.Location = new System.Drawing.Point(13, 436);
            this.lbl_SKMap.Name = "lbl_SKMap";
            this.lbl_SKMap.Size = new System.Drawing.Size(87, 16);
            this.lbl_SKMap.TabIndex = 2;
            this.lbl_SKMap.Text = "添加快捷键";
            // 
            // lbl_SKText
            // 
            this.lbl_SKText.AutoSize = true;
            this.lbl_SKText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SKText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_SKText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_SKText.Location = new System.Drawing.Point(61, 472);
            this.lbl_SKText.Name = "lbl_SKText";
            this.lbl_SKText.Size = new System.Drawing.Size(39, 16);
            this.lbl_SKText.TabIndex = 3;
            this.lbl_SKText.Text = "说明";
            // 
            // lbl_SKGroupName
            // 
            this.lbl_SKGroupName.AutoSize = true;
            this.lbl_SKGroupName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SKGroupName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_SKGroupName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_SKGroupName.Location = new System.Drawing.Point(29, 400);
            this.lbl_SKGroupName.Name = "lbl_SKGroupName";
            this.lbl_SKGroupName.Size = new System.Drawing.Size(71, 16);
            this.lbl_SKGroupName.TabIndex = 4;
            this.lbl_SKGroupName.Text = "特定程序";
            // 
            // tb_SKMap
            // 
            this.tb_SKMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_SKMap.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SKMap.Location = new System.Drawing.Point(102, 432);
            this.tb_SKMap.Name = "tb_SKMap";
            this.tb_SKMap.Size = new System.Drawing.Size(188, 26);
            this.tb_SKMap.TabIndex = 5;
            // 
            // tb_SKText
            // 
            this.tb_SKText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_SKText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SKText.Location = new System.Drawing.Point(102, 469);
            this.tb_SKText.Name = "tb_SKText";
            this.tb_SKText.Size = new System.Drawing.Size(188, 26);
            this.tb_SKText.TabIndex = 6;
            // 
            // btn_addSK
            // 
            this.btn_addSK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_addSK.Location = new System.Drawing.Point(102, 510);
            this.btn_addSK.Name = "btn_addSK";
            this.btn_addSK.Size = new System.Drawing.Size(188, 23);
            this.btn_addSK.TabIndex = 8;
            this.btn_addSK.Text = "保存";
            this.btn_addSK.UseVisualStyleBackColor = true;
            this.btn_addSK.Click += new System.EventHandler(this.btn_addSK_Click);
            // 
            // cb_SKProcessName
            // 
            this.cb_SKProcessName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_SKProcessName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SKProcessName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cb_SKProcessName.FormattingEnabled = true;
            this.cb_SKProcessName.Location = new System.Drawing.Point(103, 396);
            this.cb_SKProcessName.Name = "cb_SKProcessName";
            this.cb_SKProcessName.Size = new System.Drawing.Size(187, 24);
            this.cb_SKProcessName.TabIndex = 9;
            // 
            // pic_move
            // 
            this.pic_move.BackColor = System.Drawing.Color.Transparent;
            this.pic_move.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pic_move.Image = global::ShortcutKeyRecord.Properties.Resources.平移;
            this.pic_move.Location = new System.Drawing.Point(563, 545);
            this.pic_move.Name = "pic_move";
            this.pic_move.Size = new System.Drawing.Size(22, 22);
            this.pic_move.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_move.TabIndex = 10;
            this.pic_move.TabStop = false;
            this.pic_move.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_move_MouseDown);
            this.pic_move.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_move_MouseMove);
            this.pic_move.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_move_MouseUp);
            // 
            // gb_currentProcess
            // 
            this.gb_currentProcess.BackColor = System.Drawing.Color.Transparent;
            this.gb_currentProcess.Controls.Add(this.p_currentProcess);
            this.gb_currentProcess.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_currentProcess.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gb_currentProcess.Location = new System.Drawing.Point(12, 12);
            this.gb_currentProcess.Name = "gb_currentProcess";
            this.gb_currentProcess.Size = new System.Drawing.Size(560, 105);
            this.gb_currentProcess.TabIndex = 11;
            this.gb_currentProcess.TabStop = false;
            this.gb_currentProcess.Text = "groupBox1";
            // 
            // p_currentProcess
            // 
            this.p_currentProcess.AutoScroll = true;
            this.p_currentProcess.Location = new System.Drawing.Point(6, 20);
            this.p_currentProcess.Name = "p_currentProcess";
            this.p_currentProcess.Size = new System.Drawing.Size(548, 79);
            this.p_currentProcess.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.p_allProcess);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 196);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AllKey";
            // 
            // p_allProcess
            // 
            this.p_allProcess.AutoScroll = true;
            this.p_allProcess.BackColor = System.Drawing.Color.Transparent;
            this.p_allProcess.Location = new System.Drawing.Point(6, 20);
            this.p_allProcess.Name = "p_allProcess";
            this.p_allProcess.Size = new System.Drawing.Size(548, 170);
            this.p_allProcess.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(584, 567);
            this.ContextMenuStrip = this.cms_mouseBtnRight;
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_currentProcess);
            this.Controls.Add(this.pic_move);
            this.Controls.Add(this.cb_SKProcessName);
            this.Controls.Add(this.btn_addSK);
            this.Controls.Add(this.tb_SKText);
            this.Controls.Add(this.tb_SKMap);
            this.Controls.Add(this.lbl_SKGroupName);
            this.Controls.Add(this.lbl_SKText);
            this.Controls.Add(this.lbl_SKMap);
            this.Controls.Add(this.lbl_currentProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cms_mouseBtnRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_move)).EndInit();
            this.gb_currentProcess.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_currentProcess;
        private System.Windows.Forms.Label lbl_SKMap;
        private System.Windows.Forms.Label lbl_SKText;
        private System.Windows.Forms.Label lbl_SKGroupName;
        private System.Windows.Forms.TextBox tb_SKMap;
        private System.Windows.Forms.TextBox tb_SKText;
        private System.Windows.Forms.Button btn_addSK;
        private System.Windows.Forms.ComboBox cb_SKProcessName;
        private System.Windows.Forms.ContextMenuStrip cms_mouseBtnRight;
        private System.Windows.Forms.ToolStripMenuItem cms_t_fixedTop;
        private System.Windows.Forms.ToolStripMenuItem cms_t_close;
        private System.Windows.Forms.PictureBox pic_move;
        private System.Windows.Forms.GroupBox gb_currentProcess;
        private System.Windows.Forms.Panel p_currentProcess;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel p_allProcess;
    }
}

