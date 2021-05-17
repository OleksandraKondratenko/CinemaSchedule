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
            schedule = new Schedule();
        }

        [TestCaseSource(nameof(CurrentScheduleForTest))]
        public void CountUniqueMovies_WhenDictionaryNotNull_ShouldCountUniqueMovies(
            Dictionary<DateTime, Movie> сurrentSchedule, int expected)
        {
            int actual = schedule.CountUniqueMovies(сurrentSchedule);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> CurrentScheduleForTest()
        {
            yield return new object[] { new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
            }, 3};

            yield return new object[] { new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka1")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka1")}
            }, 1};

            yield return new object[] { new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka1")}
            }, 2};

            yield return new object[] { new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(14, 30, 0)),  new Movie(90, "Kopitoshka4")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(16, 00, 0)),  new Movie(90, "Kopitoshka5")}
            }, 5};

        }

        [TestCaseSource(nameof(CurrentScheduleForCheckPosibilityToAddMovie))]
        public void IsAbleToAddFilm_WhenExistPosibilityToAddMowie_ShouldAddMovie(
            Movie movie, Dictionary<DateTime, Movie> сurrentSchedule, DateTime currentTime, bool expected)
        {
            bool actual = schedule.IsAbleToAddFilm(movie, сurrentSchedule, currentTime);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> CurrentScheduleForCheckPosibilityToAddMovie()
        {
            yield return new object[] {new Movie(90, "AbraKadabra")
                ,new Dictionary<DateTime, Movie>(){ }, DataCinema.openHours, true};

            yield return new object[] { new Movie(90, "AbraKadabra")
                ,new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
            }
                ,DateTime.Now.Date.Add(new TimeSpan(11, 30, 0))
                ,true};

            yield return new object[] { new Movie(90, "AbraKadabra")
            ,new Dictionary<DateTime, Movie>()
            {
                { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka1")}
            }
            , DateTime.Now.Date.Add(new TimeSpan(14, 30, 0))
            ,false};
        }

        [TestCaseSource(nameof(RemoveMovieScheduleForTest))]
        public void RemoveLastMovie_ShouldRemoveLastMovie(Dictionary<DateTime, Movie> actualSchedule
            , Dictionary<DateTime, Movie> expectedSchedule)
        {
            schedule.RemoveLastFilm(actualSchedule);

            CollectionAssert.AreEqual(expectedSchedule, actualSchedule);
        }

        private static IEnumerable<object[]> RemoveMovieScheduleForTest()
        {
            yield return new object[] {
                new Dictionary<DateTime, Movie>()
                 {
                    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                    ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                    ,{ DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
                 },
                new Dictionary<DateTime, Movie>()
                {
                    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                    ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                }};

            yield return new object[] {
                new Dictionary<DateTime, Movie>()
                 {
                    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                    ,{ DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")}
                 },
                new Dictionary<DateTime, Movie>()
                {
                    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")}
                }};

           
        }

    }
}
