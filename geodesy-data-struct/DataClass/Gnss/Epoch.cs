using System.Text.Json.Serialization;

namespace geodesy_data_struct.DataClass.Gnss
{
    public record Epoch
    {
        public int Year => DateTime.Year;
        public int Day => DateTime.DayOfYear;
        public int Sec => (int)DateTime.TimeOfDay.TotalSeconds;
        public int TotalSecOfYear => (int)(DateTime - new DateTime(DateTime.Year, 1, 1)).TotalSeconds;
        public DateTime DateTime { get; }
        public Epoch(int year, int day, int sec)
        {
            DateTime = new DateTime(year, 1, 1).AddDays(day - 1).AddSeconds(sec);
        }
        [JsonConstructor]
        public Epoch(DateTime dateTime)
        {
            DateTime = dateTime;
        }
        /// <summary>
        /// Constructor for Epoch from string in format "YYYY:DDD:SSSSS"
        /// </summary>
        /// <param name="epoch">"YY:DDD:SSSSS"</param>
        public Epoch(string epoch)
        {
            string[] parts = epoch.Split(':');
            int year = int.Parse(parts[0]) + 2000;
            int day = int.Parse(parts[1]);
            int sec = int.Parse(parts[2]);
            DateTime = new DateTime(year, 1, 1).AddDays(day - 1).AddSeconds(sec);
        }
    }
}
