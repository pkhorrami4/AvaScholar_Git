using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MathNet.Numerics.Interpolation;
using MathNet.Numerics.Signals;

namespace MultiThreadServer_v5
{
    class Stat_Comp
    {
        public List<Subj_Data> all_subj; 

        public Stat_Comp()
        {
            all_subj = new List<Subj_Data>();
        }

        public Stat_Comp(List<Subj_Data> subj_list)
        {
            this.all_subj = subj_list;
        }

        public double[] get_avg_seq(out double[] avg_signal)
        {
              
            // Build time and confidence series => determine min and max times to build interval

            int NUM_SUBJ = this.all_subj.Count;
            List<double> MIN_TICKS = new List<double>(NUM_SUBJ);
            List<double> MAX_TICKS = new List<double>(NUM_SUBJ);
            List<List<double>> TIMES = new List<List<double>>(NUM_SUBJ);

            List<List<float>> CONFID = new List<List<float>>(NUM_SUBJ);

            for (int i = 0; i < this.all_subj.Count; i++)
            {
                Subj_Data S = all_subj[i];
                TIMES.Add(new List<double>(S.get_pt_list().Count));
                //CONFID.Add(new List<float>(S.get_pt_list().Count));
                CONFID.Add(new List<float>(S.get_pt_list().Count));


                for (int j = 0; j < S.get_pt_list().Count; j++)
                {
                    TIMES[i].Add((double)S.get_pt_list()[j].time_stamp.Ticks);
                    //CONFID[i].Add(S.get_pt_list()[j].confid_score);
                    CONFID[i].Add(S.get_pt_list()[j].confid_score);
                }
                MIN_TICKS.Add(TIMES[i].Min());
                MAX_TICKS.Add(TIMES[i].Max());
            }
            double MIN_MIN = MIN_TICKS.Min();
            double MAX_MAX = MAX_TICKS.Max();

            // Subdivide interval in NUM_PTS sections
            double[] points;
            int NUM_PTS = 50;
            //SignalGenerator.EquidistantInterval(TargetFunction, MIN_MIN, MAX_MAX, NUM_PTS, out points);
            SignalGenerator.EquidistantInterval(delegate(double x) { return x; }, MIN_MIN, MAX_MAX, NUM_PTS, out points);

            // For each subject, and each section of the time interval, determine if subject is present
            // If so: averge the subject's confid. scores in the time interval and add it to the appropriate section
                   
            avg_signal = new double[NUM_PTS - 1];
            double[] subj_pres = new double[NUM_PTS - 1];

            for (int i = 0; i < NUM_SUBJ; i++)
            {
                Subj_Data S = all_subj[i];

                for (int j = 0; j < NUM_PTS - 1; j++)
                {
                    int first_ind = TIMES[i].FindIndex(delegate(double d)
                    {
                        return (d >= points[j] && d < points[j + 1]);
                    });

                    int last_ind = TIMES[i].FindLastIndex(delegate(double d)
                    {
                        return (d >= points[j] && d < points[j + 1]);
                    });

                    if (first_ind != -1 && last_ind != -1)
                    {
                        double[] vals_in_interval = new double[last_ind - first_ind + 1];

                        for (int k = first_ind; k <= last_ind; k++)
                        {
                            vals_in_interval[k - first_ind] = CONFID[i][k];
                        }
                        avg_signal[j] += vals_in_interval.Average();
                        subj_pres[j] += 1;
                    }
                }
            }

            // Look at each section, average over number of subjects that were present at the time
            for (int ii = 0; ii < NUM_PTS - 1; ii++)
            {
                if (subj_pres[ii] == 0)
                {
                    avg_signal[ii] = 0.0;
                }
                else
                {
                    avg_signal[ii] = avg_signal[ii] / subj_pres[ii];                    
                }
                //Console.Write(avg_signal[ii] + " "); 
            }
            //Console.WriteLine();           

            return points;
        }

        public double[] get_avg_seq_mask(double[] mask, out double[] avg_signal)
        {

            // Build time and confidence series => determine min and max times to build interval

            int NUM_SUBJ = this.all_subj.Count;
            List<double> MIN_TICKS = new List<double>(NUM_SUBJ);
            List<double> MAX_TICKS = new List<double>(NUM_SUBJ);
            List<List<double>> TIMES = new List<List<double>>(NUM_SUBJ);

            List<List<float>> CONFID = new List<List<float>>(NUM_SUBJ);            
            int COUNT = 0; // number of subject's that weren't filtered/masked out (i.e. sum(mask) )

            for (int i = 0; i < NUM_SUBJ; i++)
            {
                Subj_Data S = all_subj[i];
               
                if (mask[i] == 0.0) { continue; }

                TIMES.Add(new List<double>(S.get_pt_list().Count));
                //CONFID.Add(new List<float>(S.get_pt_list().Count));
                CONFID.Add(new List<float>(S.get_pt_list().Count));        

                for (int j = 0; j < S.get_pt_list().Count; j++)
                {
                    TIMES[COUNT].Add((double)S.get_pt_list()[j].time_stamp.Ticks);
                    //CONFID[i].Add(S.get_pt_list()[j].confid_score);
                    CONFID[COUNT].Add(S.get_pt_list()[j].confid_score);                    
                }
                MIN_TICKS.Add(TIMES[COUNT].Min());
                MAX_TICKS.Add(TIMES[COUNT].Max());

                COUNT++;
            }
            double MIN_MIN = MIN_TICKS.Min();
            double MAX_MAX = MAX_TICKS.Max();

            // Subdivide interval in NUM_PTS sections
            double[] points;
            int NUM_PTS = 50;
            //SignalGenerator.EquidistantInterval(TargetFunction, MIN_MIN, MAX_MAX, NUM_PTS, out points);
            SignalGenerator.EquidistantInterval(delegate(double x) { return x; }, MIN_MIN, MAX_MAX, NUM_PTS, out points);

            // For each subject, and each section of the time interval, determine if subject is present
            // If so: averge the subject's confid. scores in the time interval and add it to the appropriate section

            avg_signal = new double[NUM_PTS - 1];
            double[] subj_pres = new double[NUM_PTS - 1];

            for (int i = 0; i < COUNT; i++)
            {
                Subj_Data S = all_subj[i];

                //if (mask[i] == 0.0) { continue; }

                for (int j = 0; j < NUM_PTS - 1; j++)
                {
                    int first_ind = TIMES[i].FindIndex(delegate(double d)
                    {
                        return (d >= points[j] && d < points[j + 1]);
                    });

                    int last_ind = TIMES[i].FindLastIndex(delegate(double d)
                    {
                        return (d >= points[j] && d < points[j + 1]);
                    });

                    if (first_ind != -1 && last_ind != -1)
                    {
                        double[] vals_in_interval = new double[last_ind - first_ind + 1];
                        
                        for (int k = first_ind; k <= last_ind; k++)
                        {
                            vals_in_interval[k - first_ind] = CONFID[i][k];                            
                        }
                        avg_signal[j] += vals_in_interval.Average();
                        subj_pres[j] += 1;
                    }
                }
            }

            // Look at each section, average over number of subjects that were present at the time
            for (int ii = 0; ii < NUM_PTS - 1; ii++)
            {
                if (subj_pres[ii] == 0)
                {
                    avg_signal[ii] = 0.0;
                }
                else
                {
                    avg_signal[ii] = avg_signal[ii] / subj_pres[ii];                    
                }
                //Console.Write(avg_signal[ii] + " "); 
            }
            //Console.WriteLine();           

            return points;
        }

    }
}
