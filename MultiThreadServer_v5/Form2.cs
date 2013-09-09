using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiThreadServer_v5
{
    public partial class Form2 : Form
    {
        public ArrayList hist_chart_list = new ArrayList();

        public Form2()
        {
            InitializeComponent();
            hist_chart_list.Add(subj1_hist_complete);
            hist_chart_list.Add(subj2_hist_complete);
            hist_chart_list.Add(subj3_hist_complete);
        }
    }
}
