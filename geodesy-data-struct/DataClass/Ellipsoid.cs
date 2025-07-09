namespace geodesy_data_struct.DataClass
{
    public class Ellipsoid
    {
        public required string Name { get; init; }
        public required double SemiMajorAxisLength { get; init; }
        public required double SemiMinorAxisLength { get; init; }

        // 极曲率半径
        public double PolarCurvatureRadius => SemiMajorAxisLength * SemiMajorAxisLength / SemiMinorAxisLength;

        // 扁率
        public double Flattening => (SemiMajorAxisLength - SemiMinorAxisLength) / SemiMajorAxisLength;

        // 第一离心率平方
        public double FirstEccentricitySquared => (SemiMajorAxisLength * SemiMajorAxisLength - SemiMinorAxisLength * SemiMinorAxisLength) / (SemiMajorAxisLength * SemiMajorAxisLength);

        // 第二离心率平方
        public double SecondEccentricitySquared => (SemiMajorAxisLength * SemiMajorAxisLength - SemiMinorAxisLength * SemiMinorAxisLength) / (SemiMinorAxisLength * SemiMinorAxisLength);

        public double A => SemiMajorAxisLength;
        public double B => SemiMinorAxisLength;
        public double C => PolarCurvatureRadius;
        public double F => Flattening;
        public double E12 => FirstEccentricitySquared;
        public double E22 => SecondEccentricitySquared;
    }
}
