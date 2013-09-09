namespace MultiThreadServer_v5
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.subj1_hist_complete = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.subj2_hist_complete = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Avg_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.subj3_hist_complete = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.subj1_hist_complete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj2_hist_complete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avg_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj3_hist_complete)).BeginInit();
            this.SuspendLayout();
            // 
            // subj1_hist_complete
            // 
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "P[Engaged]";
            chartArea1.Name = "ChartArea1";
            this.subj1_hist_complete.ChartAreas.Add(chartArea1);
            this.subj1_hist_complete.Location = new System.Drawing.Point(41, 22);
            this.subj1_hist_complete.Name = "subj1_hist_complete";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Blue;
            series1.Name = "Subj1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj1_hist_complete.Series.Add(series1);
            this.subj1_hist_complete.Size = new System.Drawing.Size(645, 145);
            this.subj1_hist_complete.TabIndex = 0;
            this.subj1_hist_complete.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Subj. 1 Complete History";
            this.subj1_hist_complete.Titles.Add(title1);
            // 
            // subj2_hist_complete
            // 
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "P[Engaged]";
            chartArea2.Name = "ChartArea1";
            this.subj2_hist_complete.ChartAreas.Add(chartArea2);
            this.subj2_hist_complete.Location = new System.Drawing.Point(721, 21);
            this.subj2_hist_complete.Name = "subj2_hist_complete";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Green;
            series2.Name = "Subj2";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj2_hist_complete.Series.Add(series2);
            this.subj2_hist_complete.Size = new System.Drawing.Size(645, 146);
            this.subj2_hist_complete.TabIndex = 1;
            this.subj2_hist_complete.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Subj. 2 Complete History";
            this.subj2_hist_complete.Titles.Add(title2);
            // 
            // Avg_Chart
            // 
            chartArea3.AxisX.Title = "Time";
            chartArea3.AxisY.Maximum = 1D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.Title = "P[Engaged]";
            chartArea3.Name = "ChartArea1";
            this.Avg_Chart.ChartAreas.Add(chartArea3);
            this.Avg_Chart.Location = new System.Drawing.Point(721, 222);
            this.Avg_Chart.Name = "Avg_Chart";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "Series1";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.Avg_Chart.Series.Add(series3);
            this.Avg_Chart.Size = new System.Drawing.Size(645, 141);
            this.Avg_Chart.TabIndex = 2;
            this.Avg_Chart.Text = "chart3";
            title3.Name = "Title1";
            title3.Text = "Avg. Attention Score vs. Time";
            this.Avg_Chart.Titles.Add(title3);
            // 
            // subj3_hist_complete
            // 
            chartArea4.AxisX.Title = "Time";
            chartArea4.AxisY.Maximum = 1D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.AxisY.Title = "P[Engaged]";
            chartArea4.Name = "ChartArea1";
            this.subj3_hist_complete.ChartAreas.Add(chartArea4);
            this.subj3_hist_complete.Location = new System.Drawing.Point(41, 217);
            this.subj3_hist_complete.Name = "subj3_hist_complete";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Magenta;
            series4.Name = "Subj2";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj3_hist_complete.Series.Add(series4);
            this.subj3_hist_complete.Size = new System.Drawing.Size(645, 146);
            this.subj3_hist_complete.TabIndex = 3;
            this.subj3_hist_complete.Text = "chart2";
            title4.Name = "Title1";
            title4.Text = "Subj. 3 Complete History";
            this.subj3_hist_complete.Titles.Add(title4);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 416);
            this.Controls.Add(this.subj3_hist_complete);
            this.Controls.Add(this.Avg_Chart);
            this.Controls.Add(this.subj2_hist_complete);
            this.Controls.Add(this.subj1_hist_complete);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.subj1_hist_complete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj2_hist_complete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avg_Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj3_hist_complete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart subj1_hist_complete;
        public System.Windows.Forms.DataVisualization.Charting.Chart subj2_hist_complete;
        public System.Windows.Forms.DataVisualization.Charting.Chart Avg_Chart;
        public System.Windows.Forms.DataVisualization.Charting.Chart subj3_hist_complete;
    }
}