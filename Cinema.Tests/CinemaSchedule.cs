using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests
{
    public class Tests
    {
        CinemaSchedule cinemaSchedule;

        [SetUp]
        public void Setup()
        {
            cinemaSchedule = new CinemaSchedule();
        }

        [TestCaseSource(nameof(ExpectedSchedule))]
        public void CreateSchedule_WhenAllFilmsAreDifferent_ShouldCreateRightSchedule(Dictionary<DateTime, Movie> expected)
        {
            cinemaSchedule.CreateSchedule();

            CollectionAssert.AreEquivalent(expected, cinemaSchedule.bestSchedule);
        }

        private static IEnumerable<object[]> ExpectedSchedule()
        {
            yield return new object[] { new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")},
                { DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")},
                { DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
            }};
        }

        //[TestCaseSource(nameof(ExpectedSchedulesInDifferetHals))]
        //public void CreateSchedules_WhenAreSeveralHalls_ShouldCreateDifetentSchedules(Dictionary<DateTime, Movie> expected)
        //{
        //    cinemaSchedule.SetSchedulesForDifferentHalls(2);

        //            CollectionAssert.AreEquivalent(expected,);
        //}

        //private static IEnumerable<object[]> ExpectedSchedulesInDifferetHals()
        //{
        //    yield return new object[] { new Dictionary<DateTime, Movie>()
        //    {
        //        { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")},
        //        { DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")},
        //        { DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
        //    }
        //    };
        //    yield return new object[] { new Dictionary<DateTime, Movie>()
        //    {
        //        { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka4")},
        //        { DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka5")},
        //        { DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka6")}
        //    }
        //    };
    }
}