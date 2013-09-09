using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using MathNet.Numerics.Interpolation;
using MathNet.Numerics.Signals;


namespace MultiThreadServer_v5
{
    public partial class Form1 : Form
    {
        Form2 F2 = new Form2();        
        
        // DELEGATES
        delegate void AgeBoxCallback(Subj_Data S);
        delegate void AlertBoxCallback(int distracted_flag, int ID);
        delegate void ChartHistCallback(Point_Obj p, Screen_Prob_Map p_m, Subj_Data S, int frame_num);
        delegate void ClearChartHistCallback(int ID);
        delegate void GazeChartCallback(Point_Obj p, Subj_Data S);
        delegate void GenderBoxCallback(Subj_Data S);
        delegate void MsgBoxCallback(string msg);
        // END DELEGATES

        // CLASS MEMBERS
        // Global Constants/Variables

        // Saved Client History
        List<Subj_Data> all_subj = new List<Subj_Data>();

        // Collections to house form controls
        ArrayList alert_box_list = new ArrayList();
        ArrayList hist_chart_list = new ArrayList();
        ArrayList age_box_list = new ArrayList();
        ArrayList gender_box_list = new ArrayList();

        // Monitor Dimensions (in mm)
        // Dell P2211H
        //const int MONITOR_DIM_X = 513; 
        //const int MONITOR_DIM_Y = 348; 

        // Lenovo Thinkpad 14
        //const int MONITOR_DIM_X = 343;
        //const int MONITOR_DIM_Y = 234;

        // Lenovo Thinkpad T410
        //const int MONITOR_DIM_X = 334;
        //const int MONITOR_DIM_Y = 239;

        // Dell Precision M90
        //const int MONITOR_DIM_X = 394;
        //const int MONITOR_DIM_Y = 288;

        const int DISTRACT_WINDOW = 50;
        const int POINTS_TO_SHOW = 30;

        const int NUM_FLOATS = 512; // Number of floating point numbers in a packet
        const int PACKET_LENGTH = NUM_FLOATS * sizeof(float); // Size of packet (in bytes)

        const int MAX_CLIENT_COUNT = 3;

        int[] occupied_flags = new int[MAX_CLIENT_COUNT]{0, 0, 0};
        Color[] color_list = { Color.Blue, Color.Green, Color.Magenta }; //, Color.Goldenrod, Color.Brown };
        private static Mutex mut = new Mutex();
        Stat_Comp sC;
        // END CLASS MEMBERS


        public Form1()
        {
            InitializeComponent();
            
            alert_box_list.Add(alert_box0);
            alert_box_list.Add(alert_box1);
            alert_box_list.Add(alert_box2);

            hist_chart_list.Add(subj0_hist);
            hist_chart_list.Add(subj1_hist);
            hist_chart_list.Add(subj2_hist);

            gender_box_list.Add(genderBox1);
            gender_box_list.Add(genderBox2);
            gender_box_list.Add(genderBox3);

            age_box_list.Add(ageBox1);
            age_box_list.Add(ageBox2);
            age_box_list.Add(ageBox3);

            sC = new Stat_Comp(all_subj);
            //F2.Show();
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


            TcpClient client = null;
            write_to_msg_box("Waiting for connection: \n");
            int client_ID = 0;


            while (true)
            {
                if (bg_worker1.CancellationPending == true)
                {
                    //write_to_msg_box("BG Worker Stopping the Server");
                    server.Stop();
                    Thread.Sleep(500);
                    break;
                }
                else
                {
                    client = server.AcceptTcpClient();

                    if (occupied_flags.Sum() < MAX_CLIENT_COUNT)
                    {
                        //write_to_msg_box("HERE - 1");
                        mut.WaitOne();
                        int i;
                        for (i = 0; i < MAX_CLIENT_COUNT; i++)
                        {
                            if (occupied_flags[i] == 0)
                            {
                                break;
                            }
                        }
                        client_ID = i;
                        occupied_flags[i] = 1; // atmoic (?)
                        write_to_msg_box("CLIENT FLAG ARRAY: " + occupied_flags[0].ToString() + " " + occupied_flags[1].ToString());
                        mut.ReleaseMutex();

                        //client = server.AcceptTcpClient();
                        //write_to_msg_box("Client "+Convert.ToString(client_ID)+" Connected!!\n");
                        ThreadStart start = delegate { serve_client(client, client_ID); };
                        Thread T = new Thread(start);                        
                        T.Start();
                        Thread.Sleep(500);
                        //client_ID = client_ID ^ 1;
                        /*
                        // Write Subj. to a file                    
                        //File_IO F = new File_IO();
                        //F.write_subj_to_file(S);
                         */
                    }
                    else
                    {
                        //write_to_msg_box("Here - 2");
                        client.Close();
                        //Console.WriteLine("Clients Running...");
                        write_to_msg_box("Clients Running...");
                        continue;
                    }
                }
            }
        }


