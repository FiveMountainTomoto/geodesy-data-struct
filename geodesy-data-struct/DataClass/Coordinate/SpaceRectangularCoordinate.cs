using geodesy_data_struct.Interface;
using static System.Math;

namespace geodesy_data_struct.DataClass.Coordinate
{
    public class SpaceRectangularCoordinate : IToGeodeticConvertible
    {
        public SpaceRectangularCoordinate(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public GeodeticCoordinate ToGeodetic(Ellipsoid coorSys)
        {
            double L = Atan2(Y, X);
            // calculate latitude
            double s = Sqrt((X * X) + (Y * Y));
            double t0 = Z / s,
                p = coorSys.C * coorSys.E12 / s,
                k = 1 + coorSys.E22;
            double t1 = t0, tanB;
            while (true)
            {
                double t2 = t0 + (p * t1 / Sqrt(k + (t1 * t1)));
                if (Abs(t2 - t1) < 1e-12)
                {
                    tanB = t2;
                    break;
                }
                t1 = t2;
            }
            double B = Atan(tanB);
            double N = coorSys.A / Sqrt(1 - (coorSys.E12 * Sin(B) * Sin(B)));
            double H = (s / Cos(B)) - N;
            return new()
            {
                CoordinateSystem = coorSys,
                Lat = new Angle(B),
                Lon = new Angle(L),
                H = H
            };
        }
    }
}
