namespace BasicTCPClient
{
    partial class Form1
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
            this.start_client = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.stop_button = new System.Windows.Forms.Button();
            this.msg_box = new System.Windows.Forms.TextBox();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.ageBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start_client
            // 
            this.start_client.Location = new System.Drawing.Point(29, 26);
            this.start_client.Name = "start_client";
            this.start_client.Size = new System.Drawing.Size(101, 76);
            this.start_client.TabIndex = 0;
            this.start_client.Text = "START CLIENT";
            this.start_client.UseVisualStyleBackColor = true;
            this.start_client.Click += new System.EventHandler(this.start_client_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(29, 124);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(101, 70);
            this.stop_button.TabIndex = 1;
            this.stop_button.Text = "STOP CLIENT";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // msg_box
            // 
            this.msg_box.Location = new System.Drawing.Point(152, 26);
            this.msg_box.Multiline = true;
            this.msg_box.Name = "msg_box";
            this.msg_box.Size = new System.Drawing.Size(409, 168);
            this.msg_box.TabIndex = 2;
            // 
            // genderBox
            // 
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "M",
            "F"});
            this.genderBox.Location = new System.Drawing.Point(152, 220);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(69, 21);
            this.genderBox.TabIndex = 3;
            // 
            // ageBox
            // 
            this.ageBox.FormattingEnabled = true;
            this.ageBox.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.ageBox.Location = new System.Drawing.Point(152, 260);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(69, 21);
            this.ageBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Age:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gender:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 348);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ageBox);
            this.Controls.Add(this.genderBox);
            this.Controls.Add(this.msg_box);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_client);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_client;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.TextBox msg_box;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.ComboBox ageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

