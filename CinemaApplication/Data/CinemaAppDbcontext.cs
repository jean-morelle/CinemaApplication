using CinemaApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Data
{
    public class CinemaAppDbcontext : DbContext
    {
        public DbSet<Film>Films { get; set; }
        public DbSet<CategorieDuFilm>CategorieDuFilms { get; set; }
    
        public CinemaAppDbcontext(DbContextOptions<CinemaAppDbcontext> options) :base(options){
        
        }
        
    }
}
