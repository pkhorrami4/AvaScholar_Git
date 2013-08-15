using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace MultiThreadServer
{
    public partial class Form1 : Form
    {
        
        // DELEGATES

        delegate void AlertBoxCallback(int distracted_flag, int ID);
        delegate void ChartHistCallback(Point_Obj p, Screen_Prob_Map p_m, int ID, int frame_num);
        delegate void ClearChartHistCallback(int ID);
        delegate void GazeChartCallback(Point_Obj p, int ID);
        delegate void MsgBoxCallback(string msg);

        // END DELEGATES

        // CLASS MEMBERS

        // Global Constants/Variables

        // Saved Client History
        ArrayList all_subj = new ArrayList();

        // Collections to house form controls
        ArrayList alert_box_list = new ArrayList();
        ArrayList hist_chart_list = new ArrayList();

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
        const int POINTS_TO_SHOW = 30;

        const int NUM_FLOATS = 512; // Number of floating point numbers in a packet
        const int PACKET_LENGTH = NUM_FLOATS * sizeof(float); // Size of packet (in bytes)

        const int MAX_CLIENT_COUNT = 2;

        int[] occupied_flags = new int[MAX_CLIENT_COUNT]{0, 0};
        Color[] color_list = { Color.Blue, Color.Green };// Color.Magenta, Color.Goldenrod, Color.Brown };
        private static Mutex mut = new Mutex();
        // END CLASS MEMBERS


        public Form1()
        {
            InitializeComponent();
            alert_box_list.Add(alert_box0);
            alert_box_list.Add(alert_box1);
            hist_chart_list.Add(subj0_hist);
            hist_chart_list.Add(subj1_hist);
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
            // Object to store information about subject
            Subj S = new Subj(client, 0, ID);
            // Object to get confid values based on 2D Gaussian
            Screen_Prob_Map p_m = new Screen_Prob_Map(MONITOR_DIM_X, MONITOR_DIM_Y, 250, 100);
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
                    Console.Write("\n");

                    // Process float array and get estimated gaze point
                    Point_Obj est_gaze_pt = process_float_data(float_array, S.get_ID());

                    // Log estimated gaze point
                    S.get_gaze_pts().Add(est_gaze_pt);

                    // Check if subject is distracted                    
                    S = check_if_distract(S, est_gaze_pt);
                    Console.WriteLine("{0} - NUM DISTRACT FRAMES: {1}", S.get_ID(), S.get_num_frames_distracted());
                    if (S.get_num_frames_distracted() > DISTRACT_WINDOW)
                    {
                        write_to_alert_box(1, S.get_ID());
                    }
                    else
                    {
                        write_to_alert_box(0, S.get_ID());
                    }

                    //write_pt_to_hist(est_gaze_pt, ID, Convert.ToInt32(float_array[0]));

                    write_pt_to_hist(est_gaze_pt, p_m, ID, Convert.ToInt32(float_array[0]));

                    
                }

                stream.Close();
                client.Close();
                write_to_msg_box("Connection to Client " + Convert.ToString(S.get_ID()) + " Closed");

                // Set occupied flag back to 0 (need thread-safe call)
                mut.WaitOne();
                occupied_flags[ID] = 0; // atomic (?)
                write_to_msg_box("CLIENT FLAG ARRAY: " + occupied_flags[0].ToString() + " " + occupied_flags[1].ToString());
                mut.ReleaseMutex();

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
                mut.ReleaseMutex();
                
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

        private Point_Obj process_float_data(float[] input_array, int ID)
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
                Point_Obj disp_pt_f = new Point_Obj(-1000F, -1000F);
                plot_gaze_point(disp_pt_f, ID);
                //disp_pt_f.set_coord(Single.PositiveInfinity, Single.PositiveInfinity, 0);
                return disp_pt_f;
            }


            Gaze_Comp G = new Gaze_Comp();
            Point_Obj p = G.get_gaze_pt(right_eye, left_eye, alpha, beta, gamma);
            Console.WriteLine("{0} - GAZE POINT (X, Y): ({1}, {2})", ID, p.get_x(), p.get_y());
            Point_Obj disp_pt = new Point_Obj(-p.get_x(), p.get_y()+ MONITOR_DIM_Y/2);
            plot_gaze_point(disp_pt, ID);
            Console.WriteLine("{0} - TRANSF GAZE POINT (X, Y): ({1}, {2})", ID, disp_pt.get_x(), disp_pt.get_y());

            return p;
        }


        private void plot_gaze_point(Point_Obj p, int ID)
        {
            if (this.gaze_plot.InvokeRequired)
            {
                //ChartCallback c = new ChartCallback(plot_point);
                GazeChartCallback gC = new GazeChartCallback(plot_gaze_point);
                this.Invoke(gC, new object[] { p, ID });
            }
            else
            {             
                this.gaze_plot.Series["Series1"].Points.AddXY(p.get_x(), p.get_y());
                int L = this.gaze_plot.Series["Series1"].Points.Count;

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


        private void write_pt_to_hist(Point_Obj p, Screen_Prob_Map p_m, int ID, int frame_num)
        {

            if (((Chart)this.hist_chart_list[ID]).InvokeRequired)
            {
                ChartHistCallback cH = new ChartHistCallback(write_pt_to_hist);
                this.Invoke(cH, new object[] { p, p_m, ID, frame_num });
            }
            else
            {
                Chart chart = (Chart)this.hist_chart_list[ID];
                chart.ChartAreas[0].AxisX.Maximum = frame_num; // display points up to current frame

                if (p.get_x() < -MONITOR_DIM_X / 2 || p.get_x() > MONITOR_DIM_X / 2)
                {
                    chart.Series["Series1"].Points.AddXY(frame_num, 0.0F);
                }
                else if (p.get_y() < -MONITOR_DIM_Y / 2 || p.get_y() > MONITOR_DIM_Y / 2)
                {
                    chart.Series["Series1"].Points.AddXY(frame_num, 0.0F);
                }
                else
                {
                    //chart.Series["Series1"].Points.AddXY(frame_num, 0);
                    double D = p_m.look_up_value(Convert.ToInt32(p.get_x()) + MONITOR_DIM_X / 2, Convert.ToInt32(p.get_y()) + MONITOR_DIM_Y / 2);
                    //Console.WriteLine(D);
                    //Console.WriteLine("Adding Point "+D.ToString());
                    chart.Series["Series1"].Points.AddXY(frame_num, Convert.ToSingle(D));
                    //write_to_msg_box(frame_num.ToString() + " " + D.ToString());

                }

                if (frame_num > 100)
                {
                    chart.ChartAreas[0].AxisX.Minimum = chart.ChartAreas[0].AxisX.Maximum - 100;
                }

            }

        }
    }
}
