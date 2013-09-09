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


namespace ExpressionServer_v3
{
    public partial class Form1 : Form
    {
        Form2 F2 = new Form2();
        
        // DELEGATES
        delegate void ChartHistCallback(Subj_Data S);
        delegate void ClearChartHistCallback(int ID);
        delegate void MsgBoxCallback(string msg);
        delegate void AgeBoxCallback(Subj_Data S);
        delegate void GenderBoxCallback(Subj_Data S);
        // END DELEGATES

        // CLASS MEMBERS
        // Global Constants/Variables

        // Saved Client History
        List<Subj_Data> all_subj = new List<Subj_Data>();
        Stat_Comp sC;
        //List<Subj_Data> all_subj;

        // Collections to house form controls
        ArrayList hist_chart_list = new ArrayList();
        ArrayList age_list = new ArrayList();
        ArrayList gender_list = new ArrayList();


        const int NUM_FLOATS = 512; // Number of floating point numbers in a packet
        const int PACKET_LENGTH = NUM_FLOATS * sizeof(float); // Size of packet (in bytes)

        const int MAX_CLIENT_COUNT = 3;

        int[] occupied_flags = new int[MAX_CLIENT_COUNT]{0, 0, 0};
        Color[] color_list = { Color.Blue, Color.Green };// Color.Magenta, Color.Goldenrod, Color.Brown };
        private static Mutex mut = new Mutex();
        // END CLASS MEMBERS


        public Form1()
        {
            InitializeComponent();
            sC = new Stat_Comp(all_subj);
            hist_chart_list.Add(subj0_hist);
            hist_chart_list.Add(subj1_hist);
            hist_chart_list.Add(subj2_hist);
            gender_list.Add(genderBox0);
            gender_list.Add(genderBox1);
            gender_list.Add(genderBox2);
            age_list.Add(ageBox0);
            age_list.Add(ageBox1);
            age_list.Add(ageBox2);

            //this.WindowState = FormWindowState.Maximized;
            
            //F2.Show();
            //F2.WindowState = FormWindowState.Maximized;
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
            Int32 port = 1224;
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
                        write_to_msg_box("CLIENT FLAG ARRAY: " + occupied_flags[0].ToString() + " " + occupied_flags[1].ToString()+" "+occupied_flags[2].ToString());
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
            Subj_Data S = new Subj_Data(client, ID);
            // Object to get confid values based on 2D Gaussian
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


                    // Process float array and add exp scores to subj. list
                    //Console.WriteLine("{0} - elements in S", S.get_pt_list().Count);
                    float success_flag = process_float_data(float_array, S);
                    //Console.WriteLine("{0} - elements in S", S.get_pt_list().Count);

                    // Plot/log expression scores
                    if (success_flag == 1.0F)
                    {
                        write_pt_to_hist(S);
                    }
                    
                }

                stream.Close();
                client.Close();
                write_to_msg_box("Connection to Client " + Convert.ToString(S.get_ID()) + " Closed");

                // Set occupied flag back to 0 (need thread-safe call)
                mut.WaitOne();
                occupied_flags[ID] = 0; // atomic (?)
                write_to_msg_box("CLIENT FLAG ARRAY: " + occupied_flags[0].ToString() + " " + occupied_flags[1].ToString()+" "+occupied_flags[2].ToString());
                sC.all_subj.Add(S); 
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
                write_to_msg_box("CLIENT FLAG ARRAY: " + occupied_flags[0].ToString() + " " + occupied_flags[1].ToString()+" "+occupied_flags[2].ToString());
                sC.all_subj.Add(S); 
                mut.ReleaseMutex();

                //File_IO F = new File_IO();
                //F.write_subj_to_file(S);
                
            }
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
                //C.Series[0].Points.Clear();
                //C.Series[1].Points.Clear();
                //C.Series[2].Points.Clear();

                DataPointCollection pts0 = C.Series[0].Points;
                DataPointCollection pts1 = C.Series[1].Points;
                DataPointCollection pts2 = C.Series[2].Points;
                DataPointCollection pts3 = C.Series[3].Points;

