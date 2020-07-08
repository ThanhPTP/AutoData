using System;
using System.Text;

namespace AutoData
{
    public class Randomize : IRandomize
    {
        private readonly Random random;
        public Randomize()
        {
            random = new Random();
        }

        public char GetChar()
        {
            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        }

        public DateTime GetDateTime()
        {
            return new DateTime(GetInt(1996, DateTime.Now.Year), GetInt(1, 12), GetInt(1, 28),
                GetInt(1, 24), GetInt(1, 60), GetInt(1, 60));
        }

        public DateTimeOffset GetDateTimeOffset()
        {
            return new DateTimeOffset(GetDateTime());
        }

        public double GetDouble()
        {
            return GetInt() * Math.PI;
        }

        public int GetInt(int min = 0, int max = 100)
        {
            return random.Next(min, max);
        }

        public string GetString(int size = 20)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                builder.Append(GetChar());
            }
            return builder.ToString();
        }

        public bool GetBoolean()
        {
            return random.Next(0, 1) == 1;
        }
    }
}
