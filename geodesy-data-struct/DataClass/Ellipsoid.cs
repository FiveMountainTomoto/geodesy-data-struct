using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geodesy_data_struct.DataClass
{
    public class Ellipsoid
    {
        public required string Name { get; init; }
        public double SemiMajorAxisLength { get; init; }
        public double SemiMinorAxisLength { get; init; }
        public double Flattening { get; init; }

        private double _firstEccentricitySquared = 0;
        public double FirstEccentricitySquared
        {
            get
            {
                return _firstEccentricitySquared == 0 ? (A * A - B * B) / (A * A) : _firstEccentricitySquared;
            }
            init
            {
                _firstEccentricitySquared = value;
            }
        }

        private double _secondEccentricitySquared = 0;
        public double SecondEccentricitySquared
        {
            get
            {
                return _secondEccentricitySquared == 0 ? (A * A - B * B) / (A * A) : _secondEccentricitySquared;
            }
            init
            {
                _secondEccentricitySquared = value;
            }
        }

        public double A => SemiMajorAxisLength;
        public double B => SemiMinorAxisLength;
        public double F => Flattening;
        public double E12 => FirstEccentricitySquared;
        public double E22 => SecondEccentricitySquared;
    }
}
