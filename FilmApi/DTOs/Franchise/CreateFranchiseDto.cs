using System.ComponentModel.DataAnnotations;

namespace FilmApi.DTOs.Franchise
{
    public class CreateFranchiseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
