namespace WinFormUI
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
            this.ClientSize = new System.Drawing.Size(531, 352);
            this.Name = "Form1";
            this.Text = "Form1";
            this.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            // 
            // label1
            // 
            this.label1 = new System.Windows.Forms.Label();
            this.label1.Location = new System.Drawing.Point(138, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.TabIndex = 0;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Text = "First Name";
            this.Controls.Add(this.label1);
            // 
            // firstNameText
            // 
            this.firstNameText = new System.Windows.Forms.TextBox();
            this.firstNameText.Location = new System.Drawing.Point(252, 112);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Size = new System.Drawing.Size(180, 30);
            this.firstNameText.TabIndex = 0;
            this.firstNameText.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.firstNameText.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.firstNameText.Text = "TextBox";
            this.Controls.Add(this.firstNameText);
            // 
            // label2
            // 
            this.label2 = new System.Windows.Forms.Label();
            this.label2.Location = new System.Drawing.Point(138, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.TabIndex = 0;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Text = "Label";
            this.Controls.Add(this.label2);
            // 
            // lastNameText
            // 
            this.lastNameText = new System.Windows.Forms.TextBox();
            this.lastNameText.Location = new System.Drawing.Point(253, 163);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(179, 30);
            this.lastNameText.TabIndex = 0;
            this.lastNameText.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lastNameText.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lastNameText.Text = "TextBox";
            this.Controls.Add(this.lastNameText);
            // 
            // combineNameBtn
            // 
            this.combineNameBtn = new System.Windows.Forms.Button();
            this.combineNameBtn.Location = new System.Drawing.Point(140, 234);
            this.combineNameBtn.Name = "combineNameBtn";
            this.combineNameBtn.Size = new System.Drawing.Size(296, 30);
            this.combineNameBtn.TabIndex = 0;
            this.combineNameBtn.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.combineNameBtn.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.combineNameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combineNameBtn.Text = "Combine Name";
            this.combineNameBtn.Click += new System.EventHandler(this.combineNameBtn_Click);
            this.Controls.Add(this.combineNameBtn);
            // 
            // Form controls collection
            // 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label1,
                this.firstNameText,
                this.label2,
                this.lastNameText,
                this.combineNameBtn
            });
            this.ResumeLayout(false);
        }

        #endregion

        // Control declarations
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastNameText;
        private System.Windows.Forms.Button combineNameBtn;
    }
}