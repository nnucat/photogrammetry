namespace Assignment
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.后方交会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进行后方交会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.前方交会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开控制点文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进行前方交会ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.相对定向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开相对定向文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进行相对定向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.误差值计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 440);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机参数";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 55);
            this.button1.TabIndex = 12;
            this.button1.Text = "加载相机参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(94, 242);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 25);
            this.textBox6.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(94, 196);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 25);
            this.textBox5.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(94, 141);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(94, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "像主点Y(mm)：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "像主点X(mm)：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "像元尺寸：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "相机焦距：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "图像高度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图像宽度：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 440);
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(606, 440);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(806, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.后方交会ToolStripMenuItem,
            this.前方交会ToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(53, 24);
            this.toolStripDropDownButton2.Text = "交会";
            // 
            // 后方交会ToolStripMenuItem
            // 
            this.后方交会ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.进行后方交会ToolStripMenuItem,
            this.误差值计算ToolStripMenuItem});
            this.后方交会ToolStripMenuItem.Name = "后方交会ToolStripMenuItem";
            this.后方交会ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.后方交会ToolStripMenuItem.Text = "后方交会";
            this.后方交会ToolStripMenuItem.Click += new System.EventHandler(this.后方交会ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.打开ToolStripMenuItem.Text = "打开控制点文件";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 进行后方交会ToolStripMenuItem
            // 
            this.进行后方交会ToolStripMenuItem.Name = "进行后方交会ToolStripMenuItem";
            this.进行后方交会ToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.进行后方交会ToolStripMenuItem.Text = "进行后方交会";
            this.进行后方交会ToolStripMenuItem.Click += new System.EventHandler(this.进行后方交会ToolStripMenuItem_Click);
            // 
            // 前方交会ToolStripMenuItem
            // 
            this.前方交会ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开控制点文件ToolStripMenuItem,
            this.进行前方交会ToolStripMenuItem});
            this.前方交会ToolStripMenuItem.Name = "前方交会ToolStripMenuItem";
            this.前方交会ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.前方交会ToolStripMenuItem.Text = "前方交会";
            this.前方交会ToolStripMenuItem.Click += new System.EventHandler(this.前方交会ToolStripMenuItem_Click);
            // 
            // 打开控制点文件ToolStripMenuItem
            // 
            this.打开控制点文件ToolStripMenuItem.Name = "打开控制点文件ToolStripMenuItem";
            this.打开控制点文件ToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.打开控制点文件ToolStripMenuItem.Text = "打开控制点文件";
            this.打开控制点文件ToolStripMenuItem.Click += new System.EventHandler(this.打开控制点文件ToolStripMenuItem_Click);
            // 
            // 进行前方交会ToolStripMenuItem
            // 
            this.进行前方交会ToolStripMenuItem.Name = "进行前方交会ToolStripMenuItem";
            this.进行前方交会ToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.进行前方交会ToolStripMenuItem.Text = "打开同名像点并进行前方交会";
            this.进行前方交会ToolStripMenuItem.Click += new System.EventHandler(this.进行前方交会ToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相对定向ToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(53, 24);
            this.toolStripDropDownButton3.Text = "定向";
            this.toolStripDropDownButton3.ToolTipText = "相对定向";
            // 
            // 相对定向ToolStripMenuItem
            // 
            this.相对定向ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开相对定向文件ToolStripMenuItem,
            this.进行相对定向ToolStripMenuItem});
            this.相对定向ToolStripMenuItem.Name = "相对定向ToolStripMenuItem";
            this.相对定向ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.相对定向ToolStripMenuItem.Text = "相对定向";
            this.相对定向ToolStripMenuItem.Click += new System.EventHandler(this.相对定向ToolStripMenuItem_Click);
            // 
            // 打开相对定向文件ToolStripMenuItem
            // 
            this.打开相对定向文件ToolStripMenuItem.Name = "打开相对定向文件ToolStripMenuItem";
            this.打开相对定向文件ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.打开相对定向文件ToolStripMenuItem.Text = "打开同名像点文件";
            this.打开相对定向文件ToolStripMenuItem.Click += new System.EventHandler(this.打开相对定向文件ToolStripMenuItem_Click);
            // 
            // 进行相对定向ToolStripMenuItem
            // 
            this.进行相对定向ToolStripMenuItem.Name = "进行相对定向ToolStripMenuItem";
            this.进行相对定向ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.进行相对定向ToolStripMenuItem.Text = "进行相对定向";
            this.进行相对定向ToolStripMenuItem.Click += new System.EventHandler(this.进行相对定向ToolStripMenuItem_Click);
            // 
            // 误差值计算ToolStripMenuItem
            // 
            this.误差值计算ToolStripMenuItem.Name = "误差值计算ToolStripMenuItem";
            this.误差值计算ToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.误差值计算ToolStripMenuItem.Text = "读取真值并进行误差值计算";
            this.误差值计算ToolStripMenuItem.Click += new System.EventHandler(this.误差值计算ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 467);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "双像解析摄影测量";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 后方交会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 前方交会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem 相对定向ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进行后方交会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开控制点文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进行前方交会ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开相对定向文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进行相对定向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 误差值计算ToolStripMenuItem;
    }
}

