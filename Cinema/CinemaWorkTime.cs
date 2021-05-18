using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public static class CinemaWorkTime
    {
        public static DateTime openHours = DateTime.Now.Date.Add(new TimeSpan(10, 0, 0));
        public static DateTime closeHours = DateTime.Now.Date.Add(new TimeSpan(15, 0, 0));
    }
}
