using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    public class CinemaSchedule
    {
        private Schedule _schedule;
        public Dictionary<DateTime, Movie> bestSchedule;
        public List<Dictionary<DateTime, Movie>> allSchedules;

        public CinemaSchedule()
        {
            _schedule = new Schedule();
            allSchedules = new List<Dictionary<DateTime, Movie>>();
        }

        public void SetSchedulesForDifferentHalls(int hallQuantity)
        {
            for (int i = 0; i < hallQuantity; i++)
            {
                CreateSchedule();
                allSchedules.Add(bestSchedule);
                СhangeTheSequenceOfMovies();
                bestSchedule = null;
            }
        }

        public void CreateSchedule(DateTime currentTime=default(DateTime)
            , Dictionary<DateTime, Movie> сurrentSchedule = null)
        {
            if (сurrentSchedule is null)
            {
                сurrentSchedule = new Dictionary<DateTime, Movie>();
                currentTime = DataCinema.openHours;
            }

            foreach (var movie in DataCinema.Movies)
            {
                bool isAdded = false;
                if (_schedule.IsAbleToAddFilm(movie, сurrentSchedule, currentTime))
                {
                    currentTime = currentTime.AddMinutes(movie.DurationInMinuts);
                    CreateSchedule(currentTime,сurrentSchedule);
                    isAdded = true;
                }

                if (isAdded)
                {
                    SetTheBestSchedule(сurrentSchedule);
                    currentTime = сurrentSchedule.Keys.Last();
                    _schedule.RemoveLastFilm(сurrentSchedule);
                }

            }
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            CinemaSchedule scheduleForOneHall = obj as CinemaSchedule;
            if(!(scheduleForOneHall is null))
            {
                if (scheduleForOneHall.bestSchedule.Count == bestSchedule.Count)
                { 
                    equal = true;
                    foreach (var pair in scheduleForOneHall.bestSchedule)
                    {
                        Movie value;
                        if (bestSchedule.TryGetValue(pair.Key, out value))
                        {
                            if (value != pair.Value)
                            {
                                equal = false;
                                break;
                            }
                        }
                        else
                        {
                            equal = false;
                            break;
                        }
                    }
                }
            }
            return equal;
           
        }

        private void SetTheBestSchedule(Dictionary<DateTime, Movie> сurrentSchedule)
        {

            if (!(bestSchedule is null))
            {
                if (_schedule.CountUniqueMovies(bestSchedule) < _schedule.CountUniqueMovies(сurrentSchedule))
                {
                    bestSchedule = new Dictionary<DateTime, Movie>(сurrentSchedule);
                }
            }
            else
            {
                bestSchedule = new Dictionary<DateTime, Movie>(сurrentSchedule);
            }
        }

        private void СhangeTheSequenceOfMovies()
        {
            int index = DataCinema.Movies.IndexOf(bestSchedule.Values.Last());
            List<Movie> temp = new List<Movie>();

            for (int i = 0; i < DataCinema.Movies.Count; i++)
            {
                if (i > index)
                {
                    temp.Add(DataCinema.Movies[i]);
                }
            }

            foreach (var movie in bestSchedule)
            {
                temp.Add(movie.Value);
            }
            DataCinema.Movies = temp;
        }


    }
}