        public void serve_client(TcpClient client, int ID)
        {
            write_to_msg_box("Client " + Convert.ToString(ID) + " Connected!!\n");
            NetworkStream stream = client.GetStream();
            // Array to store incoming data
            Byte[] bytes = new Byte[PACKET_LENGTH];

            //int MONITOR_DIM_X = 394;
            //int MONITOR_DIM_Y = 288;
            int MONITOR_DIM_X = 513; 
            int MONITOR_DIM_Y = 348; 
            //int MONITOR_DIM_X = 334;
            //int MONITOR_DIM_Y = 239;

            // Object to store information about subject
            Subj_Data S = new Subj_Data(client, 0, ID, MONITOR_DIM_X, MONITOR_DIM_Y);
            // Object to get confid values based on 2D Gaussian
            Screen_Prob_Map p_m = new Screen_Prob_Map(MONITOR_DIM_X, MONITOR_DIM_Y, 200, 100);
            int i;

            clear_chart(ID);

            try
            {
                while ((i = stream.Read(bytes, 0, PACKET_LENGTH)) != 0)
                {
                    // Convert byte array to float
                    float[] float_array = new float[NUM_FLOATS];
                    Console.Write("\n"+Convert.ToString(ID)+" - ");
                    for (int ii = 0; ii < float_array.Length; ii++)
                    {
                        float_array[ii] = BitConverter.ToSingle(bytes, ii * sizeof(float));
                        if (ii < 11)
                            Console.Write(float_array[ii] + " ");
                    }
                    //Console.Write("\n");

                    Console.Write("\n" + Convert.ToString(ID) + " - ");
                    for (int ii = 256; ii < float_array.Length; ii++)
                    {
                        float_array[ii] = BitConverter.ToSingle(bytes, ii * sizeof(float));
                        if (ii < 267)
                            Console.Write(float_array[ii] + " ");
                    }
                    Console.Write("\n");


                    // Process float array and get estimated gaze point
                    Point_Obj est_gaze_pt = process_float_data(float_array, S);

                    // Log estimated gaze point
                    //S.get_gaze_pts().Add(est_gaze_pt);
                    double confid_score = p_m.look_up_value(Convert.ToInt32(-est_gaze_pt.get_x()), Convert.ToInt32(est_gaze_pt.get_y()) + S.get_MONITOR_DIM_Y()/2 );
                    S.add_to_pt_list(new Gaze_Data_Pt((int)float_array[0], est_gaze_pt, DateTime.Now, Convert.ToSingle(confid_score), S.get_MONITOR_DIM_X(), S.get_MONITOR_DIM_Y() ));
                    //Console.WriteLine("{0} - CONFID_SCORE - in loop - {1}", ID, confid_score);
                    //Console.WriteLine("EST GAZE PT1: {0}", est_gaze_pt);

                    // Check if subject is distracted                    
                    S = check_if_distract(S, est_gaze_pt);
                    //Console.WriteLine("{0} - NUM DISTRACT FRAMES: {1}", S.get_ID(), S.get_num_frames_distracted());
                    if (S.get_num_frames_distracted() > DISTRACT_WINDOW)
                    {
                        write_to_alert_box(1, S.get_ID());
                    }
                    else
                    {
                        write_to_alert_box(0, S.get_ID());
                    }

                    //write_pt_to_hist(est_gaze_pt, ID, Convert.ToInt32(float_array[0]));

                    //Console.WriteLine("EST GAZE PT2: {0}", est_gaze_pt);
                    write_pt_to_hist(est_gaze_pt, p_m, S, Convert.ToInt32(float_array[0]));

                    
                }

                stream.Close();
                client.Close();
                write_to_msg_box("Connection to Client " + Convert.ToString(S.get_ID()) + " Closed");

                // Set occupied flag back to 0 (need thread-safe call)
                mut.WaitOne();
                occupied_flags[ID] = 0; // atomic (?)
                write_to_msg_box("CLIENT FLAG ARRAY: " + occupied_flags[0].ToString() + " " + occupied_flags[1].ToString());
                all_subj.Add(S); 
                mut.ReleaseMutex();

                //File_IO F = new File_IO();
                //F.write_subj_to_file(S);

            }
            catch (Exception EE)
            {
                Console.WriteLine("EXCEPTION: {0}\n", EE.Message);
                //all_subj.Add(S);
                stream.Close();
                client.Close();
                write_to_msg_box("Connection to Client "+Convert.ToString(S.get_ID())+" Closed");

                // Set occupied flag back to 0 (need thread-safe call)
                mut.WaitOne();
                occupied_flags[ID] = 0; // atomic (?)
                write_to_msg_box("CLIENT FLAG ARRAY: " + occupied_flags[0].ToString() + " " + occupied_flags[1].ToString());
                all_subj.Add(S); 
                mut.ReleaseMutex();

                //File_IO F = new File_IO();
                //F.write_subj_to_file(S);
                
            }
            //all_subj.Add(S); 


            // Set occupied flag back to 0 (need thread-safe call)
            //mut.WaitOne();
            //occupied_flags[ID] = 0; // atomic (?)
            //mut.ReleaseMutex();
        }


