using System.ComponentModel.DataAnnotations;

namespace LibraryTestWeek5.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "ז'אנר")]
        public string? Genre { get; set; }
    }
}
