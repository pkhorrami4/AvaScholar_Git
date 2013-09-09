using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpressionServer_v3
{
    public partial class Form2 : Form
    {
        public ArrayList stacked_chart_list_g = new ArrayList();
        public ArrayList stacked_chart_list_a = new ArrayList();

        public Form2()
        {
            InitializeComponent();

            stacked_chart_list_g.Add(female_avg_stack_hist);
            stacked_chart_list_g.Add(male_avg_stack_hist);
            //stacked_chart_list.Add(Avg_Stack_Hist);

            stacked_chart_list_a.Add(under25_avg_hist);
            stacked_chart_list_a.Add(over25_avg_hist);
        }
    }
}
