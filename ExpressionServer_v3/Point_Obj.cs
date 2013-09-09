using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionServer_v3
{
    class Point_Obj
    {
        float x_coord;
        float y_coord;
        float z_coord;

        public Point_Obj()
        {
            x_coord = Convert.ToSingle(0.0);
            y_coord = Convert.ToSingle(0.0);
            z_coord = Convert.ToSingle(0.0);
        }

        public Point_Obj(float X_in, float Y_in)
        {
            x_coord = X_in;
            y_coord = Y_in;
            z_coord = 0.0F;
        }

        public Point_Obj(float X_in, float Y_in, float Z_in)
        {
            x_coord = X_in;
            y_coord = Y_in;
            z_coord = Z_in;
        }

        public void set_coord(float X_in, float Y_in, float Z_in)
        {
            x_coord = X_in;
            y_coord = Y_in;
            z_coord = Z_in;
        }

        public float get_x()
        {
            return x_coord;
        }

        public float get_y()
        {
            return y_coord;
        }

        public float get_z()
        {
            return z_coord;
        }

        public override String ToString()
        {
            return "(X,Y,Z): (" + Convert.ToString(x_coord) + ", " + Convert.ToString(y_coord) + ", " + Convert.ToString(z_coord) + ")";
        }
    }
}
