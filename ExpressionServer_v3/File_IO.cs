using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ExpressionServer_v3
{
    class File_IO
    {
        public void write_subj_to_file(Subj_Data S)
        {
            Console.WriteLine("WRITING GAZE PT DATA TO FILE");
            //String out_path = Path.GetFullPath(System.Environment.GetCommandLineArgs()[1]);
            //String filename = out_path + "\\OUT_S" + Convert.ToString(S.get_ID()) + ".txt";

            String filename = @"C:\Users\pkhorra2\Documents\AvaScholar\Attention_Detector\C#_Proj\Server_Mult_Version\MultiThreadServer_w_log\out.txt";

            StreamWriter sW = new StreamWriter(filename);
            //ArrayList gaze_pts = S.get_gaze_pts();
            List<Exp_Data_Pt> gaze_pts = S.get_pt_list();
            for (int i = 0; i < gaze_pts.Count; i++)
            {
                //Point_Obj g = gaze_pts[i].gaze_pt;
                //DateTime T = gaze_pts[i].time_stamp;      
                //sW.WriteLine("({0}, {1}) -- TIME: " + T.ToString(), g.get_x(), g.get_y()); //T.ToString());                
                //sW.WriteLine("TICKS: {0}", T.Ticks);
            }
            sW.Flush();
            sW.Close();
            Console.WriteLine("DONE WRITING");
        }
    }
}