using geodesy_data_struct.Interface;
using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geodesy_data_struct.DataClass.Coordinate
{
    public class SpaceRectangularCoordinate : IToGeodeticConvertible
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public GeodeticCoordinate ToGeodetic(Ellipsoid coorSys)
        {
            double L = Atan2(Y, X);
            // calculate latitude
            double p = Sqrt(X * X + Y * Y);
            double tanB0 = Z / p, 
                tanB, N;
            while (true)
            {
                double sin2B0 = tanB0 * tanB0 / (1 + tanB0 * tanB0);
                N = coorSys.A / Sqrt(1 - coorSys.E12 * sin2B0);
                tanB = (Z + N * coorSys.E12 * Sqrt(sin2B0)) / p;
                if (Abs(tanB - tanB0) < 1e-12) break;
                tanB0 = tanB;
            }
            double B = Atan(tanB);
            double H = p / Cos(B) - N;
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
