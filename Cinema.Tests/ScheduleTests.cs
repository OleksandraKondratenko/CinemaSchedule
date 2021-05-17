using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests
{
    class ScheduleTests
    {
        Schedule schedule;

        [SetUp]
        public void SetUp()
        {
            schedule = new Schedule(DataCinema.openHours);
        }

        [TestCaseSource(nameof(CurrentScheduleForTest))]
        public void CountUniqueMovies_WhenDictionaryNotNull_ShouldCountUniqueMovies(Dictionary<DateTime, Movie> сurrentMovie, int expected)
        {
            int actual = schedule.CountUniqueMovies(сurrentMovie);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> CurrentScheduleForTest()
        {
            //yield return new object[] { new Dictionary<DateTime, Movie>()
            //{
            //    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
            //}, 3};

            //yield return new object[] { new Dictionary<DateTime, Movie>()
            //{
            //    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka1")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka1")}
            //}, 1};

            yield return new object[] { new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka1")}
            }, 2};

            //yield return new object[] { new Dictionary<DateTime, Movie>()
            //{
            //    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka4")}
            //    ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka5")}
            //}, 5};

        }
    }
}
