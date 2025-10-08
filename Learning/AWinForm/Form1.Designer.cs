namespace AWinForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            this.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            // 
            // button1
            // 
            this.button1 = new System.Windows.Forms.Button();
            this.button1.Location = new System.Drawing.Point(229, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 0;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.button1.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Text = "Button";
            this.Controls.Add(this.button1);
            // 
            // textbox1
            // 
            this.textbox1 = new System.Windows.Forms.TextBox();
            this.textbox1.Location = new System.Drawing.Point(15, 48);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(458, 185);
            this.textbox1.TabIndex = 0;
            this.textbox1.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.textbox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.textbox1.Text = "TextBox";
            this.Controls.Add(this.textbox1);
            // 
            // textbox2
            // 
            this.textbox2 = new System.Windows.Forms.TextBox();
            this.textbox2.Location = new System.Drawing.Point(0, 0);
            this.textbox2.Name = "textbox2";
            this.textbox2.Size = new System.Drawing.Size(100, 30);
            this.textbox2.TabIndex = 0;
            this.textbox2.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.textbox2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.textbox2.Text = "TextBox";
            this.Controls.Add(this.textbox2);
            // 
            // button2
            // 
            this.button2 = new System.Windows.Forms.Button();
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 46);
            this.button2.TabIndex = 0;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.button2.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Text = "Button";
            this.Controls.Add(this.button2);
            // 
            // Form controls collection
            // 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.button1,
                this.textbox1,
                this.textbox2,
                this.button2
            });
            this.ResumeLayout(false);
        }

        #endregion

        // Control declarations
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textbox1;
        private System.Windows.Forms.TextBox textbox2;
        private System.Windows.Forms.Button button2;
    }
}