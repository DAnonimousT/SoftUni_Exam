using System.ComponentModel.DataAnnotations;

namespace SoftUni_Exam.Data.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!; 
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public DateTime PublishedOn { get; set; }
    }
}