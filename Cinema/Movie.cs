using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Movie
    {
        public int DurationInMinuts { get; set; }
        public string Title { get; set; }

        public Movie(int duratoinFilmInMinuts, string nameFilm)
        {
            DurationInMinuts = duratoinFilmInMinuts;
            Title = nameFilm;
        }
        public override bool Equals(object obj)
        {
            bool equal = false;
            Movie movie = obj as Movie;

            if (!(movie is null))
            {
                if (DurationInMinuts == movie.DurationInMinuts && Title == movie.Title)
                {
                    equal = true;
                }
            }

            return equal;
        }
    }
}