                pts0.SuspendUpdates();
                pts1.SuspendUpdates();
                pts2.SuspendUpdates();
                pts3.SuspendUpdates();
                pts0.Clear();
                pts1.Clear();
                pts2.Clear();
                pts3.Clear();

                //chart1.ResetAutoValues();
                C.ChartAreas[0].AxisX.Minimum = 1.0;
                C.ChartAreas[0].AxisX.Maximum = 1.0;

                pts0.ResumeUpdates();
                pts1.ResumeUpdates();
                pts2.ResumeUpdates();
                pts3.ResumeUpdates();
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

        private float process_float_data(float[] input_array, Subj_Data S)
        {
            float frame_num = input_array[0];
            float success_flag = input_array[1];

            int ID = S.get_ID();

            if (success_flag == 0.0)
            {
                Console.WriteLine("{0}: Tracking Failure", Convert.ToInt32(frame_num));
                S.add_to_pt_list(new Exp_Data_Pt((int)frame_num, DateTime.Now, 0.0F, 0.0F, 0.0F, 0.0F));
            }
            else if (success_flag == 1.0)
            {
                float neu_score = input_array[2];
                float neg_score = input_array[3];
                float pos_score = input_array[4];
                float surp_score = input_array[5];

                Console.Write("{0}: Tracking Package", Convert.ToInt32(frame_num));
                S.add_to_pt_list(new Exp_Data_Pt((int)frame_num, DateTime.Now, neu_score, neg_score, pos_score, surp_score));
            }
            else if (success_flag == 2.0)
            {
                float age = input_array[2];
                float gender = input_array[3];

                Console.WriteLine("{0}: Age/Gender Package", Convert.ToInt32(frame_num));
                S.set_age(Convert.ToInt32(age));
                
                if (gender >= 0.5F)
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
                
            }
            return success_flag;
        }

        private void disp_age(Subj_Data S)
        {
            int ID = S.get_ID();
            if (((TextBox)this.age_list[ID]).InvokeRequired)
            {
                AgeBoxCallback a = new AgeBoxCallback(disp_age);
                this.Invoke(a, new object[]{ S });
            }
            else
            {
                TextBox t = (TextBox)this.age_list[ID];
                t.Text = Math.Round(S.get_age()).ToString();
            }
        }

