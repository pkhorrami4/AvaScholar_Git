using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double;


namespace MultiThreadServer_v5
{
    class Screen_Prob_Map
    {
        private int X;
        private int Y;

        private double STD_X;
        private double STD_Y;

        private DenseMatrix PROB_MAP_ORIG;
        private DenseMatrix PROB_MAP;

        private double[,] PROB_MAP_simple;

        public Screen_Prob_Map()
        {
            X = 200;
            Y = 150;
            STD_X = 50;
            STD_Y = 30;

            //build_prob_map();
            build_prob_map_simple();
        }

        public Screen_Prob_Map(int X, int Y, double STD_X, double STD_Y)
        {
            this.X = X;
            this.Y = Y;
            this.STD_X = STD_X;
            this.STD_Y = STD_Y;

            //build_prob_map();   
            build_prob_map_simple();
        }

        public void build_prob_map()
        {

            Normal N_x = new Normal(X / 2, STD_X);
            Normal N_y = new Normal(Y / 2, STD_Y);

            DenseMatrix M_x = new DenseMatrix(Y, X, 0.0);
            DenseMatrix M_y = new DenseMatrix(Y, X, 0.0);

            DenseVector V_x = new DenseVector(X);
            for (int i = 0; i < X; i++)
            {
                V_x[i] = N_x.Density(i);
            }

            for (int j = 0; j < Y; j++)
            {
                M_x.SetRow(j, V_x);
            }


            DenseVector V_y = new DenseVector(Y);
            for (int i = 0; i < Y; i++)
            {
                V_y[i] = N_y.Density(i);
            }

            for (int j = 0; j < X; j++)
            {
                M_y.SetColumn(j, V_y);
            }

            DenseMatrix MULT = (DenseMatrix)M_x.PointwiseMultiply(M_y);
            double s = MULT.Data.Sum();
            MULT = (DenseMatrix)MULT.PointwiseDivide(new DenseMatrix(Y, X, s));
            //this.dataGridView1.DataSource = MULT;
            //Console.WriteLine(MULT.Data.Sum());
            PROB_MAP_ORIG = MULT;

            s = MULT[Y / 2, X / 2];
            MULT = (DenseMatrix)MULT.PointwiseDivide(new DenseMatrix(Y, X, s));

            /*
            for (int i = 0; i < Y; i++)
            {
                Console.Write(i + " - ");
                for (int j = 0; j < X; j++)
                {
                    Console.Write(MULT[i, j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            */
            PROB_MAP = MULT;

        }


        public void build_prob_map_simple()
        {
            // Uses explicit math formulas instead of Math.Net Library
            PROB_MAP_simple = new double[Y, X];
            for (int j = 0; j < Y; j++)
            {
                for (int i = 0; i < X; i++)
                {
                    PROB_MAP_simple[j, i] = Math.Exp((-0.5) * (Math.Pow((Convert.ToDouble(i) - (Convert.ToDouble(X) / 2)) / (STD_X), 2) + Math.Pow((Convert.ToDouble(j) - (Convert.ToDouble(Y) / 2)) / (STD_Y), 2)));
                }
            }
        }


        public double look_up_value(int u, int v)
        {
            u = u + this.X / 2;
            v = v + this.Y / 2;

            if ( (u < 0) || (u >= this.X) )
            {
                return 0;
            }
            else if ( (v < 0) || (v >= this.Y) )
            {
                return 0;
            }            
            else
            {
                return PROB_MAP_simple[v,u];
                //return PROB_MAP[v, u];
            }
        }

        public double look_up_value_orig(int u, int v)
        {
            u = u + this.X / 2;
            v = v + this.Y / 2;

            if ((u < 0) || (u >= this.X))
            {
                return 0;
            }
            else if ((v < 0) || (v >= this.Y))
            {
                return 0;
            }
            else
            {
                return PROB_MAP_ORIG[v, u];
            }
        }
    }
}
