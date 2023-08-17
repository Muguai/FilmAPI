using FilmApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmApi.DTOs.Character
{
    public class ReadCharacterDto
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }

    }
}
