using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Text;

namespace MultiThreadServer_v5
{
    class Subj_Data
    {
        private TcpClient client;
        private int MONITOR_DIM_X;
        private int MONITOR_DIM_Y;
        private int num_frames_distracted;
        private int ID;
        //private ArrayList gaze_pts;
        private List<Gaze_Data_Pt> pt_list;
        private double age;
        private char gender;

        public Subj_Data()
        {
            this.client = null;
            this.num_frames_distracted = 0;
            this.ID = 0;
            this.pt_list = new List<Gaze_Data_Pt>();
            this.MONITOR_DIM_X = 0;
            this.MONITOR_DIM_Y = 0;
            this.age = 0;
            this.gender = 'M';
            //gaze_pts = new ArrayList();
        }

        public Subj_Data(TcpClient client, int num_frames_distracted, int ID, int MONITOR_DIM_X, int MONITOR_DIM_Y)
        {
            this.client = client;
            this.num_frames_distracted = num_frames_distracted;
            this.ID = ID;
            this.pt_list = new List<Gaze_Data_Pt>();
            this.MONITOR_DIM_X = MONITOR_DIM_X;
            this.MONITOR_DIM_Y = MONITOR_DIM_Y;
            this.age = 0;
            this.gender = 'M';
            //this.gaze_pts = new ArrayList();
        }

        public TcpClient get_client()
        {
            return client;
        }

        public void set_num_frames_distracted(int nF)
        {
            this.num_frames_distracted = nF;
        }

        public int get_num_frames_distracted()
        {
            return num_frames_distracted;
        }

        public int get_ID()
        {
            return ID;
        }

        public int get_MONITOR_DIM_X()
        {
            return MONITOR_DIM_X;
        }

        public int get_MONITOR_DIM_Y()
        {
            return MONITOR_DIM_Y;
        }

        public void set_MONITOR_DIM_X(int m_X)
        {
            MONITOR_DIM_X = m_X;
        }

        public void set_MONITOR_DIM_Y(int m_Y)
        {
            MONITOR_DIM_Y = m_Y;
        }

        public void set_MONITOR_DIMS(int m_X, int m_Y)
        {
            MONITOR_DIM_X = m_X;
            MONITOR_DIM_Y = m_Y;
        }
        //public ArrayList get_gaze_pts()
        //{
        //    return gaze_pts;
        //}

        public List<Gaze_Data_Pt> get_pt_list()
        {
            return pt_list;
        }

        public void add_to_pt_list(Gaze_Data_Pt in_gaze_pt)
        {
            pt_list.Add(in_gaze_pt);
        }

        public void set_age(double age)
        {
            this.age = age;
        }

        public void set_gender(char gender)
        {
            this.gender = gender;
        }

        public double get_age()
        {
            return this.age;
        }

        public char get_gender()
        {
            return this.gender;
        }

    }
}
