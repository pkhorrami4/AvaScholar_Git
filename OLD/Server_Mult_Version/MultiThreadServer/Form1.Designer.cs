namespace MultiThreadServer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.start_server = new System.Windows.Forms.Button();
            this.msg_box = new System.Windows.Forms.TextBox();
            this.stop_server = new System.Windows.Forms.Button();
            this.bg_worker1 = new System.ComponentModel.BackgroundWorker();
            this.gaze_plot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.alert_box0 = new System.Windows.Forms.TextBox();
            this.alert_box1 = new System.Windows.Forms.TextBox();
            this.subj0_hist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.subj1_hist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.subjNameBox0 = new System.Windows.Forms.RichTextBox();
            this.subjNameBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gaze_plot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj0_hist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj1_hist)).BeginInit();
            this.SuspendLayout();
            // 
            // start_server
            // 
            this.start_server.Location = new System.Drawing.Point(12, 12);
            this.start_server.Name = "start_server";
            this.start_server.Size = new System.Drawing.Size(130, 77);
            this.start_server.TabIndex = 0;
            this.start_server.Text = "START SERVER";
            this.start_server.UseVisualStyleBackColor = true;
            this.start_server.Click += new System.EventHandler(this.start_server_Click);
            // 
            // msg_box
            // 
            this.msg_box.Location = new System.Drawing.Point(172, 12);
            this.msg_box.Multiline = true;
            this.msg_box.Name = "msg_box";
            this.msg_box.Size = new System.Drawing.Size(398, 173);
            this.msg_box.TabIndex = 1;
            // 
            // stop_server
            // 
            this.stop_server.Location = new System.Drawing.Point(12, 108);
            this.stop_server.Name = "stop_server";
            this.stop_server.Size = new System.Drawing.Size(130, 77);
            this.stop_server.TabIndex = 2;
            this.stop_server.Text = "STOP SERVER";
            this.stop_server.UseVisualStyleBackColor = true;
            this.stop_server.Click += new System.EventHandler(this.stop_server_Click);
            // 
            // bg_worker1
            // 
            this.bg_worker1.WorkerSupportsCancellation = true;
            this.bg_worker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_worker1_DoWork);
            // 
            // gaze_plot
            // 
            this.gaze_plot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gaze_plot.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.gaze_plot.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea1.AxisX.Interval = 75D;
            chartArea1.AxisX.Maximum = 300D;
            chartArea1.AxisX.Minimum = -300D;
            chartArea1.AxisX.Title = "X";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Interval = 50D;
            chartArea1.AxisY.Maximum = 200D;
            chartArea1.AxisY.Minimum = -200D;
            chartArea1.AxisY.Title = "Y";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.gaze_plot.ChartAreas.Add(chartArea1);
            this.gaze_plot.Location = new System.Drawing.Point(613, 12);
            this.gaze_plot.Name = "gaze_plot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Blue;
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.MarkerSize = 8;
            series2.Name = "Series2";
            this.gaze_plot.Series.Add(series1);
            this.gaze_plot.Series.Add(series2);
            this.gaze_plot.Size = new System.Drawing.Size(753, 414);
            this.gaze_plot.TabIndex = 5;
            // 
            // alert_box0
            // 
            this.alert_box0.ForeColor = System.Drawing.SystemColors.Window;
            this.alert_box0.Location = new System.Drawing.Point(12, 287);
            this.alert_box0.Multiline = true;
            this.alert_box0.Name = "alert_box0";
            this.alert_box0.Size = new System.Drawing.Size(130, 49);
            this.alert_box0.TabIndex = 6;
            // 
            // alert_box1
            // 
            this.alert_box1.Location = new System.Drawing.Point(12, 526);
            this.alert_box1.Multiline = true;
            this.alert_box1.Name = "alert_box1";
            this.alert_box1.Size = new System.Drawing.Size(130, 49);
            this.alert_box1.TabIndex = 7;
            // 
            // subj0_hist
            // 
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "Frame Number";
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "P(Engaged)";
            chartArea2.Name = "ChartArea1";
            this.subj0_hist.ChartAreas.Add(chartArea2);
            this.subj0_hist.Location = new System.Drawing.Point(172, 210);
            this.subj0_hist.Name = "subj0_hist";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Blue;
            series3.Name = "Series1";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj0_hist.Series.Add(series3);
            this.subj0_hist.Size = new System.Drawing.Size(398, 216);
            this.subj0_hist.TabIndex = 8;
            this.subj0_hist.Text = "chart1";
            // 
            // subj1_hist
            // 
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.Title = "Frame Number";
            chartArea3.AxisY.Maximum = 1D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.Title = "P(Engaged)";
            chartArea3.Name = "ChartArea1";
            this.subj1_hist.ChartAreas.Add(chartArea3);
            this.subj1_hist.Location = new System.Drawing.Point(172, 447);
            this.subj1_hist.Name = "subj1_hist";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Green;
            series4.Name = "Series1";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj1_hist.Series.Add(series4);
            this.subj1_hist.Size = new System.Drawing.Size(398, 216);
            this.subj1_hist.TabIndex = 9;
            this.subj1_hist.Text = "chart2";
            // 
            // subjNameBox0
            // 
            this.subjNameBox0.BackColor = System.Drawing.Color.Blue;
            this.subjNameBox0.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjNameBox0.ForeColor = System.Drawing.Color.White;
            this.subjNameBox0.Location = new System.Drawing.Point(12, 258);
            this.subjNameBox0.Name = "subjNameBox0";
            this.subjNameBox0.Size = new System.Drawing.Size(130, 23);
            this.subjNameBox0.TabIndex = 10;
            this.subjNameBox0.Text = "     SUBJECT 0";
            // 
            // subjNameBox1
            // 
            this.subjNameBox1.BackColor = System.Drawing.Color.Green;
            this.subjNameBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjNameBox1.ForeColor = System.Drawing.Color.White;
            this.subjNameBox1.Location = new System.Drawing.Point(12, 497);
            this.subjNameBox1.Name = "subjNameBox1";
            this.subjNameBox1.Size = new System.Drawing.Size(130, 23);
            this.subjNameBox1.TabIndex = 11;
            this.subjNameBox1.Text = "     SUBJECT 1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1394, 688);
            this.Controls.Add(this.subjNameBox1);
            this.Controls.Add(this.subjNameBox0);
            this.Controls.Add(this.subj1_hist);
            this.Controls.Add(this.subj0_hist);
            this.Controls.Add(this.alert_box1);
            this.Controls.Add(this.alert_box0);
            this.Controls.Add(this.gaze_plot);
            this.Controls.Add(this.stop_server);
            this.Controls.Add(this.msg_box);
            this.Controls.Add(this.start_server);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gaze_plot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj0_hist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj1_hist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_server;
        private System.Windows.Forms.TextBox msg_box;
        private System.Windows.Forms.Button stop_server;
        private System.ComponentModel.BackgroundWorker bg_worker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart gaze_plot;
        private System.Windows.Forms.TextBox alert_box0;
        private System.Windows.Forms.TextBox alert_box1;
        private System.Windows.Forms.DataVisualization.Charting.Chart subj0_hist;
        private System.Windows.Forms.DataVisualization.Charting.Chart subj1_hist;
        private System.Windows.Forms.RichTextBox subjNameBox0;
        private System.Windows.Forms.RichTextBox subjNameBox1;
    }
}

