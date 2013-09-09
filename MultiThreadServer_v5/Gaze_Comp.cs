using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;


namespace MultiThreadServer_v5
{
    class Gaze_Comp
    {
        const float f = 600; // Camera focal length (in pixels)
        const float EYE_DIST = 62.5F; // Distance between eyes (in mm)
        //Point_Obj princ_pt = new Point_Obj(320F, 240F);
        Point_Obj princ_pt = new Point_Obj(0.0F, 0.0F);

        public Point_Obj get_gaze_pt(Point_Obj right_eye, Point_Obj left_eye, float alpha, float beta, float gamma)
        {
            // Compute Z coordinate of head/eyes in the WCS (World Coordinate System)
            float Z = (-f * EYE_DIST) / (left_eye.get_x() - right_eye.get_x());
            //Console.WriteLine("EST Z: {0}", Z);

            // Use computed Z coordinate to get X,Y world coordinates of the eyes
            float X_r = Z * (right_eye.get_x() - princ_pt.get_x()) / (-f);
            float Y_r = Z * (right_eye.get_y() - princ_pt.get_y()) / (-f);

            float X_l = Z * (left_eye.get_x() - princ_pt.get_x()) / (-f);
            float Y_l = Z * (left_eye.get_y() - princ_pt.get_y()) / (-f);

            // Compute direction vector (d) of eyes using rotation angles (alpha, beta, gamma)
            DenseVector k_hat = new DenseVector(3);
            k_hat[2] = 1;
            //DenseMatrix R = get_rotation_mat(alpha, beta, gamma);
            DenseMatrix R = get_rotation_mat(alpha, beta, gamma);
            DenseVector d = R * k_hat;

            // Get point of intersection using eye points and direction vector d
            DenseVector P_r = new DenseVector(new[]{Convert.ToDouble(X_r), Convert.ToDouble(Y_r), Convert.ToDouble(Z)});
            DenseVector P_l = new DenseVector(new[] { Convert.ToDouble(X_l), Convert.ToDouble(Y_l), Convert.ToDouble(Z)});

            DenseVector p_hat_r = P_r + d * (-P_r[2] / d[2]);
            DenseVector p_hat_l = P_l + d * (-P_l[2] / d[2]);
            DenseVector p_hat_avg = (p_hat_r + p_hat_l) / 2;

            /*
            Console.WriteLine("EYE_DIST (pix): {0}", (left_eye.get_x() - right_eye.get_x()).ToString());
            Console.WriteLine("P_r: {0}", P_r.ToString());
            Console.WriteLine("P_l: {0}", P_l.ToString());
            Console.WriteLine("d: {0}", d);
            Console.WriteLine("p_hat_r: {0}", p_hat_r);
            Console.WriteLine("p_hat_l: {0}", p_hat_l);
            Console.WriteLine("p_hat_avg: {0}", p_hat_avg);
            */
              
            return new Point_Obj(Convert.ToSingle(p_hat_avg[0]), Convert.ToSingle(p_hat_avg[1]));
        }


        private DenseMatrix get_rotation_mat(float alpha, float beta, float gamma)
        {
            double alpha_rad = alpha * (Math.PI / 180);
            double beta_rad = beta * (Math.PI / 180);
            double gamma_rad = gamma * (Math.PI / 180);

            
            //var R_alpha = new DenseMatrix(3, 3, [1, 0, 0, 0, Math.Cos(alpha_rad), -Math.Sin(alpha_rad), 0, Math.Sin(alpha_rad), Math.Cos(alpha_rad)]);
            DenseMatrix R_alpha = DenseMatrix.Create(3, 3, (i, j) => 0.0);
            DenseMatrix R_beta = DenseMatrix.Create(3, 3, (i, j) => 0.0);
            DenseMatrix R_gamma = DenseMatrix.Create(3, 3, (i, j) => 0.0);
       
           
            R_alpha[0, 0] = 1;
            R_alpha[1, 1] = Math.Cos(alpha_rad);
            R_alpha[1, 2] = -Math.Sin(alpha_rad);
            R_alpha[2, 1] = Math.Sin(alpha_rad);
            R_alpha[2, 2] = Math.Cos(alpha_rad);

            R_beta[0, 0] = Math.Cos(beta_rad);
            R_beta[0, 2] = Math.Sin(beta_rad);
            R_beta[1, 1] = 1;
            R_beta[2, 0] = -Math.Sin(beta_rad);
            R_beta[2, 2] = Math.Cos(beta_rad);

            R_gamma[0, 0] = Math.Cos(gamma_rad);
            R_gamma[0, 1] = Math.Sin(gamma_rad);
            R_gamma[1, 0] = -Math.Sin(gamma_rad);
            R_gamma[1, 1] = Math.Cos(gamma_rad);
            R_gamma[2, 2] = 1;
            

            var R_F = R_beta * R_alpha * R_gamma;


            return R_F;
        }

    }

}