using System;
using System.Collections.Generic;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie(90, "Stranger"),
                new Movie(60, "Kopitoshka"),
                new Movie(135, "Ali-Baba")
            };
            Schedule schedule = new Schedule(movies, DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)));
            schedule.CreateSchedule();
            //schedule.WriteAllLeaves();
        }
    }
}
