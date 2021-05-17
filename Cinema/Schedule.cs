using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    public class Schedule
    {

        public int CountUniqueMovies(Dictionary<DateTime, Movie> сurrentMovie)
        {
            List<Movie> tmp = new List<Movie>();
            int counter = 0;
            foreach (var item in сurrentMovie)
            {
                if (tmp.Contains(item.Value))
                {
                    continue;
                }
                else
                {
                    tmp.Add(item.Value);
                    ++counter;
                }
            }
            return counter;
        }

        public bool IsAbleToAddFilm(Movie movie, Dictionary<DateTime, Movie> сurrentSchedule, DateTime currentTime)
        {
            bool result = false;

            if (currentTime.AddMinutes(movie.DurationInMinuts) <= DataCinema.closeHours)
            {
                сurrentSchedule.Add(currentTime, movie);
              
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public void RemoveLastFilm(Dictionary<DateTime, Movie> сurrentSchedule)
        {
            сurrentSchedule.Remove(сurrentSchedule.Keys.Last());
        }
    }
}
