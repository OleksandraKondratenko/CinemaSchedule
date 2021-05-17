using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class MovieSettings
    {
        private DateTime _currentTime;
        private Movie _currentMovie;

        public MovieSettings(DateTime currentTime)
        {
            _currentTime = currentTime;
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
    }
}
