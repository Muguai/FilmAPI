using System.ComponentModel.DataAnnotations;

namespace FilmApi.Models
{
    public class CharacterMovie
    {
        public int? CharacterId { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
        public Character? Character { get; set; } 
    }
}
