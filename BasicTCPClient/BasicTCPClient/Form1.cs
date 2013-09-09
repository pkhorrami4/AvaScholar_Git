using System;
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

namespace BasicTCPClient
{
    public partial class Form1 : Form
    {
        delegate void MsgBoxCallback(string msg);
        delegate char GenderBoxCallback();
        delegate int AgeBoxCallback();

        public Form1()
        {
            InitializeComponent();
        }

        private void start_client_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                write_to_msg_box("Client Started!\n");
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                write_to_msg_box("Client already running\n");
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            // Create a TcpClient. 
            // Note, for this client to work you need to have a TcpServer  
            // connected to the same address as specified by the server, port 
            // combination.
            //Int32 port = 13000;
            Int32 port = 1223;

            //TcpClient client = new TcpClient("ifp-33.ifp.uiuc.edu", port);
            //TcpClient client = new TcpClient("172.16.231.228" , port);
            String hostname = Environment.GetCommandLineArgs()[1].ToString();
            TcpClient client = new TcpClient(hostname, port);

            Byte[] data;
            NetworkStream stream = client.GetStream();
            Random rnd = new Random();
            int frame_count = 0;

            float cur_X = 0.0F;
            float cur_Y = -289.0F;

            while (true)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    // Close everything.
                    stream.Close();
                    client.Close();
                    break;
                }
                
      
                // Translate the passed message into ASCII and store it as a Byte array.
                //String data_str = Math.Round(rnd.NextDouble(),2).ToString()+"\n\0"; 
                //String data_str = Math.Round(rnd.NextDouble(),2).ToString() + " " + Math.Round(rnd.NextDouble(),2).ToString() + " " + Math.Round(rnd.NextDouble(),2).ToString();
                //String pos_str = Math.Round(rnd.NextDouble() * 100 + 1).ToString() + " " + Math.Round(rnd.NextDouble() * 100 + 1).ToString()+" "+(0.0).ToString();
                //data = System.Text.Encoding.ASCII.GetBytes(data_str+" "+pos_str+"\n\0");
                
                // Get a client stream for reading and writing. 
                //  Stream stream = client.GetStream();
                //stream = client.GetStream();

                float[] data_f = new float[512];
               
                if (frame_count == 0)
                {                   
                    data_f[1] = 2.0F;

                    int age = get_age();
                    data_f[2] = Convert.ToSingle(age);

                    char gender = this.get_gender();
                    if (gender == 'M')
                    {
                        data_f[3] = 1.0F;
                    }
                    else
                    {
                        data_f[3] = 0.0F;
                    }  
                }
                else
                {
                    //float X = (float)(-416 + (832) * rnd.NextDouble());
                    //float Y = (float)(-557 + 557 * rnd.NextDouble());
                    float theta = (float)(-179 + 360 * rnd.NextDouble());
                    float R = 20;
                    
                    data_f[0] = Convert.ToSingle(frame_count);
                    data_f[1] = 1.0F;
                    data_f[2] = cur_X+R*Convert.ToSingle(Math.Cos(theta));
                    data_f[3] = cur_Y+R*Convert.ToSingle(Math.Sin(theta));
                    data_f[4] = -150.0F;
                    data_f[5] = data_f[2]-100.0F;
                    data_f[6] = data_f[3];
                    data_f[7] = -150.0F;
                    data_f[8] = 0.0F;
                    data_f[9] = 0.0F;
                    data_f[10] = 0.0F;

                    cur_X = data_f[2];
                    cur_Y = data_f[3];
                }
                frame_count++;

                data = new Byte[512*sizeof(float)];
                int byte_count = 0;
                for (int ii = 0; ii < 512; ii++)
                {
                    byte[] byte_rep = BitConverter.GetBytes(data_f[ii]);
                    data[byte_count] = byte_rep[0];
                    data[byte_count + 1] = byte_rep[1];
                    data[byte_count + 2] = byte_rep[2];
                    data[byte_count + 3] = byte_rep[3];
                    byte_count += 4;
                }
                

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                Console.WriteLine("{0} bytes sent.", data.Length);

                //Console.WriteLine("Sent: {0}", "Hello!!");
                //write_to_msg_box(data_str);
                Thread.Sleep(250);


            }
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                msg_box.AppendText("Stopping the Client!!\n");
                backgroundWorker1.CancelAsync();
                msg_box.AppendText("Client Stopped!!\n");
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

        private char get_gender()
        {
            if (this.genderBox.InvokeRequired)
            {
                GenderBoxCallback c = new GenderBoxCallback(get_gender);
                return (char)this.Invoke(c, new object[] { });
            }
            else
            {
                return Convert.ToChar(genderBox.SelectedItem);
            }
        }

        private int get_age()
        {
            if (this.ageBox.InvokeRequired)
            {
                AgeBoxCallback a = new AgeBoxCallback(get_age);
                return (int)this.Invoke(a, new object[] { });
            }
            else
            {
                return Convert.ToInt32(ageBox.SelectedItem);
            }

        }

    }
}
