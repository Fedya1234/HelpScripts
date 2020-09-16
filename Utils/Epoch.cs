using System;
using UnityEngine;

public static class Epoch
{
    
    public static int DaysFromStartGame24h(string dateTime)
    {
        DateTime startTime = Convert.ToDateTime(dateTime);
        TimeSpan dif = DateTime.Now.Subtract(startTime);
        return dif.Days;
    }

    public static int DaysFromStartGame(string dateTime)
    {
        DateTime startTime = Convert.ToDateTime(dateTime);
        DateTime startDayTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0, DateTimeKind.Local);
        TimeSpan dif = DateTime.Now.Subtract(startDayTime);
        return dif.Days;
    }
}
