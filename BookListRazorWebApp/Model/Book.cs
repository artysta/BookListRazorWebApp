using System.ComponentModel.DataAnnotations;

namespace BookListRazorWebApp.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public int Author { get; set; }
    }
}
