using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MoviesModel
/// </summary>
public class MoviesModel
{
    public class Repository
    {
       static DatabaseModel _databaseContext = new DatabaseModel();

        public List<Movie> ReadMovies()
        {
            return _databaseContext.Movies.Include("Actors").ToList();
        }

        public List<Actor> ReadActors()
        {
            return _databaseContext.Actors.ToList();
        }

        public List<MovieActorLink> ReadMovieActorLinks()
        {
            return _databaseContext.MovieActorLinks.ToList();
        } 

        
        public void CreateMovie(Movie movie)
        {
            
            _databaseContext.Movies.Add(movie);
            
           
            _databaseContext.SaveChanges();
        }

        public void RemoveMovie(Movie movie)
        {
            var findMovie = ReadMovies().FirstOrDefault(m => m.Id == movie.Id);
            _databaseContext.Movies.Remove(findMovie);


            _databaseContext.SaveChanges();
        }

        public void CreateActor(Actor actor)
        {
            _databaseContext.Actors.Add(actor);
            _databaseContext.SaveChanges();
        }

        public void CreateActorMovieLink(MovieActorLink movieActorLink)
        {
            _databaseContext.MovieActorLinks.Add(movieActorLink);
            _databaseContext.SaveChanges();
        }
        
        public static string ReadMovieLink(string movieLinkId)
        {
            int id = Convert.ToInt32(movieLinkId);
            return _databaseContext.Actors.FirstOrDefault(a => a.Id == id).ToString();
        }
    }

    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public List<MovieActorLink> Actors { get; set; }
        public List<Director> Directors { get; set; }
        public List<Genre> Genres { get; set; }
        public UploadModel.Image Image { get; set; }
    } 

    public class  MovieActorLink
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }

    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Director
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Movie Movie { get; set; }

    }

    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string GenreName { get; set; }
        public Movie Movie { get; set; }

    }

    public class TempActor
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

}