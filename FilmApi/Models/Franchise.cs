using System.ComponentModel.DataAnnotations;

namespace FilmApi.Models
{
    public class Franchise
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }


        public ICollection<Movie> movies { get; set; }


    }
}
