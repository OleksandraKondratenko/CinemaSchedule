using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema
{
    public class SheduleForHalls
    {
        private ScheduleForOneHall _cinemaSchedule;
        public List<Dictionary<DateTime, Movie>> allSchedules;

        public SheduleForHalls()
        {
            _cinemaSchedule = new ScheduleForOneHall();
            allSchedules = new List<Dictionary<DateTime, Movie>>();
        }

        public void SetSchedulesForDifferentHalls(int hallQuantity)
        {
            for (int i = 0; i < hallQuantity; i++)
            {
                _cinemaSchedule.CreateSchedule();
                allSchedules.Add(_cinemaSchedule.bestSchedule);
                СhangeTheSequenceOfMovies();
                _cinemaSchedule.bestSchedule = null;
            }
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            SheduleForHalls sheduleForHalls = obj as SheduleForHalls;

            if(!(sheduleForHalls is null))
            {
               
                //var compareResult = sheduleForHalls.allSchedules.Union(allSchedules)
                //    .Except(sheduleForHalls.allSchedules.Intersect(allSchedules));
                if(sheduleForHalls.allSchedules.All(allSchedules.Contains) )
                {
                    equal = true;
                }
            }

            return equal;
        }

        private void СhangeTheSequenceOfMovies()
        {
            int index = DataCinema.Movies.IndexOf(_cinemaSchedule.bestSchedule.Values.Last());
            List<Movie> temp = new List<Movie>();

            for (int i = 0; i < DataCinema.Movies.Count; i++)
            {
                if (i > index)
                {
                    temp.Add(DataCinema.Movies[i]);
                }
            }

            foreach (var movie in _cinemaSchedule.bestSchedule)
            {
                temp.Add(movie.Value);
            }
            DataCinema.Movies = temp;
        }
    }
}
