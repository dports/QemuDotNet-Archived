namespace QemuDotNet
{
	public partial class DebugForm : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::QemuDotNet.DebugForm));
			this.txtDebug = new global::System.Windows.Forms.TextBox();
			this.toolStrip = new global::System.Windows.Forms.ToolStrip();
			this.toolStripButton3 = new global::System.Windows.Forms.ToolStripButton();
			this.tsButton_copy = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new global::System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			base.SuspendLayout();
			this.txtDebug.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtDebug.BackColor = global::System.Drawing.SystemColors.Window;
			this.txtDebug.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.txtDebug.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtDebug.Location = new global::System.Drawing.Point(0, 28);
			this.txtDebug.Multiline = true;
			this.txtDebug.Name = "txtDebug";
			this.txtDebug.ReadOnly = true;
			this.txtDebug.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.txtDebug.Size = new global::System.Drawing.Size(624, 416);
			this.txtDebug.TabIndex = 0;
			this.txtDebug.WordWrap = false;
			this.toolStrip.GripStyle = global::System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripButton3,
				this.tsButton_copy
			});
			this.toolStrip.Location = new global::System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = global::System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip.Size = new global::System.Drawing.Size(624, 25);
			this.toolStrip.Stretch = true;
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "Copy to clipboard";
			this.toolStripButton3.Image = global::QemuDotNet.Properties.Resources.MainSaveIcon;
			this.toolStripButton3.ImageTransparentColor = global::System.Drawing.Color.Transparent;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new global::System.Drawing.Size(51, 22);
			this.toolStripButton3.Text = "Save";
			this.toolStripButton3.Click += new global::System.EventHandler(this.tsButton_save_Click);
			this.tsButton_copy.Font = new global::System.Drawing.Font("Tahoma", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tsButton_copy.Image = global::QemuDotNet.Properties.Resources.copy;
			this.tsButton_copy.ImageTransparentColor = global::System.Drawing.Color.Transparent;
			this.tsButton_copy.Name = "tsButton_copy";
			this.tsButton_copy.Size = new global::System.Drawing.Size(68, 22);
			this.tsButton_copy.Text = "Copy all";
			this.tsButton_copy.Click += new global::System.EventHandler(this.tsbuttonCopy_Click);
			this.toolStripButton1.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = (global::System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
			this.toolStripButton1.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new global::System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton2.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = (global::System.Drawing.Image)resources.GetObject("toolStripButton2.Image");
			this.toolStripButton2.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new global::System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "toolStripButton2";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.AutoValidate = global::System.Windows.Forms.AutoValidate.Disable;
			base.CausesValidation = false;
			base.ClientSize = new global::System.Drawing.Size(624, 444);
			base.Controls.Add(this.toolStrip);
			base.Controls.Add(this.txtDebug);
			this.DoubleBuffered = true;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "DebugForm";
			this.Text = "Serial Output";
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components = null;

		public global::System.Windows.Forms.TextBox txtDebug;

		private global::System.Windows.Forms.ToolStrip toolStrip;

		private global::System.Windows.Forms.ToolStripButton toolStripButton1;

		private global::System.Windows.Forms.ToolStripButton toolStripButton2;

		private global::System.Windows.Forms.ToolStripButton tsButton_copy;

		private global::System.Windows.Forms.ToolStripButton toolStripButton3;
	}
}
