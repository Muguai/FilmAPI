using System.ComponentModel.DataAnnotations;

namespace FilmApi.Models
{
    public class Movie
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }

        [MaxLength(100)]
        public string Director { get; set; }

        [MaxLength(200)]
        public string Picture { get; set; }

        [MaxLength(200)]
        public string Trailer { get; set; }

        public int? FranchiseId { get; set; }

        public Franchise? Franchise { get; set; }

        public ICollection<CharacterMovie> CharacterMovie { get; set; }

    }
}
