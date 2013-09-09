using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Text;

namespace ExpressionServer_v3
{
    class Subj_Data
    {
        private TcpClient client;
        private int ID;
        private List<Exp_Data_Pt> pt_list;
        private int age;
        private char gender;

        public Subj_Data()
        {
            this.client = null;
            this.ID = 0;
            this.pt_list = new List<Exp_Data_Pt>();
            this.age = 25;
            this.gender = 'F';
        }

        public Subj_Data(TcpClient client, int ID)
        {
            this.client = client;
            this.ID = ID;
            this.pt_list = new List<Exp_Data_Pt>();
            this.age = 25;
            this.gender = 'F';
        }

        public TcpClient get_client()
        {
            return client;
        }

        public int get_ID()
        {
            return ID;
        }

        public List<Exp_Data_Pt> get_pt_list()
        {
            return pt_list;
        }

        public char get_gender()
        {
            return gender;
        }

        public double get_age()
        {
            return age;
        }


        public void add_to_pt_list(Exp_Data_Pt in_gaze_pt)
        {
            pt_list.Add(in_gaze_pt);
        }

        public void set_age(int age)
        {
            this.age = age;
        }

        public void set_gender(char gender)
        {
            this.gender = gender;
        }
    }
}
