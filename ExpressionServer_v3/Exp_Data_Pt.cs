using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionServer_v3
{
    class Exp_Data_Pt
    {
        // Not good style, but necesssary
        public int frame_num;
        public DateTime time_stamp;        
        public float neu_score;
        public float neg_score;
        public float pos_score;
        public float surp_score;

        public Exp_Data_Pt()
        {
            this.frame_num = 0;
            this.time_stamp = DateTime.Now;
            this.neu_score = 0.0F;
            this.neg_score = 0.0F;
            this.pos_score = 0.0F;
            this.surp_score = 0.0F;
        }

        public Exp_Data_Pt(int frame_num, DateTime time_stamp, float neu_score, float neg_score, float pos_score, float surp_score)
        {
            this.frame_num = frame_num;
            this.time_stamp = time_stamp;
            this.neu_score = neu_score;
            this.neg_score = neg_score;
            this.pos_score = pos_score;
            this.surp_score = surp_score;
        }

    }
}
