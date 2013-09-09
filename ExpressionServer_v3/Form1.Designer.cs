namespace ExpressionServer_v3
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
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.start_server = new System.Windows.Forms.Button();
            this.msg_box = new System.Windows.Forms.TextBox();
            this.stop_server = new System.Windows.Forms.Button();
            this.bg_worker1 = new System.ComponentModel.BackgroundWorker();
            this.plot_all_button = new System.Windows.Forms.Button();
            this.plot_gender_button = new System.Windows.Forms.Button();
            this.plot_age_button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ageBox2 = new System.Windows.Forms.TextBox();
            this.genderBox2 = new System.Windows.Forms.TextBox();
            this.subjNameBox3 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ageBox1 = new System.Windows.Forms.TextBox();
            this.genderBox1 = new System.Windows.Forms.TextBox();
            this.subjNameBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ageBox0 = new System.Windows.Forms.TextBox();
            this.genderBox0 = new System.Windows.Forms.TextBox();
            this.subjNameBox1 = new System.Windows.Forms.RichTextBox();
            this.subj2_hist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.subj1_hist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.subj0_hist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subj2_hist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj1_hist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj0_hist)).BeginInit();
            this.SuspendLayout();
            // 
            // start_server
            // 
            this.start_server.Location = new System.Drawing.Point(26, 27);
            this.start_server.Name = "start_server";
            this.start_server.Size = new System.Drawing.Size(130, 50);
            this.start_server.TabIndex = 0;
            this.start_server.Text = "START SERVER";
            this.start_server.UseVisualStyleBackColor = true;
            this.start_server.Click += new System.EventHandler(this.start_server_Click);
            // 
            // msg_box
            // 
            this.msg_box.Location = new System.Drawing.Point(186, 27);
            this.msg_box.Multiline = true;
            this.msg_box.Name = "msg_box";
            this.msg_box.Size = new System.Drawing.Size(398, 114);
            this.msg_box.TabIndex = 1;
            // 
            // stop_server
            // 
            this.stop_server.Location = new System.Drawing.Point(26, 92);
            this.stop_server.Name = "stop_server";
            this.stop_server.Size = new System.Drawing.Size(130, 49);
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
            // plot_all_button
            // 
            this.plot_all_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plot_all_button.Location = new System.Drawing.Point(186, 157);
            this.plot_all_button.Name = "plot_all_button";
            this.plot_all_button.Size = new System.Drawing.Size(122, 34);
            this.plot_all_button.TabIndex = 12;
            this.plot_all_button.Text = "PLOT_AVG";
            this.plot_all_button.UseVisualStyleBackColor = true;
            this.plot_all_button.Click += new System.EventHandler(this.plot_all_button_Click);
            // 
            // plot_gender_button
            // 
            this.plot_gender_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plot_gender_button.Location = new System.Drawing.Point(335, 157);
            this.plot_gender_button.Name = "plot_gender_button";
            this.plot_gender_button.Size = new System.Drawing.Size(117, 34);
            this.plot_gender_button.TabIndex = 13;
            this.plot_gender_button.Text = "GENDER";
            this.plot_gender_button.UseVisualStyleBackColor = true;
            this.plot_gender_button.Click += new System.EventHandler(this.plot_gender_button_Click);
            // 
            // plot_age_button
            // 
            this.plot_age_button.Location = new System.Drawing.Point(480, 157);
            this.plot_age_button.Name = "plot_age_button";
            this.plot_age_button.Size = new System.Drawing.Size(104, 34);
            this.plot_age_button.TabIndex = 14;
            this.plot_age_button.Text = "AGE";
            this.plot_age_button.UseVisualStyleBackColor = true;
            this.plot_age_button.Click += new System.EventHandler(this.plot_age_button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(49, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 484);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage1.Controls.Add(this.start_server);
            this.tabPage1.Controls.Add(this.msg_box);
            this.tabPage1.Controls.Add(this.stop_server);
            this.tabPage1.Controls.Add(this.plot_all_button);
            this.tabPage1.Controls.Add(this.plot_gender_button);
            this.tabPage1.Controls.Add(this.plot_age_button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(610, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controls";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.ageBox2);
            this.tabPage2.Controls.Add(this.genderBox2);
            this.tabPage2.Controls.Add(this.subjNameBox3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.ageBox1);
            this.tabPage2.Controls.Add(this.genderBox1);
            this.tabPage2.Controls.Add(this.subjNameBox2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.ageBox0);
            this.tabPage2.Controls.Add(this.genderBox0);
            this.tabPage2.Controls.Add(this.subjNameBox1);
            this.tabPage2.Controls.Add(this.subj2_hist);
            this.tabPage2.Controls.Add(this.subj1_hist);
            this.tabPage2.Controls.Add(this.subj0_hist);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(610, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Subjects";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 65;
            this.label6.Text = "Age:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 64;
            this.label5.Text = "Gender:";
            // 
            // ageBox2
            // 
            this.ageBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageBox2.Location = new System.Drawing.Point(86, 385);
            this.ageBox2.Name = "ageBox2";
            this.ageBox2.Size = new System.Drawing.Size(68, 29);
            this.ageBox2.TabIndex = 63;
            this.ageBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // genderBox2
            // 
            this.genderBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderBox2.Location = new System.Drawing.Point(86, 354);
            this.genderBox2.Name = "genderBox2";
            this.genderBox2.Size = new System.Drawing.Size(68, 25);
            this.genderBox2.TabIndex = 62;
            this.genderBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // subjNameBox3
            // 
            this.subjNameBox3.BackColor = System.Drawing.Color.Magenta;
            this.subjNameBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjNameBox3.ForeColor = System.Drawing.Color.White;
            this.subjNameBox3.Location = new System.Drawing.Point(24, 325);
            this.subjNameBox3.Name = "subjNameBox3";
            this.subjNameBox3.Size = new System.Drawing.Size(130, 23);
            this.subjNameBox3.TabIndex = 61;
            this.subjNameBox3.Text = "     SUBJECT 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 60;
            this.label4.Text = "Age:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 59;
            this.label3.Text = "Gender:";
            // 
            // ageBox1
            // 
            this.ageBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageBox1.Location = new System.Drawing.Point(83, 244);
            this.ageBox1.Name = "ageBox1";
            this.ageBox1.Size = new System.Drawing.Size(68, 29);
            this.ageBox1.TabIndex = 58;
            this.ageBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // genderBox1
            // 
            this.genderBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderBox1.Location = new System.Drawing.Point(83, 209);
            this.genderBox1.Name = "genderBox1";
            this.genderBox1.Size = new System.Drawing.Size(68, 25);
            this.genderBox1.TabIndex = 57;
            this.genderBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // subjNameBox2
            // 
            this.subjNameBox2.BackColor = System.Drawing.Color.Green;
            this.subjNameBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjNameBox2.ForeColor = System.Drawing.Color.White;
            this.subjNameBox2.Location = new System.Drawing.Point(21, 180);
            this.subjNameBox2.Name = "subjNameBox2";
            this.subjNameBox2.Size = new System.Drawing.Size(130, 23);
            this.subjNameBox2.TabIndex = 56;
            this.subjNameBox2.Text = "     SUBJECT 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 55;
            this.label2.Text = "Age:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 54;
            this.label1.Text = "Gender:";
            // 
            // ageBox0
            // 
            this.ageBox0.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageBox0.Location = new System.Drawing.Point(83, 103);
            this.ageBox0.Name = "ageBox0";
            this.ageBox0.Size = new System.Drawing.Size(68, 29);
            this.ageBox0.TabIndex = 53;
            this.ageBox0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // genderBox0
            // 
            this.genderBox0.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderBox0.Location = new System.Drawing.Point(83, 68);
            this.genderBox0.Name = "genderBox0";
            this.genderBox0.Size = new System.Drawing.Size(68, 25);
            this.genderBox0.TabIndex = 52;
            this.genderBox0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // subjNameBox1
            // 
            this.subjNameBox1.BackColor = System.Drawing.Color.Blue;
            this.subjNameBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjNameBox1.ForeColor = System.Drawing.Color.White;
            this.subjNameBox1.Location = new System.Drawing.Point(21, 39);
            this.subjNameBox1.Name = "subjNameBox1";
            this.subjNameBox1.Size = new System.Drawing.Size(130, 23);
            this.subjNameBox1.TabIndex = 51;
            this.subjNameBox1.Text = "     SUBJECT 1";
            // 
            // subj2_hist
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Frame Number";
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Expr. Perc.";
            chartArea1.Name = "ChartArea1";
            this.subj2_hist.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.subj2_hist.Legends.Add(legend1);
            this.subj2_hist.Location = new System.Drawing.Point(166, 309);
            this.subj2_hist.Name = "subj2_hist";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series1.Color = System.Drawing.Color.DarkGreen;
            series1.CustomProperties = "PointWidth=1";
            series1.Legend = "Legend1";
            series1.Name = "Neutral";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series2.Color = System.Drawing.Color.DarkRed;
            series2.CustomProperties = "PointWidth=1";
            series2.Legend = "Legend1";
            series2.Name = "Negative";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series3.Color = System.Drawing.Color.DarkBlue;
            series3.CustomProperties = "PointWidth=1";
            series3.Legend = "Legend1";
            series3.Name = "Positive";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series4.Color = System.Drawing.Color.Magenta;
            series4.CustomProperties = "PointWidth=1";
            series4.Legend = "Legend1";
            series4.Name = "Surprise";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj2_hist.Series.Add(series1);
            this.subj2_hist.Series.Add(series2);
            this.subj2_hist.Series.Add(series3);
            this.subj2_hist.Series.Add(series4);
            this.subj2_hist.Size = new System.Drawing.Size(427, 124);
            this.subj2_hist.TabIndex = 45;
            this.subj2_hist.Text = "chart2";
            // 
            // subj1_hist
            // 
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "Frame Number";
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "Expr. Perc. ";
            chartArea2.Name = "ChartArea1";
            this.subj1_hist.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.subj1_hist.Legends.Add(legend2);
            this.subj1_hist.Location = new System.Drawing.Point(166, 169);
            this.subj1_hist.Name = "subj1_hist";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series5.Color = System.Drawing.Color.DarkGreen;
            series5.CustomProperties = "PointWidth=1";
            series5.Legend = "Legend1";
            series5.Name = "Neutral";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series6.Color = System.Drawing.Color.DarkRed;
            series6.CustomProperties = "PointWidth=1";
            series6.Legend = "Legend1";
            series6.Name = "Negative";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series7.Color = System.Drawing.Color.DarkBlue;
            series7.CustomProperties = "PointWidth=1";
            series7.Legend = "Legend1";
            series7.Name = "Positive";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series8.Color = System.Drawing.Color.Magenta;
            series8.CustomProperties = "PointWidth=1";
            series8.Legend = "Legend1";
            series8.Name = "Surprise";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj1_hist.Series.Add(series5);
            this.subj1_hist.Series.Add(series6);
            this.subj1_hist.Series.Add(series7);
            this.subj1_hist.Series.Add(series8);
            this.subj1_hist.Size = new System.Drawing.Size(427, 124);
            this.subj1_hist.TabIndex = 28;
            this.subj1_hist.Text = "chart2";
            // 
            // subj0_hist
            // 
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.Title = "Frame Number";
            chartArea3.AxisY.Maximum = 1D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.Title = "Expr. Perc.";
            chartArea3.Name = "ChartArea1";
            this.subj0_hist.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.subj0_hist.Legends.Add(legend3);
            this.subj0_hist.Location = new System.Drawing.Point(166, 28);
            this.subj0_hist.Name = "subj0_hist";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series9.Color = System.Drawing.Color.DarkGreen;
            series9.CustomProperties = "PointWidth=1";
            series9.EmptyPointStyle.Color = System.Drawing.Color.White;
            series9.Legend = "Legend1";
            series9.Name = "Neutral";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series10.Color = System.Drawing.Color.DarkRed;
            series10.CustomProperties = "PointWidth=1";
            series10.Legend = "Legend1";
            series10.Name = "Negative";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series10.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series11.Color = System.Drawing.Color.DarkBlue;
            series11.CustomProperties = "PointWidth=1";
            series11.Legend = "Legend1";
            series11.Name = "Postive";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series11.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series12.Color = System.Drawing.Color.Magenta;
            series12.CustomProperties = "PointWidth=1";
            series12.Legend = "Legend1";
            series12.Name = "Surprise";
            series12.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series12.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.subj0_hist.Series.Add(series9);
            this.subj0_hist.Series.Add(series10);
            this.subj0_hist.Series.Add(series11);
            this.subj0_hist.Series.Add(series12);
            this.subj0_hist.Size = new System.Drawing.Size(427, 124);
            this.subj0_hist.TabIndex = 27;
            this.subj0_hist.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(715, 530);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subj2_hist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj1_hist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subj0_hist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start_server;
        private System.Windows.Forms.TextBox msg_box;
        private System.Windows.Forms.Button stop_server;
        private System.ComponentModel.BackgroundWorker bg_worker1;
        private System.Windows.Forms.Button plot_all_button;
        private System.Windows.Forms.Button plot_gender_button;
        private System.Windows.Forms.Button plot_age_button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ageBox2;
        private System.Windows.Forms.TextBox genderBox2;
        private System.Windows.Forms.RichTextBox subjNameBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ageBox1;
        private System.Windows.Forms.TextBox genderBox1;
        private System.Windows.Forms.RichTextBox subjNameBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ageBox0;
        private System.Windows.Forms.TextBox genderBox0;
        private System.Windows.Forms.RichTextBox subjNameBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart subj2_hist;
        private System.Windows.Forms.DataVisualization.Charting.Chart subj1_hist;
        private System.Windows.Forms.DataVisualization.Charting.Chart subj0_hist;
    }
}

