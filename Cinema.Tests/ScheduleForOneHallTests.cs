using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests
{
    public class Tests
    {
        ScheduleForOneHall scheduleForOneHall;

        [SetUp]
        public void Setup()
        {
            scheduleForOneHall = new ScheduleForOneHall();
        }

        [TestCaseSource(nameof(ExpectedSchedule))]
        public void CreateSchedule_WhenAllFilmsAreDifferent_ShouldCreateRightSchedule(Dictionary<DateTime, Movie> expected)
        {
            scheduleForOneHall.CreateSchedule();

            CollectionAssert.AreEquivalent(expected, scheduleForOneHall.bestSchedule);
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

        [TestCaseSource(nameof(ExpectedSchedulesInDifferetHals))]
        public void CreateSchedules_WhenAreSeveralHalls_ShouldCreateDifetentSchedules(List<Dictionary<DateTime, Movie>> expected)
        {
            scheduleForOneHall.SetSchedulesForDifferentHalls(2);

            CollectionAssert.AreEquivalent(expected, scheduleForOneHall.allSchedules);
        }

        private static IEnumerable<object[]> ExpectedSchedulesInDifferetHals()
        {
            yield return new object[] { new List< Dictionary<DateTime, Movie>>()
            {
                new Dictionary<DateTime, Movie>()
                {
                    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka1")},
                    { DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka2")},
                    { DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka3")}
                },
                new Dictionary<DateTime, Movie>()
                {
                    { DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),  new Movie(90, "Kopitoshka4")},
                    { DateTime.Now.Date.Add(new TimeSpan(11, 30, 0)),  new Movie(90, "Kopitoshka5")},
                    { DateTime.Now.Date.Add(new TimeSpan(13, 00, 0)),  new Movie(90, "Kopitoshka6")}
                }
            }
            };
        }
    }
}