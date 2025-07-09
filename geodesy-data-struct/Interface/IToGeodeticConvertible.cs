using geodesy_data_struct.DataClass;
using geodesy_data_struct.DataClass.Coordinate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geodesy_data_struct.Interface
{
    public interface IToGeodeticConvertible
    {
        public GeodeticCoordinate ToGeodetic(Ellipsoid coorSys);
    }
}