        private void clear_chart(int ID)
        {
            if (((Chart)this.hist_chart_list[ID]).InvokeRequired)
            {
                ClearChartHistCallback ccH = new ClearChartHistCallback(clear_chart);
                this.Invoke(ccH, new object[] { ID });
            }
            else
            {
                Chart C = (Chart)this.hist_chart_list[ID];
                C.Series["Series1"].Points.Clear();

                DataPointCollection pts = C.Series[0].Points;
                pts.SuspendUpdates();
                pts.Clear();
                //chart1.ResetAutoValues();
                C.ChartAreas[0].AxisX.Minimum = 1.0;
                C.ChartAreas[0].AxisX.Maximum = 1.0;
                pts.ResumeUpdates();
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
                //Thread.Sleep(500);
            }

        }

        private void write_to_alert_box(int distracted_flag, int ID)
        {            
            if ( ((TextBox)this.alert_box_list[ID]).InvokeRequired)
            {
                AlertBoxCallback a = new AlertBoxCallback(write_to_alert_box);
                this.Invoke(a, new object[] { distracted_flag, ID });
            }
            else
            {
                TextBox BOX = (TextBox)alert_box_list[ID];
                if (distracted_flag == 1)
                {
                    BOX.BackColor = Color.Red;
                    BOX.ForeColor = Color.White;
                    BOX.Text = "SUBJECT "+Convert.ToString(ID)+ " NOT ENGAGED!!";
                }
                else
                {
                    BOX.BackColor = Color.White;
                    BOX.Text = "";
                }
            }
        }

        private void disp_age(Subj_Data S)
        {
            int ID = S.get_ID();
            if (((TextBox)this.age_box_list[ID]).InvokeRequired)
            {
                AgeBoxCallback a = new AgeBoxCallback(disp_age);
                this.Invoke(a, new object[] { S });
            }
            else
            {
                TextBox t = (TextBox)this.age_box_list[ID];
                t.Text = Math.Round(S.get_age()).ToString();
            }
        }

        private void disp_gender(Subj_Data S)
        {
            int ID = S.get_ID();
            if (((TextBox)this.gender_box_list[ID]).InvokeRequired)
            {
                GenderBoxCallback g = new GenderBoxCallback(disp_gender);
                this.Invoke(g, new object[] { S });
            }
            else
            {
                TextBox t = (TextBox)this.gender_box_list[ID];
                //t.Text = Math.Round(S.get_age()).ToString();
                char gender = S.get_gender();
                if (gender == 'F')
                {
                    t.BackColor = Color.Indigo;
                    t.ForeColor = Color.White;
                    t.Text = "FEMALE";
                }
                else
                {
                    t.BackColor = Color.DimGray;
                    t.ForeColor = Color.White;
                    t.Text = "MALE";
                }
            }
        }

