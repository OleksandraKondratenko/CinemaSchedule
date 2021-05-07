using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Movie
    {
        public int TimeMovieInMinuts { get; set; }
        public string Title { get; set; }

        public Movie(int duratoinFilmInMinuts, string nameFilm)
        {
            TimeMovieInMinuts = duratoinFilmInMinuts;
            Title = nameFilm;
        }
    }
}
