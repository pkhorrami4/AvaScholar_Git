namespace BasicTCPServer_v1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.start_server = new System.Windows.Forms.Button();
            this.msg_box = new System.Windows.Forms.TextBox();
            this.stop_server = new System.Windows.Forms.Button();
            this.bg_worker1 = new System.ComponentModel.BackgroundWorker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.alert_box = new System.Windows.Forms.TextBox();
            this.Test_Calc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
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
            this.msg_box.Size = new System.Drawing.Size(324, 173);
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
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DarkGray;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea3.AxisX.Title = "Frame Number";
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea3.AxisY.Interval = 30D;
            chartArea3.AxisY.Maximum = 90D;
            chartArea3.AxisY.Minimum = -90D;
            chartArea3.AxisY.Title = "Rotation Angles";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 205);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.Blue;
            series6.Legend = "Legend1";
            series6.Name = "Pitch";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series7.Legend = "Legend1";
            series7.Name = "Yaw";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series8.Legend = "Legend1";
            series8.Name = "Roll";
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(484, 263);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chart2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.chart2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea4.AxisX.Interval = 75D;
            chartArea4.AxisX.Maximum = 300D;
            chartArea4.AxisX.Minimum = -300D;
            chartArea4.AxisX.Title = "X";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisY.Interval = 50D;
            chartArea4.AxisY.Maximum = 200D;
            chartArea4.AxisY.Minimum = -200D;
            chartArea4.AxisY.Title = "Y";
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Location = new System.Drawing.Point(532, 83);
            this.chart2.Name = "chart2";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series9.Color = System.Drawing.Color.Blue;
            series9.MarkerSize = 8;
            series9.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series9.Name = "Series1";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series10.Color = System.Drawing.Color.Red;
            series10.MarkerSize = 8;
            series10.Name = "Series2";
            this.chart2.Series.Add(series9);
            this.chart2.Series.Add(series10);
            this.chart2.Size = new System.Drawing.Size(681, 385);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // alert_box
            // 
            this.alert_box.Location = new System.Drawing.Point(683, 12);
            this.alert_box.Multiline = true;
            this.alert_box.Name = "alert_box";
            this.alert_box.Size = new System.Drawing.Size(530, 49);
            this.alert_box.TabIndex = 6;
            // 
            // Test_Calc
            // 
            this.Test_Calc.Location = new System.Drawing.Point(528, 12);
            this.Test_Calc.Name = "Test_Calc";
            this.Test_Calc.Size = new System.Drawing.Size(116, 49);
            this.Test_Calc.TabIndex = 4;
            this.Test_Calc.Text = "Test_Calc";
            this.Test_Calc.UseVisualStyleBackColor = true;
            this.Test_Calc.Click += new System.EventHandler(this.Test_Calc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1242, 576);
            this.Controls.Add(this.alert_box);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.Test_Calc);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.stop_server);
            this.Controls.Add(this.msg_box);
            this.Controls.Add(this.start_server);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_server;
        private System.Windows.Forms.TextBox msg_box;
        private System.Windows.Forms.Button stop_server;
        private System.ComponentModel.BackgroundWorker bg_worker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox alert_box;
        private System.Windows.Forms.Button Test_Calc;
    }
}