        private Point_Obj process_float_data(float[] input_array, Subj_Data S)
        {
            float frame_num = input_array[0];
            float success_flag = input_array[1];


            if (success_flag == 1.0)
            {
                Console.WriteLine("{0}: Gaze Pt Package", Convert.ToInt32(frame_num));

                Point_Obj left_eye = new Point_Obj(input_array[2], input_array[3], input_array[4]);
                Point_Obj right_eye = new Point_Obj(input_array[5], input_array[6], input_array[7]);

                float alpha = input_array[8] * 180;
                float beta = input_array[9] * 180;
                float gamma = input_array[10] * 180;
                int ID = S.get_ID();

                Gaze_Comp G = new Gaze_Comp();
                Point_Obj p = G.get_gaze_pt(right_eye, left_eye, alpha, beta, gamma);
                Console.WriteLine("{0} - GAZE POINT (X, Y): ({1}, {2})", ID, p.get_x(), p.get_y());
                Point_Obj disp_pt = new Point_Obj(-p.get_x(), p.get_y() + S.get_MONITOR_DIM_Y() / 2);
                plot_gaze_point(disp_pt, S);
                Console.WriteLine("{0} - TRANSF GAZE POINT (X, Y): ({1}, {2})", ID, disp_pt.get_x(), disp_pt.get_y());

                return p;
            }
            else if(success_flag == 2.0)
            {
                float age = input_array[2];
                float gender = input_array[3];

                Console.WriteLine("{0}: Age/Gender Package", Convert.ToInt32(frame_num));
                S.set_age(Convert.ToDouble(age));
                
                if (gender >= 0.5)
                {
                    // Male
                    S.set_gender('M');
                }
                else
                {
                    // Female
                    S.set_gender('F');
                }

                disp_age(S);
                disp_gender(S);


                if (S.get_pt_list().Count != 0)
                {
                    return S.get_pt_list().Last().gaze_pt;
                }
                else
                {
                    return new Point_Obj(0.0F, -S.get_MONITOR_DIM_Y()/2);
                }
            }
            else
            {
                Console.WriteLine("{0}: Tracking Failure", Convert.ToInt32(frame_num));
                //Point_Obj Gaze_Pt = new Point_Obj(Single.PositiveInfinity, Single.PositiveInfinity);
                Point_Obj disp_pt_f = new Point_Obj(-1000F, -1000F);
                plot_gaze_point(disp_pt_f, S);
                //disp_pt_f.set_coord(Single.PositiveInfinity, Single.PositiveInfinity, 0);
                return disp_pt_f;
            }
        }

        private void plot_gaze_point(Point_Obj p, Subj_Data S)
        {
            if (this.gaze_plot.InvokeRequired)
            {
                //ChartCallback c = new ChartCallback(plot_point);
                GazeChartCallback gC = new GazeChartCallback(plot_gaze_point);
                this.Invoke(gC, new object[] { p, S });
            }
            else
            {             
                this.gaze_plot.Series["Series1"].Points.AddXY(p.get_x(), p.get_y());
                int L = this.gaze_plot.Series["Series1"].Points.Count;
                int MONITOR_DIM_X = S.get_MONITOR_DIM_X();
                int MONITOR_DIM_Y = S.get_MONITOR_DIM_Y();
                int ID = S.get_ID();

                if (p.get_x() < -MONITOR_DIM_X / 2 || p.get_x() > MONITOR_DIM_X / 2)
                {
                    //Console.WriteLine("POINT RED!");
                    this.gaze_plot.Series["Series1"].Points[L - 1].Color = Color.Red;
                }
                else if (p.get_y() < -MONITOR_DIM_Y / 2 || p.get_y() > MONITOR_DIM_Y / 2)
                {
                    //Console.WriteLine("POINT RED!");
                    this.gaze_plot.Series["Series1"].Points[L - 1].Color = Color.Red;
                }
                else
                {
                    //Console.WriteLine("POINT BLUE!");
                    this.gaze_plot.Series["Series1"].Points[L - 1].Color = color_list[ID];
                }
                
                if(L > POINTS_TO_SHOW)
                {
                    this.gaze_plot.Series["Series1"].Points.RemoveAt(0);                    
                }
                
            }

        }

