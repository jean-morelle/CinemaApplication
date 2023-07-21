namespace CinemaApplication.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime AnneeDeSortie { get; set; }
        public string CategorieDeFilm { get; set; }
        public string PrixDAchatDuFilm { get; set; }
        public int CategorieDuFilmId { get; set; }
        public virtual CategorieDuFilm CategorieDuFilm { get; set; }
    }
}
