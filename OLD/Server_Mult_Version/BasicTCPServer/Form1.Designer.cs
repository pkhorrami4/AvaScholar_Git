namespace BasicTCPServer
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.start_server = new System.Windows.Forms.Button();
            this.msg_box = new System.Windows.Forms.TextBox();
            this.stop_server = new System.Windows.Forms.Button();
            this.bg_worker1 = new System.ComponentModel.BackgroundWorker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Test_Calc = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.alert_box = new System.Windows.Forms.TextBox();
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
            chartArea1.AxisX.Title = "Frame Number";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea1.AxisY.Interval = 30D;
            chartArea1.AxisY.Maximum = 90D;
            chartArea1.AxisY.Minimum = -90D;
            chartArea1.AxisY.Title = "Rotation Angles";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 205);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Pitch";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Yaw";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "Roll";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(484, 263);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
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
            // chart2
            // 
            this.chart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chart2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.chart2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea2.AxisX.Interval = 75D;
            chartArea2.AxisX.Maximum = 300D;
            chartArea2.AxisX.Minimum = -300D;
            chartArea2.AxisX.Title = "X";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.Interval = 50D;
            chartArea2.AxisY.Maximum = 200D;
            chartArea2.AxisY.Minimum = -200D;
            chartArea2.AxisY.Title = "Y";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(532, 83);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Color = System.Drawing.Color.Blue;
            series4.MarkerSize = 8;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "Series1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Color = System.Drawing.Color.Red;
            series5.MarkerSize = 8;
            series5.Name = "Series2";
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
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
        private System.Windows.Forms.Button Test_Calc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox alert_box;
    }
}

