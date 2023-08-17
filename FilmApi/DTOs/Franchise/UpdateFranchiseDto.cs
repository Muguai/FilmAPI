using System.ComponentModel.DataAnnotations;

namespace FilmApi.DTOs.Franchise
{
    public class UpdateFranchiseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
