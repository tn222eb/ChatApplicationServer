namespace NetworkApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlServerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // controlServerBtn
            // 
            this.controlServerBtn.Location = new System.Drawing.Point(100, 226);
            this.controlServerBtn.Name = "controlServerBtn";
            this.controlServerBtn.Size = new System.Drawing.Size(75, 23);
            this.controlServerBtn.TabIndex = 0;
            this.controlServerBtn.Text = "Start Server";
            this.controlServerBtn.UseVisualStyleBackColor = true;
            this.controlServerBtn.Click += new System.EventHandler(this.ControlServerBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.controlServerBtn);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button controlServerBtn;

    }
}