        private Subj_Data check_if_distract(Subj_Data S, Point_Obj est_gaze_pt)
        {
            int MONITOR_DIM_X = S.get_MONITOR_DIM_X();
            int MONITOR_DIM_Y = S.get_MONITOR_DIM_Y();

            //Console.WriteLine("INPUT PT: {0}", est_gaze_pt.ToString());
            //est_gaze_pt.set_coord(-est_gaze_pt.get_x(), est_gaze_pt.get_y() + MONITOR_DIM_Y / 2, est_gaze_pt.get_z());
            Point_Obj disp_pt = new Point_Obj(-est_gaze_pt.get_x(), est_gaze_pt.get_y() + MONITOR_DIM_Y / 2, est_gaze_pt.get_z());

            int cur_num_frames_distracted = S.get_num_frames_distracted();
            if (disp_pt.get_x() < -MONITOR_DIM_X / 2 || disp_pt.get_x() > MONITOR_DIM_X / 2)
            {
                //Console.WriteLine("INCREMENT!");
                S.set_num_frames_distracted(++cur_num_frames_distracted);
            }
            else if (disp_pt.get_y() < -MONITOR_DIM_Y / 2 || disp_pt.get_y() > MONITOR_DIM_Y / 2)
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

        private void write_pt_to_hist(Point_Obj p, Screen_Prob_Map p_m, Subj_Data S, int frame_num)
        {
            int ID = S.get_ID();
            if (((Chart)this.hist_chart_list[ID]).InvokeRequired)
            {
                ChartHistCallback cH = new ChartHistCallback(write_pt_to_hist);
                this.Invoke(cH, new object[] { p, p_m, S, frame_num });
            }
            else
            {
                Chart chart = (Chart)this.hist_chart_list[ID];
                chart.ChartAreas[0].AxisX.Maximum = frame_num; // display points up to current frame

                Chart chart_f2 = (Chart)F2.hist_chart_list[ID];

                int MONITOR_DIM_X = S.get_MONITOR_DIM_X();
                int MONITOR_DIM_Y = S.get_MONITOR_DIM_Y();

                // convert gaze point (world coordinates) => monitor coordinates
                p.set_coord(-p.get_x(), p.get_y() + MONITOR_DIM_Y / 2, p.get_z());


                if (p.get_x() < -MONITOR_DIM_X / 2 || p.get_x() > MONITOR_DIM_X / 2)
                {
                    chart.Series["Series1"].Points.AddXY(frame_num, 0.0F);
                    Console.WriteLine("{0} - Confid Score: {1}", ID, 0.0F);
                    
                    chart_f2.Series[0].Points.AddXY(DateTime.Now.ToLongTimeString(), 0.0F);
                }
                else if (p.get_y() < -MONITOR_DIM_Y / 2 || p.get_y() > MONITOR_DIM_Y / 2)
                {
                    chart.Series["Series1"].Points.AddXY(frame_num, 0.0F);
                    Console.WriteLine("{0} - Confid Score: {1}", ID, 0.0F);
                    
                    chart_f2.Series[0].Points.AddXY(DateTime.Now.ToLongTimeString(), 0.0F);
                }
                else
                {
                    //chart.Series["Series1"].Points.AddXY(frame_num, 0);
                    //double D = p_m.look_up_value(Convert.ToInt32(-p.get_x()), Convert.ToInt32(p.get_y()) + MONITOR_DIM_Y / 2);
                    double D = p_m.look_up_value(Convert.ToInt32(p.get_x()), Convert.ToInt32(p.get_y()));
                    Console.WriteLine("{0} - Confid Score: {1}", ID, D);
                    //Console.WriteLine("Adding Point "+D.ToString());
                    chart.Series["Series1"].Points.AddXY(frame_num, Convert.ToSingle(D));
                    //write_to_msg_box(frame_num.ToString() + " " + D.ToString());
                    
                    chart_f2.Series[0].Points.AddXY(DateTime.Now.ToLongTimeString(), Convert.ToSingle(D));
                }

                if (frame_num > 100)
                {
                    chart.ChartAreas[0].AxisX.Minimum = chart.ChartAreas[0].AxisX.Maximum - 100;
                }

            }

        }

        private void plot_all_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("HI - PLOT_ALL");                       
            get_avg_seq();
        }

