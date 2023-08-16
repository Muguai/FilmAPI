using System.ComponentModel.DataAnnotations;

namespace FilmApi.Models
{
    public class Character
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Alias { get; set; }
        [MaxLength(25)]
        public string Gender { get; set; }

        [MaxLength(1000)]
        public string Picture { get; set; }

        public ICollection<CharacterMovie> CharacterMovie { get; set; }


    }
}
