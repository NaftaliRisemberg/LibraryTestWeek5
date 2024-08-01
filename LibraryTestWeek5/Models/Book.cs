using System.ComponentModel.DataAnnotations;

namespace LibraryTestWeek5.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "שם הספר")]
        public string? Title { get; set; }
       
        [Display(Name = "גובה")]
        public int Height { get; set; }

        [Display(Name = "רוחב")]
        public int Width { get; set; }

        [Display(Name = "ז'אנר")]
        public Library? Library { get; set; }

        [Display(Name = "מדף")]
        public Shelf? Shelf { get; set; }

    }
}