        private void get_avg_seq()
        {
            // Build time and confidence series => determine min and max times to build interval

            int NUM_SUBJ = this.all_subj.Count;
            List<double> MIN_TICKS = new List<double>(NUM_SUBJ);
            List<double> MAX_TICKS = new List<double>(NUM_SUBJ);
            List<List<double>> TIMES = new List<List<double>>(NUM_SUBJ);
            List<List<float>> CONFID = new List<List<float>>(NUM_SUBJ);

            for (int i = 0; i < this.all_subj.Count; i++)
            {
                Subj_Data S = all_subj[i];
                TIMES.Add(new List<double>(S.get_pt_list().Count));
                CONFID.Add(new List<float>(S.get_pt_list().Count));
                for (int j = 0; j < S.get_pt_list().Count; j++)
                {
                    TIMES[i].Add((double)S.get_pt_list()[j].time_stamp.Ticks);
                    CONFID[i].Add(S.get_pt_list()[j].confid_score);
                }
                MIN_TICKS.Add(TIMES[i].Min());
                MAX_TICKS.Add(TIMES[i].Max());
            }
            double MIN_MIN = MIN_TICKS.Min();
            double MAX_MAX = MAX_TICKS.Max();
            
            // Subdivide interval in NUM_PTS sections
            double[] points;
            int NUM_PTS = 50;
            //SignalGenerator.EquidistantInterval(TargetFunction, MIN_MIN, MAX_MAX, NUM_PTS, out points);
            SignalGenerator.EquidistantInterval(delegate(double x) { return x; }, MIN_MIN, MAX_MAX, NUM_PTS, out points);

            // For each subject, and each section of the time interval, determine if subject is present
            // If so: averge the subject's confid. scores in the time interval and add it to the appropriate section
            double[] avg_signal = new double[NUM_PTS-1];
            double[] subj_pres = new double[NUM_PTS-1];
            
            for (int i = 0; i < NUM_SUBJ; i++)
            {
                Subj_Data S = all_subj[i];
                
                for (int j = 0; j < NUM_PTS-1; j++)
                {
                    int first_ind = TIMES[i].FindIndex(delegate(double d)
                    {
                        return (d >= points[j] && d < points[j+1]);
                    });

                    int last_ind = TIMES[i].FindLastIndex(delegate(double d)
                    {
                        return (d >= points[j] && d < points[j + 1]);
                    });

                    if (first_ind != -1 && last_ind != -1)
                    {
                        double[] vals_in_interval = new double[last_ind - first_ind + 1];
                        for (int k = first_ind; k <= last_ind; k++)
                        {
                            vals_in_interval[k - first_ind] = CONFID[i][k];
                        }
                        avg_signal[j] += vals_in_interval.Average();
                        subj_pres[j] += 1;
                    }
                }
            }

            // Look at each section, average over number of subjects that were present at the time
            for (int ii = 0; ii < NUM_PTS - 1; ii++)
            {
                if (subj_pres[ii] == 0)
                {
                    avg_signal[ii] = 0.0;
                }
                else
                {
                    avg_signal[ii] = avg_signal[ii] / subj_pres[ii];
                }
                Console.Write(avg_signal[ii] + " "); 
            }
            Console.WriteLine();

            // Smooth out empty intervals
            for (int i = 1; i < avg_signal.Length-1; i++)
            {
                if (avg_signal[i] == 0.0)
                {
                    avg_signal[i] = (avg_signal[i - 1] + avg_signal[i + 1]) / 2;
                }
            }


            display_avg(points, avg_signal);
        }

