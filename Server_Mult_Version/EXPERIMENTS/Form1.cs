using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;
using MathNet.Numerics.Distributions;

namespace EXPERIMENTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void disp_button_Click(object sender, EventArgs e)
        {
            /*
            Normal N = new Normal(0.0, 1.0);
            DenseVector VALS = new DenseVector(20, 0);
            for (int i = -10; i < 10; i++)
            {
                VALS[i + 10] = N.Density(i);
                Console.WriteLine(VALS[i + 10]);
            }
            */

            /*
            //double[] d = new double[]{0,0};
            DenseMatrix mu = new DenseMatrix(2, 1, new[] { 0.0, 0.0 });
            DenseMatrix K = new DenseMatrix(1, 1, new[] { 1.0 });
            DenseMatrix V = new DenseMatrix(2,2, new[] {4.0, 0.0, 0.0, 1.0 });
            MatrixNormal mN = new MatrixNormal(mu, V, K);


            Console.WriteLine(mu.RowCount);
            Console.WriteLine(mu.ColumnCount);
            Console.WriteLine(mN.Sample());
            Console.WriteLine(mN.Sample());
            DenseMatrix sample_pt = new DenseMatrix(2, 1, new[] { 0.0, 0.1 });
            double pt = mN.Density(sample_pt);
            */

            int M = 150;
            int N = 200;

            Normal N_x = new Normal(N/2, 50);
            Normal N_y = new Normal(M/2, 30);
           
            DenseMatrix M_x = new DenseMatrix(M, N, 0.0);
            DenseMatrix M_y = new DenseMatrix(M, N, 0.0);

            DenseVector V_x = new DenseVector(N);
            for (int i = 0; i < N; i++)
            {
                V_x[i] = N_x.Density(i);
            }

            for (int j = 0; j < M; j++)
            {
                M_x.SetRow(j, V_x);
            }


            DenseVector V_y = new DenseVector(M);
            for (int i = 0; i < M; i++)
            {
                V_y[i] = N_y.Density(i);
            }

            for (int j = 0; j < N; j++)
            {
                M_y.SetColumn(j, V_y);
            }

            DenseMatrix MULT = (DenseMatrix)M_x.PointwiseMultiply(M_y);
            double s = MULT.Data.Sum();
            MULT = (DenseMatrix)MULT.PointwiseDivide(new DenseMatrix(M,N,s));
            //this.dataGridView1.DataSource = MULT;
            //Console.WriteLine(MULT.Data.Sum());

            s = MULT[M / 2, N / 2];
            MULT = (DenseMatrix)MULT.PointwiseDivide(new DenseMatrix(M, N, s));

            /*
            for (int i = 0; i < M; i++)
            {
                Console.Write(i + " - ");
                for (int j = 0; j < N; j++)
                {
                    Console.Write(MULT[i, j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            */
            Console.WriteLine(Environment.ProcessorCount);
            
        }
    }
}
