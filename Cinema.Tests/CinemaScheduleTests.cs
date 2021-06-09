using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cinema.Tests
{
    public class Tests
    {
        CinemaSchedule cinemaSchedule;
        List<Movie> Movies = new List<Movie>()
            {
            new Movie(90, "Kopitoshka1"),
            new Movie(90, "Kopitoshka2"),
            new Movie(90, "Kopitoshka3"),
            new Movie(90, "Kopitoshka4"),
            new Movie(90, "Kopitoshka5"),
            new Movie(90, "Kopitoshka6"),
            new Movie(90, "Kopitoshka7"),
            new Movie(90, "Kopitoshka8"),
            new Movie(90, "Kopitoshka9"),
            new Movie(90, "Kopitoshka10"),
            new Movie(135, "Kopitoshka11")
         };
        [SetUp]
        public void Setup()
        {
            cinemaSchedule = CinemaSchedule.Create(Movies);
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
                { new DateTime(2020, 2, 20, 10, 0, 0),  new Movie(90, "Kopitoshka1")},
                { new DateTime(2020, 2, 20, 11, 30, 0),  new Movie(90, "Kopitoshka2")},
                {new DateTime(2020, 2, 20, 13, 0, 0),  new Movie(90, "Kopitoshka3")}
            }};
        }

        [TestCaseSource(nameof(ExpectedSchedulesInDifferetHals))]
        public void CreateSchedules_WhenAreSeveralHalls_ShouldCreateDifetentSchedules(List<Dictionary<DateTime, Movie>> expected)
        {
            cinemaSchedule.SetSchedulesForDifferentHalls(2);

            CollectionAssert.AreEquivalent(expected, cinemaSchedule.allSchedules);
        }

        private static IEnumerable<object[]> ExpectedSchedulesInDifferetHals()
        {
            yield return new object[] { new List< Dictionary<DateTime, Movie>>()
            {
                new Dictionary<DateTime, Movie>()
                {
                    { new DateTime(2020, 2, 20, 10, 0, 0),  new Movie(90, "Kopitoshka1")},
                    { new DateTime(2020, 2, 20, 11, 30, 0),  new Movie(90, "Kopitoshka2")},
                    {new DateTime(2020, 2, 20, 13, 0, 0),  new Movie(90, "Kopitoshka3")}
                },
                new Dictionary<DateTime, Movie>()
                {
                    { new DateTime(2020, 2, 20, 10, 0, 0),  new Movie(90, "Kopitoshka4")},
                    { new DateTime(2020, 2, 20, 11, 30, 0),  new Movie(90, "Kopitoshka5")},
                    {new DateTime(2020, 2, 20, 13, 0, 0),  new Movie(90, "Kopitoshka6")}
                }
            }
            };
        }
    }
}