using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Schedule
    {
        private DateTime _currentTime;
        public List<Movie> Movies { get; set; }
        public Dictionary<DateTime, Movie> finalSchedule;

        public Schedule(List<Movie> movies, DateTime currentTime)
        {
            _currentTime = currentTime;
          

            if (!(movies is null))
            {
                Movies = movies;
            }
            else
            {
                throw new NullReferenceException("Movies list is empty");
            }
        }

        public void CreateSchedule(Dictionary<DateTime,Movie> сurrentMovie = null)
        {
            if (сurrentMovie is null)
            {
                сurrentMovie = new Dictionary<DateTime, Movie>();
            }

            foreach (var movie in Movies)
            {
                if (IsAbleToAddFilm(сurrentMovie))
                {
                    CreateSchedule(сurrentMovie);
                }

                SetTheBestSchedule(сurrentMovie);
            }
        }

        private void SetTheBestSchedule(Dictionary<DateTime, Movie> сurrentMovie)
        {
           if(!(finalSchedule is null))
            {
                if (CountUniqueMovies(finalSchedule) < CountUniqueMovies(сurrentMovie))
                {

                }
            }
            else
            {
                finalSchedule = сurrentMovie;
            }
        }

        private int CountUniqueMovies(Dictionary<DateTime, Movie> сurrentMovie)
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
                    ++counter;
                }
            }
            return counter;
        }

        public bool IsAbleToAddFilm(Dictionary<DateTime, Movie> сurrentMovie)
        {
            foreach (var movie in Movies)
            {
                if (_currentTime.AddMinutes(movie.TimeMovieInMinuts) < DateTime.Now.Date.Add(new TimeSpan(24, 0, 0)))
                {

                    сurrentMovie.Add(_currentTime,  movie );
                    _currentTime = _currentTime.AddMinutes(movie.TimeMovieInMinuts);
                    return true;
                }
            }
            return false;
        }

        //public void WriteAllLeaves()
        //{
        //    if (NextMovie.Count == 0)
        //    {
        //        foreach (var item in сurrentMovie)
        //        {
        //            Console.Write($" {item.Key.Hour} {item.Key.Minute}");
        //            foreach (var movie in item.Value)
        //            {
        //                Console.WriteLine($"{movie.Title    }");
        //            }
        //            Console.WriteLine();
        //        }
        //        Console.WriteLine();
        //    }
        //    else
        //    {
        //        foreach (var movie in NextMovie)
        //        {
        //            movie.WriteAllLeaves();
        //        }
        //    }
        //}

    }
}
