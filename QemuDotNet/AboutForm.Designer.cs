namespace QemuDotNet
{
	public partial class AboutForm : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::QemuDotNet.AboutForm));
			this.button1 = new global::System.Windows.Forms.Button();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			base.SuspendLayout();
			this.button1.Location = new global::System.Drawing.Point(109, 263);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new global::System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(287, 245);
			this.tabControl1.TabIndex = 2;
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(279, 219);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "License";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.textBox1.Location = new global::System.Drawing.Point(6, 6);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new global::System.Drawing.Size(267, 207);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			this.tabPage2.Controls.Add(this.textBox2);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(279, 219);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Credits";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.textBox2.Location = new global::System.Drawing.Point(6, 6);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new global::System.Drawing.Size(267, 207);
			this.textBox2.TabIndex = 0;
			this.textBox2.Text = resources.GetString("textBox2.Text");
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(311, 298);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.button1);
			base.Name = "AboutForm";
			this.Text = "About";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.Button button1;

		private global::System.Windows.Forms.TabControl tabControl1;

		private global::System.Windows.Forms.TabPage tabPage1;

		private global::System.Windows.Forms.TabPage tabPage2;

		private global::System.Windows.Forms.TextBox textBox1;

		private global::System.Windows.Forms.TextBox textBox2;
	}
}
