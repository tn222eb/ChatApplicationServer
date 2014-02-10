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
            this.currentChatroomsListview = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlServerBtn
            // 
            this.controlServerBtn.Location = new System.Drawing.Point(31, 226);
            this.controlServerBtn.Name = "controlServerBtn";
            this.controlServerBtn.Size = new System.Drawing.Size(75, 23);
            this.controlServerBtn.TabIndex = 0;
            this.controlServerBtn.Text = "Start Server";
            this.controlServerBtn.UseVisualStyleBackColor = true;
            this.controlServerBtn.Click += new System.EventHandler(this.ControlServerBtn_Click);
            // 
            // currentChatroomsListview
            // 
            this.currentChatroomsListview.Location = new System.Drawing.Point(12, 28);
            this.currentChatroomsListview.Name = "currentChatroomsListview";
            this.currentChatroomsListview.Size = new System.Drawing.Size(121, 192);
            this.currentChatroomsListview.TabIndex = 1;
            this.currentChatroomsListview.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Chatrooms";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentChatroomsListview);
            this.Controls.Add(this.controlServerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Much Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button controlServerBtn;
        private System.Windows.Forms.ListView currentChatroomsListview;
        private System.Windows.Forms.Label label1;

    }
}

