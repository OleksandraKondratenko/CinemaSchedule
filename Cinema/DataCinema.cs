using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public static class DataCinema
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie(90, "Kopitoshka1"),
            new Movie(90, "Kopitoshka2"),
            new Movie(90, "Kopitoshka3"),
            new Movie(90, "Kopitoshka4"),
            new Movie(90, "Kopitoshka5"),
            new Movie(90, "Kopitoshka6"),
            new Movie(90, "Kopitoshka7"),
            new Movie(90, "Kopitoshka8"),
            new Movie(90, "Kopitoshka9"),
            new Movie(90, "Kopitoshka10"),
            new Movie(135, "Kopitoshka11")
        };
        public static DateTime openHours = DateTime.Now.Date.Add(new TimeSpan(10, 0, 0));
        public static DateTime closeHours = DateTime.Now.Date.Add(new TimeSpan(15, 0, 0));
    }
}
