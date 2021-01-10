namespace QemuDotNet
{
	public partial class ErrorForm : global::System.Windows.Forms.Form
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
			this.txtError = new global::System.Windows.Forms.TextBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.error_copy = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.txtError.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.txtError.Location = new global::System.Drawing.Point(12, 12);
			this.txtError.Multiline = true;
			this.txtError.Name = "txtError";
			this.txtError.Size = new global::System.Drawing.Size(638, 267);
			this.txtError.TabIndex = 0;
			this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new global::System.Drawing.Point(557, 285);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(93, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.error_copy.Location = new global::System.Drawing.Point(12, 285);
			this.error_copy.Name = "error_copy";
			this.error_copy.Size = new global::System.Drawing.Size(134, 23);
			this.error_copy.TabIndex = 6;
			this.error_copy.Text = "Copy to clipboard";
			this.error_copy.UseVisualStyleBackColor = true;
			this.error_copy.Click += new global::System.EventHandler(this.error_copy_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(662, 320);
			base.ControlBox = false;
			base.Controls.Add(this.error_copy);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.txtError);
			base.Name = "frmError";
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Error";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.Button btnOK;

		public global::System.Windows.Forms.TextBox txtError;

		private global::System.Windows.Forms.Button error_copy;
	}
}
