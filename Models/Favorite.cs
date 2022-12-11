using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Movie_App.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Genre { get; set; } = string.Empty;

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(10)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}
