using System;
using System.Text;

namespace AutoData
{
    public static class RandomizeUtils
    {
        private static readonly Random _random = new Random();

        public static char GetChar()
        {
            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65)));
        }

        public static DateTime GetDateTime()
        {
            return new DateTime(GetInt(1996, DateTime.Now.Year), GetInt(1, 12), GetInt(1, 28),
                GetInt(1, 24), GetInt(1, 60), GetInt(1, 60));
        }

        public static DateTimeOffset GetDateTimeOffset()
        {
            return new DateTimeOffset(GetDateTime());
        }

        public static double GetDouble()
        {
            return GetInt() * Math.PI;
        }

        public static int GetInt(int min = 0, int max = 100)
        {
            return _random.Next(min, max);
        }

        public static string GetString(int size = 20)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                builder.Append(GetChar());
            }
            return builder.ToString();
        }

        public static bool GetBoolean()
        {
            return _random.Next(0, 1) == 1;
        }
    }
}
