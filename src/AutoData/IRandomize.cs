using System;

namespace AutoData
{
    public interface IRandomize
    {
        string GetString(int size = 20);
        char GetChar();
        double GetDouble();
        int GetInt(int max = 0, int min = 100);
        DateTime GetDateTime();
        DateTimeOffset GetDateTimeOffset();
        bool GetBoolean();
    }
}
