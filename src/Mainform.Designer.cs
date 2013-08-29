namespace src
{
    partial class Mainform
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button10 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.button9 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button10);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.listBox2);
			this.groupBox1.Controls.Add(this.button9);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 347);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "神奇的木炭";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// button10
			// 
			this.button10.Enabled = false;
			this.button10.Location = new System.Drawing.Point(13, 311);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(147, 26);
			this.button10.TabIndex = 16;
			this.button10.Text = "Save";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(166, 163);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(51, 28);
			this.button7.TabIndex = 15;
			this.button7.Text = "<-Add";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(225, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "可以爆的东西";
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(228, 87);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(163, 251);
			this.listBox2.TabIndex = 13;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(82, 279);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(78, 26);
			this.button9.TabIndex = 12;
			this.button9.Text = "Default";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(13, 279);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(63, 26);
			this.button6.TabIndex = 11;
			this.button6.Text = "Remove";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "当前爆的东西";
			// 
			// listBox1
			// 
			this.listBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(16, 87);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(144, 186);
			this.listBox1.TabIndex = 3;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(243, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "这里允许你修改游戏中被火烧过的树能够爆出的道具(修改完保存后重新开启游戏生效)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "label2";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Mainform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 416);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Mainform";
			this.Text = "I won\'t Starve";
			this.Load += new System.EventHandler(this.Mainform_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button10;
    }
}