        private void display_avg(double[] pts, double[] avg_sig)
        {

            this.Avg_Chart.Series[0].Points.Clear();
            for (int i = 0; i < avg_sig.Length; i++)
            {
                          
                DateTime T = new DateTime(Convert.ToInt64(pts[i]));
                //this.cum_chart.Series[series_str].Points.AddXY(T.ToLongTimeString(), avg_sig[i]);
                this.Avg_Chart.Series[0].Points.AddXY(T.ToLongTimeString(), avg_sig[i]);
                F2.Avg_Chart.Series[0].Points.AddXY(T.ToLongTimeString(), avg_sig[i]);                
            }

            //this.cum_chart.Visible = true;

        }

        private void plot_all_gender_Click(object sender, EventArgs e)
        {            
            double[] female_mask = new double[all_subj.Count];
            double[] male_mask = new double[all_subj.Count];
            for (int i = 0; i < male_mask.Length; i++)
            {
                if (all_subj[i].get_gender() == 'M')
                {
                    male_mask[i] = 1.0;
                }
                else
                {
                    female_mask[i] = 1.0;
                }
            }

            double[] avg_signal_f;
            double[] avg_signal_m;

            // Compute and display the female statistics
            if (female_mask.Sum() != 0.0)
            {
                double[] pts_f = sC.get_avg_seq_mask(female_mask, out avg_signal_f);
                display_avg_by_gender(0, pts_f, avg_signal_f);
            }

            // Compute and display the male statistics
            if (male_mask.Sum() != 0.0)
            {
                double[] pts_m = sC.get_avg_seq_mask(male_mask, out avg_signal_m);
                display_avg_by_gender(1, pts_m, avg_signal_m);
            }
        }

        private void display_avg_by_gender(int gender_ind, double[] pts, double[] avg_sig)
        {
            if (gender_ind != 0 && gender_ind != 1)
            {
                Console.WriteLine("PROBLEM Occured");
                return;
            }

            // gender_ind => 0 if female, 1 if male
            Chart c;
            if (gender_ind == 0)
            {
                c = avg_female_chart;
                c.Series[0].Points.Clear();
            }
            else
            {
                c = avg_male_chart;
                c.Series[0].Points.Clear();
            }

            for (int i = 0; i < avg_sig.Length; i++)
            {
                DateTime T = new DateTime(Convert.ToInt64(pts[i]));
                c.Series[0].Points.AddXY(T.ToLongTimeString(), avg_sig[i]);
            }
        }

        private void plot_all_age_Click(object sender, EventArgs e)
        {
            double[] under25_mask = new double[all_subj.Count];
            double[] over25_mask = new double[all_subj.Count];
            for (int i = 0; i < under25_mask.Length; i++)
            {
                if (all_subj[i].get_age() <= 25)
                {
                    under25_mask[i] = 1.0;
                }
                else
                {
                    over25_mask[i] = 1.0;
                }

            }

            double[] avg_signal_u;
            double[] avg_signal_o;

            // Compute and display the female statistics
            if (under25_mask.Sum() != 0.0)
            {
                double[] pts_u = sC.get_avg_seq_mask(under25_mask, out avg_signal_u);
                display_avg_by_age(0, pts_u, avg_signal_u);
            }

            // Compute and display the male statistics
            if (over25_mask.Sum() != 0.0)
            {
                double[] pts_o = sC.get_avg_seq_mask(over25_mask, out avg_signal_o);
                display_avg_by_age(1, pts_o, avg_signal_o);
            }

        }

        private void display_avg_by_age(int age_ind, double[] pts, double[] avg_sig)
        {
            if (age_ind != 0 && age_ind != 1)
            {
                Console.WriteLine("PROBLEM Occured");
                return;
            }

            Chart c;
            if (age_ind == 0)
            {
                c = avg_u25_chart;
                c.Series[0].Points.Clear();
            }
            else
            {
                c = avg_o25_chart;
                c.Series[0].Points.Clear();
            }

            
            for (int i = 0; i < avg_sig.Length; i++)
            {
                DateTime T = new DateTime(Convert.ToInt64(pts[i]));   
                c.Series[0].Points.AddXY(T.ToLongTimeString(), avg_sig[i]);
            }
        }



    }
}