        private void disp_gender(Subj_Data S)
        {
            int ID = S.get_ID();
            if (((TextBox)this.gender_list[ID]).InvokeRequired)
            {
                GenderBoxCallback g = new GenderBoxCallback(disp_gender);
                this.Invoke(g, new object[] { S });
            }
            else
            {
                TextBox t = (TextBox)this.gender_list[ID];
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


        private void write_pt_to_hist(Subj_Data S)
        {
            int frame_num = S.get_pt_list().Last().frame_num;
            int ID = S.get_ID();
            if (((Chart)this.hist_chart_list[ID]).InvokeRequired)
            {
                ChartHistCallback cH = new ChartHistCallback(write_pt_to_hist);
                this.Invoke(cH, new object[] { S });
            }
            else
            {
                Exp_Data_Pt exp_pt = S.get_pt_list().Last();

                Chart chart = (Chart)this.hist_chart_list[ID];
                chart.ChartAreas[0].AxisX.Maximum = frame_num; // display points up to current frame

                float SUM = (exp_pt.neu_score + exp_pt.neg_score + exp_pt.pos_score + exp_pt.surp_score);

                chart.Series[0].Points.AddXY(frame_num, exp_pt.neu_score/SUM);
                chart.Series[1].Points.AddXY(frame_num, exp_pt.neg_score/SUM);
                chart.Series[2].Points.AddXY(frame_num, exp_pt.pos_score/SUM);
                chart.Series[3].Points.AddXY(frame_num, exp_pt.surp_score/SUM);

                if (frame_num > 50)
                {
                    chart.ChartAreas[0].AxisX.Minimum = chart.ChartAreas[0].AxisX.Maximum - 50;
                }
            }
        }

        private void plot_all_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("HI - PLOT_ALL");                       
            //get_avg_seq();

            
            double[] avg_signal_neu, avg_signal_neg, avg_signal_pos, avg_signal_surp;
            double[] mask = new double[all_subj.Count];
            for (int i = 0; i < mask.Length; i++)
            {
                mask[i] = 1.0;
            }

            //Stat_Comp sC = new Stat_Comp(all_subj);          
            //double[] points = sC.get_avg_seq(out avg_signal_neu, out avg_signal_neg, out avg_signal_pos, out avg_signal_surp);
            double[] points = sC.get_avg_seq_mask(mask, out avg_signal_neu, out avg_signal_neg, out avg_signal_pos, out avg_signal_surp);
            display_avg_all_subj_stacked_column(points, avg_signal_neu, avg_signal_neg, avg_signal_pos, avg_signal_surp);

            F2.Show();
        }

        private void display_avg_all_subj_stacked_column(double[] pts, double[] avg_sig_neu, double[] avg_sig_neg, double[] avg_sig_pos, double[] avg_sig_surp)
        {
            F2.Avg_Stack_Hist.Series[0].Points.Clear();
            F2.Avg_Stack_Hist.Series[1].Points.Clear();
            F2.Avg_Stack_Hist.Series[2].Points.Clear();
            F2.Avg_Stack_Hist.Series[3].Points.Clear();

            double[] S = new double[avg_sig_neu.Length];

            for (int i = 0; i < avg_sig_neu.Length; i++)
            {
                S[i] = (avg_sig_neu[i]+avg_sig_neg[i]+avg_sig_pos[i]+avg_sig_surp[i]);
                DateTime T = new DateTime(Convert.ToInt64(pts[i]));

                F2.Avg_Stack_Hist.Series[0].Points.AddXY(T.ToLongTimeString(), 100*(avg_sig_neu[i]/S[i]));
                F2.Avg_Stack_Hist.Series[1].Points.AddXY(T.ToLongTimeString(), 100*(avg_sig_neg[i]/S[i]));
                F2.Avg_Stack_Hist.Series[2].Points.AddXY(T.ToLongTimeString(), 100*(avg_sig_pos[i]/S[i]));
                F2.Avg_Stack_Hist.Series[3].Points.AddXY(T.ToLongTimeString(), 100*(avg_sig_surp[i]/S[i]));

                //Console.WriteLine("ORIG: {0} - {1} - {2} - {3}", avg_sig_neu[i], avg_sig_neg[i], avg_sig_pos[i], avg_sig_surp[i]);
                //Console.WriteLine("SUM: {0}", S[i]);
                //Console.WriteLine("TRANSF: {0} - {1} - {2} - {3}", avg_sig_neu[i] / S[i], avg_sig_neg[i] / S[i], avg_sig_pos[i] / S[i], avg_sig_surp[i] / S[i]);
                //Console.WriteLine();
            }            
        }

        private void plot_gender_button_Click(object sender, EventArgs e)
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

            double[] avg_signal_neu_f, avg_signal_neg_f, avg_signal_pos_f, avg_signal_surp_f;
            double[] avg_signal_neu_m, avg_signal_neg_m, avg_signal_pos_m, avg_signal_surp_m;
            
            // Compute and display the female statistics
            if (female_mask.Sum() != 0.0)
            {
                double[] pts_f = sC.get_avg_seq_mask(female_mask, out avg_signal_neu_f, out avg_signal_neg_f, out avg_signal_pos_f, out avg_signal_surp_f);                
                display_avg_by_gender(0, pts_f, avg_signal_neu_f, avg_signal_neg_f, avg_signal_pos_f, avg_signal_surp_f);
            }

            // Compute and display the male statistics
            if (male_mask.Sum() != 0.0)
            {
                double[] pts_m = sC.get_avg_seq_mask(male_mask, out avg_signal_neu_m, out avg_signal_neg_m, out avg_signal_pos_m, out avg_signal_surp_m);
                display_avg_by_gender(1, pts_m, avg_signal_neu_m, avg_signal_neg_m, avg_signal_pos_m, avg_signal_surp_m);
            }

            F2.Show();
        }
        
