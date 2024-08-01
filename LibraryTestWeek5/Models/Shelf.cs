using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryTestWeek5.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ספריה")]
        public Library? Library { get; set; }

        [Display(Name = "גובה")]
        public int Height { get; set; }

        [Display(Name = "רוחב")]
        public int Width { get; set; }

        [Display(Name = "שם")]
        public string? Name { get; set; }

        [NotMapped]
        public int LibId { get; set; }
    }
}
 