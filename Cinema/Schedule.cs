using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    public class Schedule
    {
        public DateTime _currentTime;
        

        public Schedule(DateTime currentTime)
        {
            _currentTime = currentTime;
        }
    

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

        public bool IsAbleToAddFilm(Movie movie, Dictionary<DateTime, Movie> сurrentSchedule)
        {

            if (_currentTime.AddMinutes(movie.DurationInMinuts) <= DataCinema.closeHours)
            {
               
                
                сurrentSchedule.Add(_currentTime, movie);
                _currentTime = _currentTime.AddMinutes(movie.DurationInMinuts);
                return true;
            }

            return false;
        }

        public void RemoveLastFilm(Dictionary<DateTime, Movie> сurrentSchedule)
        {
            _currentTime = сurrentSchedule.Keys.Last();
            сurrentSchedule.Remove(сurrentSchedule.Keys.Last());
        }
    }
}
