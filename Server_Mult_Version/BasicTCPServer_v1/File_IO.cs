using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace BasicTCPServer_v1
{
    class File_IO
    {
        public void write_subj_to_file(Subj S)
        {
            Console.WriteLine("WRITING GAZE PT DATA TO FILE");
            String out_path = Path.GetFullPath(System.Environment.GetCommandLineArgs()[1]);
            String filename = out_path + "\\OUT_S" + Convert.ToString(S.get_ID()) + ".txt";

            StreamWriter sW = new StreamWriter(filename);
            ArrayList gaze_pts = S.get_gaze_pts();
            for(int i=0; i<gaze_pts.Count; i++)
            {
                Point_Obj g = (Point_Obj)gaze_pts[i];
                sW.WriteLine("({0}, {1})", g.get_x(), g.get_y());
            }
            sW.Flush();
            sW.Close();
            Console.WriteLine("DONE WRITING");
        }
    }
}