        private void display_avg_by_gender(int gender_ind, double[] pts, double[] avg_sig_neu, double[] avg_sig_neg, double[] avg_sig_pos, double[] avg_sig_surp)
        {
            if(gender_ind !=0 && gender_ind != 1)
            {
                Console.WriteLine("PROBLEM Occured");
                return;
            }

            // gender_ind => 0 if female, 1 if male
            Chart stack_chart = (Chart)F2.stacked_chart_list_g[gender_ind];
            for (int i = 0; i < 4; i++)
            {
                stack_chart.Series[i].Points.Clear();
            }


            double S = 0.0;
            for (int i = 0; i < avg_sig_neu.Length; i++)
            {
                DateTime T = new DateTime(Convert.ToInt64(pts[i]));
                S = (avg_sig_neu[i] + avg_sig_neg[i] + avg_sig_pos[i] + avg_sig_surp[i]);
                stack_chart.Series[0].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_neu[i] / S));
                stack_chart.Series[1].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_neg[i] / S));
                stack_chart.Series[2].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_pos[i] / S));
                stack_chart.Series[3].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_surp[i] / S));                
            }
        }

        private void plot_age_button_Click(object sender, EventArgs e)
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

            double[] avg_signal_neu_u, avg_signal_neg_u, avg_signal_pos_u, avg_signal_surp_u;
            double[] avg_signal_neu_o, avg_signal_neg_o, avg_signal_pos_o, avg_signal_surp_o;

            // Compute and display the female statistics
            if (under25_mask.Sum() != 0.0)
            {
                double[] pts_u = sC.get_avg_seq_mask(under25_mask, out avg_signal_neu_u, out avg_signal_neg_u, out avg_signal_pos_u, out avg_signal_surp_u);
                display_avg_by_age(0, pts_u, avg_signal_neu_u, avg_signal_neg_u, avg_signal_pos_u, avg_signal_surp_u);
            }

            // Compute and display the male statistics
            if (over25_mask.Sum() != 0.0)
            {
                double[] pts_o = sC.get_avg_seq_mask(over25_mask, out avg_signal_neu_o, out avg_signal_neg_o, out avg_signal_pos_o, out avg_signal_surp_o);
                display_avg_by_age(1, pts_o, avg_signal_neu_o, avg_signal_neg_o, avg_signal_pos_o, avg_signal_surp_o);
            }

            F2.Show();
        }

        private void display_avg_by_age(int age_ind, double[] pts, double[] avg_sig_neu, double[] avg_sig_neg, double[] avg_sig_pos, double[] avg_sig_surp)
        {
            if (age_ind != 0 && age_ind != 1)
            {
                Console.WriteLine("PROBLEM Occured");
                return;
            }

            // gender_ind => 0 if female, 1 if male
            Chart stack_chart = (Chart)F2.stacked_chart_list_a[age_ind];
            for (int i = 0; i < 4; i++)
            {
                stack_chart.Series[i].Points.Clear();
            }


            double S = 0.0;
            for (int i = 0; i < avg_sig_neu.Length; i++)
            {
                DateTime T = new DateTime(Convert.ToInt64(pts[i]));
                S = (avg_sig_neu[i] + avg_sig_neg[i] + avg_sig_pos[i] + avg_sig_surp[i]);
                stack_chart.Series[0].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_neu[i] / S));
                stack_chart.Series[1].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_neg[i] / S));
                stack_chart.Series[2].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_pos[i] / S));
                stack_chart.Series[3].Points.AddXY(T.ToLongTimeString(), 100 * (avg_sig_surp[i] / S));
            }
        }

    }
}