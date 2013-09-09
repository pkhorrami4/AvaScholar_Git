using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThreadServer_v5
{
    class Gaze_Data_Pt
    {
        // Not good style, but necesssary
        public int frame_num;
        public Point_Obj gaze_pt;
        public DateTime time_stamp;
        public float confid_score;
        //public int MONITOR_DIM_X;
        //public int MONITOR_DIM_Y;

        public Gaze_Data_Pt()
        {
            this.frame_num = 0;
            this.gaze_pt = new Point_Obj(0.0F, 0.0F);
            this.time_stamp = DateTime.Now;
            this.confid_score = 0.0F;
            //this.MONITOR_DIM_X = 0;
            //this.MONITOR_DIM_Y = 0;
        }

        public Gaze_Data_Pt(int frame_num, Point_Obj gaze_pt, DateTime time_stamp, float confid_score, int MONITOR_DIM_X, int MONITOR_DIM_Y)
        {
            this.frame_num = frame_num;
            this.gaze_pt = gaze_pt;
            this.time_stamp = time_stamp;
            this.confid_score = confid_score;
            //this.MONITOR_DIM_X = MONITOR_DIM_X;
            //this.MONITOR_DIM_Y = MONITOR_DIM_Y;
        }

    }
}
