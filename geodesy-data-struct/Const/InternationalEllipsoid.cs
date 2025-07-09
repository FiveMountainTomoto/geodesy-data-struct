using geodesy_data_struct.DataClass;

namespace geodesy_data_struct.Const
{
    public static class InternationalEllipsoid
    {
        public static readonly Ellipsoid WGS84 = new()
        {
            Name = "WGS84",
            SemiMajorAxisLength = 6378137,
            SemiMinorAxisLength = 6356752.3142
        };
        public static readonly Ellipsoid CGCS2000 = new()
        {
            Name = "CGCS2000",
            SemiMajorAxisLength = 6378137,
            SemiMinorAxisLength = 6356752.3141
        };
    }
}
