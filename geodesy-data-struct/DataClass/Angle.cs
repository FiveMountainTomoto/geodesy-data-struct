using geodesy_data_struct.Enum;
using System.Text.Json.Serialization;

namespace geodesy_data_struct.DataClass
{
    public class Angle
    {
        public const double Rho = 206264.80624709636;
        public double Degree { get; init; }
        public double Minute { get; init; }
        public double Second { get; init; }
        public double Radian { get; init; }
        public double TotalDegree { get; init; }
        public double TotalMinute { get; init; }
        public double TotalSecond { get; init; }
        public Angle(double degree, double minute, double second)
        {
            Degree = degree;
            Minute = minute;
            Second = second;
            TotalSecond = degree * 3600 + minute * 60 + second;
            TotalMinute = TotalSecond / 60;
            TotalDegree = TotalSecond / 3600;
            Radian = TotalSecond / Rho;
        }
        public Angle(double value, AngleCreaterType type = AngleCreaterType.Radian)
        {
            switch (type)
            {
                case AngleCreaterType.Radian:
                    Radian = value;
                    TotalSecond = value * Rho;
                    TotalMinute = TotalSecond / 60;
                    TotalDegree = TotalSecond / 3600;
                    break;
                case AngleCreaterType.TotalDegree:
                    TotalDegree = value;
                    TotalMinute = TotalDegree * 60;
                    TotalSecond = TotalDegree * 3600;
                    Radian = TotalSecond / Rho;
                    break;
                case AngleCreaterType.TotalMinute:
                    TotalMinute = value;
                    TotalDegree = TotalMinute / 60;
                    TotalSecond = TotalMinute * 60;
                    Radian = TotalSecond / Rho;
                    break;
                case AngleCreaterType.TotalSecond:
                    TotalSecond = value;
                    TotalMinute = TotalSecond / 60;
                    TotalDegree = TotalSecond / 3600;
                    Radian = TotalSecond / Rho;
                    break;
            }
            Degree = (int)TotalDegree;
            Minute = (int)((TotalDegree - Degree) * 60);
            Second = TotalSecond - Degree * 3600 - Minute * 60;
        }
        [JsonConstructor]
        public Angle(double degree, double minute, double second, double radian, double totalDegree, double totalMinute, double totalSecond) : this(degree, minute, second)
        {
            Radian = radian;
            TotalDegree = totalDegree;
            TotalMinute = totalMinute;
            TotalSecond = totalSecond;
        }
        public override string ToString()
        {
            return $"{Degree}°{Minute}'{Second}\"";
        }
        public static Angle operator +(Angle angle1, Angle angle2)
        {
            double resTotalSec = angle1.TotalSecond + angle2.TotalSecond;
            return new Angle(resTotalSec, AngleCreaterType.TotalSecond);
        }
        public static Angle operator -(Angle angle1, Angle angle2)
        {
            double resTotalSec = angle1.TotalSecond - angle2.TotalSecond;
            return new Angle(resTotalSec, AngleCreaterType.TotalSecond);
        }
        public static Angle operator *(Angle angle, double factor)
        {
            double resTotalSec = angle.TotalSecond * factor;
            return new Angle(resTotalSec, AngleCreaterType.TotalSecond);
        }
        public static Angle operator /(Angle angle, double factor)
        {
            double resTotalSec = angle.TotalSecond / factor;
            return new Angle(resTotalSec, AngleCreaterType.TotalSecond);
        }
        public Angle GetStandard()
        {
            double rad = Radian;
            while (rad < 0)
            {
                rad += 2 * double.Pi;
            }
            while (rad >= 2 * double.Pi)
            {
                rad -= 2 * double.Pi;
            }
            return new Angle(rad);
        }
    }
}
