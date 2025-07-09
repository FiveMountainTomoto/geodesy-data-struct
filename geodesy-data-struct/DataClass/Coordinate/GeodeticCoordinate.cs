using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geodesy_data_struct.DataClass.Coordinate
{
    public class GeodeticCoordinate
    {
        public required Ellipsoid CoordinateSystem { get; init; }
        public required Angle Lat { get; init; }
        public required Angle Lon { get; init; }
        public required double H { get; set; }
        public Angle B => Lat;
        public Angle L => Lon;
    }
}
