using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests
{
    public class ScheduleForHallsTests
    {
        SheduleForHalls schedule;

        [SetUp]
        public void Setup()
        {
            schedule = new SheduleForHalls();
        }

        [TestCaseSource(nameof(ExpectedSchedulesInDifferetHals))]
        public void CreateSchedules_WhenAreSeveralHalls_ShouldCreateDifetentSchedules(List<Dictionary<DateTime, Movie>> expected)
        {
            schedule.SetSchedulesForDifferentHalls(2);

            CollectionAssert.AreEquivalent(expected, schedule.allSchedules);
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
