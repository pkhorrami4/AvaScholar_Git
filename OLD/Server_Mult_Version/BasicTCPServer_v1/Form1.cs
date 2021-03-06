﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace BasicTCPServer_v1
{
    public partial class Form1 : Form
    {
        delegate void AlertBoxCallback(int distracted_flag);
        delegate void ChartAxisCallback();
        delegate void ChartCallback(string series, double pt);
        delegate void GazeChartCallback(Point_Obj p);
        delegate void MsgBoxCallback(string msg);


        // Saved Datapoints
        ArrayList all_subj = new ArrayList();

        // Monitor Dimensions (in mm)
        // Dell P2211H
        const int MONITOR_DIM_X = 513; 
        const int MONITOR_DIM_Y = 348; 

        // Lenovo Thinkpad 14
        //const int MONITOR_DIM_X = 343;
        //const int MONITOR_DIM_Y = 234;

        // Lenovo Thinkpad T410
        //const int MONITOR_DIM_X = 334;
        //const int MONITOR_DIM_Y = 239;

        const int DISTRACT_WINDOW = 50;
        const int POINTS_TO_SHOW = 25;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_server_Click(object sender, EventArgs e)
        {
            if (bg_worker1.IsBusy != true)
            {
                msg_box.AppendText("Server Started!!\n");
                bg_worker1.RunWorkerAsync();
            }
            else
            {
                msg_box.AppendText("Server has already started\n");
            }
        }

        private void stop_server_Click(object sender, EventArgs e)
        {
            if (bg_worker1.WorkerSupportsCancellation == true)
            {
                msg_box.AppendText("Stopping the Server!!\n");
                bg_worker1.CancelAsync();
                msg_box.AppendText("Server Stopped!!\n");
            }
        }

        private void bg_worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Int32 port = 13000;
            Int32 port = 1223;
            //IPAddress localAddr = IPAddress.Parse("130.126.122.122");
            //IPAddress localAddr = IPAddress.Any;

            TcpListener server = null;
            //server = new TcpListener(localAddr, port);
            server = new TcpListener(port);

            // Start listening for client requests.
            server.Start();


            // Buffer for reading data
            int num_floats = 512; // number of floating point numbers in each packet
            int packet_length = num_floats * sizeof(float); // (in bytes)
            Byte[] bytes = new Byte[packet_length];
            TcpClient client = null;
            NetworkStream stream = null;
            write_to_msg_box("Waiting for connection: \n");
            Subj S = new Subj();

            while (true)
            {
                if (bg_worker1.CancellationPending == true)
                {
                    server.Stop();
                    Thread.Sleep(500);
                    break;
                }
                else
                {
                    try
                    {
                        //write_to_msg_box("In BG_Do_WORK\n");
                        client = server.AcceptTcpClient();
                        write_to_msg_box("Client Connected!!\n");
                        stream = client.GetStream();

                        S = new Subj(client, 0, all_subj.Count);

                        int i;                                                                        
                        while ((i = stream.Read(bytes, 0, packet_length)) != 0)
                        {                            
                            // Convert byte array to float
                            float[] float_array = new float[num_floats];
                            for (int ii = 0; ii < float_array.Length; ii++)
                            {
                                float_array[ii] = BitConverter.ToSingle(bytes, ii * sizeof(float));
                                if (ii < 11)
                                    Console.Write(float_array[ii] + " ");
                            }
                            Console.Write("\n\n");

                            // Process float array and get estimated gaze point
                            Point_Obj est_gaze_pt = process_float_data(float_array);

                            // Log estimated gaze point
                            S.get_gaze_pts().Add(est_gaze_pt);

                            // Check if subject is distracted
                            S = check_if_distract(S, est_gaze_pt);
                            Console.WriteLine("NUM DISTRACT FRAMES: {0}", S.get_num_frames_distracted());
                            if (S.get_num_frames_distracted() > DISTRACT_WINDOW)
                            {
                                write_to_alert_box(1);
                            }
                            else
                            {
                                write_to_alert_box(0);
                            }
                        }

                        all_subj.Add(S);                    
                        stream.Close();
                        client.Close();
                        write_to_msg_box("Connection Closed");
                    }
                    catch (Exception EE)
                    {
                        Console.WriteLine("EXCEPTION: {0}", EE.Message);
                        all_subj.Add(S);
                        stream.Close();
                        client.Close();
                        write_to_msg_box("Connection Closed");
                    }

                    // Write Subj. to a file                    
                    File_IO F = new File_IO();
                    F.write_subj_to_file(S);
                }
                     
            }
        }

        private void write_to_msg_box(string msg)
        {
            if (this.msg_box.InvokeRequired)
            {
                MsgBoxCallback d = new MsgBoxCallback(write_to_msg_box);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                msg_box.AppendText(msg+"\n");
                Thread.Sleep(500);

            }

        }

        private void write_to_alert_box(int distracted_flag)
        {
            if (this.alert_box.InvokeRequired)
            {
                AlertBoxCallback a = new AlertBoxCallback(write_to_alert_box);
                this.Invoke(a, new object[] { distracted_flag });
            }
            else
            {
                if (distracted_flag == 1)
                {
                    this.alert_box.BackColor = Color.Red;
                    this.alert_box.ForeColor = Color.White;
                    this.alert_box.Text = "SUBJECT NOT ENGAGED!!";
                }
                else
                {
                    this.alert_box.BackColor = Color.White;
                    this.alert_box.Text = "";
                }
            }

        }

        private Point_Obj process_float_data(float[] input_array)
        {
            float frame_num = input_array[0];
            float success_flag = input_array[1];
            Point_Obj left_eye = new Point_Obj(input_array[2], input_array[3], input_array[4]);
            Point_Obj right_eye = new Point_Obj(input_array[5], input_array[6], input_array[7]);

            float alpha = input_array[8]*180;
            float beta = input_array[9]*180;
            float gamma = input_array[10]*180;

            if (success_flag == 0.0)
            {
                Console.WriteLine("{0}: Tracking Failure", Convert.ToInt32(frame_num));
                //Point_Obj Gaze_Pt = new Point_Obj(Single.PositiveInfinity, Single.PositiveInfinity);
                Point_Obj disp_pt_f = new Point_Obj(-1000, -1000);
                plot_gaze_point(disp_pt_f);
                disp_pt_f.set_coord(Single.PositiveInfinity, Single.PositiveInfinity, 0);
                return disp_pt_f;
            }


            Gaze_Comp G = new Gaze_Comp();
            Point_Obj p = G.get_gaze_pt(right_eye, left_eye, alpha, beta, gamma);
            Console.WriteLine("GAZE POINT (X, Y): ({0}, {1})", p.get_x(), p.get_y());
            Point_Obj disp_pt = new Point_Obj(-p.get_x(), p.get_y()+ MONITOR_DIM_Y/2);
            plot_gaze_point(disp_pt);
            Console.WriteLine("TRANSF GAZE POINT (X, Y): ({0}, {1})", disp_pt.get_x(), disp_pt.get_y());

            // Plot Rotation Angles
            plot_point("Pitch", Convert.ToDouble(alpha));
            plot_point("Yaw", Convert.ToDouble(beta));
            plot_point("Roll", Convert.ToDouble(gamma));
            set_axis();

            return p;
        }


        private void plot_gaze_point(Point_Obj p)
        {
            if (this.chart2.InvokeRequired)
            {
                //ChartCallback c = new ChartCallback(plot_point);
                GazeChartCallback gC = new GazeChartCallback(plot_gaze_point);
                this.Invoke(gC, new object[] { p });
            }
            else
            {             
                this.chart2.Series["Series1"].Points.AddXY(p.get_x(), p.get_y());
                int L = this.chart2.Series["Series1"].Points.Count;

                if (p.get_x() < -MONITOR_DIM_X / 2 || p.get_x() > MONITOR_DIM_X / 2)
                {
                    //Console.WriteLine("POINT RED!");
                    this.chart2.Series["Series1"].Points[L - 1].Color = Color.Red;
                }
                else if (p.get_y() < -MONITOR_DIM_Y / 2 || p.get_y() > MONITOR_DIM_Y / 2)
                {
                    //Console.WriteLine("POINT RED!");
                    this.chart2.Series["Series1"].Points[L - 1].Color = Color.Red;
                }
                else
                {
                    //Console.WriteLine("POINT BLUE!");
                    this.chart2.Series["Series1"].Points[L - 1].Color = Color.Blue;
                }
                
                if(L > POINTS_TO_SHOW)
                {
                    //DataPoint d = new DataPoint(this.chart2.Series["Series1"].Points[0].XValue, this.chart2.Series["Series1"].Points[0].YValues[0]);                    
                    //saved_pts.Add(d);
                    this.chart2.Series["Series1"].Points.RemoveAt(0);                    
                }
                
            }

        }

        private Subj check_if_distract(Subj S, Point_Obj est_gaze_pt)
        {
            //Console.WriteLine("INPUT PT: {0}", est_gaze_pt.ToString());
            est_gaze_pt.set_coord(-est_gaze_pt.get_x(), est_gaze_pt.get_y() + MONITOR_DIM_Y / 2, est_gaze_pt.get_z());


            int cur_num_frames_distracted = S.get_num_frames_distracted();
            if (est_gaze_pt.get_x() < -MONITOR_DIM_X / 2 || est_gaze_pt.get_x() > MONITOR_DIM_X / 2)
            {
                //Console.WriteLine("INCREMENT!");
                S.set_num_frames_distracted(++cur_num_frames_distracted);
            }
            else if (est_gaze_pt.get_y() < -MONITOR_DIM_Y / 2 || est_gaze_pt.get_y() > MONITOR_DIM_Y / 2)
            {
                //Console.WriteLine("INCREMENT!!");
                S.set_num_frames_distracted(++cur_num_frames_distracted);
            }
            else
            {
                //Console.WriteLine("RESET");
                S.set_num_frames_distracted(0);
            }

            //Console.WriteLine("NUM DISTRACT FRAMES PRIOR: {0}", S.get_num_frames_distracted()); 

            return S;
        }

        private void process_data(string input_str)
        {
            string[] S = input_str.Split();
            //Console.WriteLine(S[0]);
            //Console.WriteLine(S[1]);
            //Console.WriteLine(S[2]);
            Console.WriteLine("{0} numbers present\n", S.Length);


            //double[] d = new double[S.Length];
            double[] d = new double[3];
            for (int i = 0; i < 3; i++)
            {
                d[i] = Convert.ToDouble(S[i]);
            }
            double avg = d.Average();
            Console.WriteLine("AVG = {0}", avg);


            // Add average to time series
            plot_point("Series1", avg);
            set_axis();
            //this.chart1.Series["Series1"].Points.AddY(avg);
            //this.chart1.ChartAreas[0].AxisX.Minimum = this.chart1.ChartAreas[0].AxisX.Maximum - 20;


        }

        private void plot_point(string series, double pt)
        {
            if (this.chart1.InvokeRequired)
            {
                ChartCallback c = new ChartCallback(plot_point);
                this.Invoke(c, new object[] { series, pt });
            }
            else
            {
                this.chart1.Series[series].Points.AddY(pt);
            }
        }

        private void set_axis()
        {
            if (this.chart1.InvokeRequired)
            {
                ChartAxisCallback c = new ChartAxisCallback(set_axis);
                this.Invoke(c, new object[] { });
            }
            else
            {
                this.chart1.ChartAreas[0].AxisX.Minimum = this.chart1.ChartAreas[0].AxisX.Maximum - 20;
            }
        }

        private void Test_Calc_Click(object sender, EventArgs e)
        {
            write_to_msg_box("TESTING CALCULATIONS!");
            Gaze_Comp G = new Gaze_Comp();
            Point_Obj P = G.get_gaze_pt(new Point_Obj(379, 165), new Point_Obj(439, 171), 45, 30, 60);
            P.set_coord(10, 10, 10);
            plot_gaze_point(P);
        }

       
    }
}
