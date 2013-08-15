using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Text;

namespace BasicTCPServer_v1
{
    class Subj
    {
        TcpClient client;
        int num_frames_distracted;
        int ID;
        ArrayList gaze_pts;

        public Subj()
        {
            this.client = null;
            this.num_frames_distracted = 0;
            this.ID = 0;
            gaze_pts = new ArrayList();
        }

        public Subj(TcpClient client, int num_frames_distracted, int ID)
        {
            this.client = client;
            this.num_frames_distracted = num_frames_distracted;
            this.ID = ID;
            this.gaze_pts = new ArrayList();
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

        public ArrayList get_gaze_pts()
        {
            return gaze_pts;
        }
    }
}
