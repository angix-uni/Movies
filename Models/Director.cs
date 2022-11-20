using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Movie_App.Models
{
    public class Director
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Award { get; set; } = string.Empty;
    }
}
