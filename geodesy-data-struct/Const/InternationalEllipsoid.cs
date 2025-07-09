using geodesy_data_struct.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geodesy_data_struct.Const
{
    public static class InternationalEllipsoid
    {
        public static readonly Ellipsoid WGS84 = new()
        {
            Name = "WGS84",
            SemiMajorAxisLength = 6378137,
            SemiMinorAxisLength = 6356752.3142,
            Flattening = 1 / 298.257223563,
            FirstEccentricitySquared = 6.69437999013e-3,
            SecondEccentricitySquared = 6.73949674227e-3
        };
        public static readonly Ellipsoid CGCS2000 = new()
        {
            Name = "CGCS2000",
            SemiMajorAxisLength = 6378137,
            SemiMinorAxisLength = 6356752.3141,
            Flattening = 1 / 298.257222101,
            FirstEccentricitySquared = 6.69438002290e-3,
            SecondEccentricitySquared = 6.73949677548e-3
        };
    }
}
