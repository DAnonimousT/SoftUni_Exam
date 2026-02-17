namespace SoftUni_Exam.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static SoftUni_Exam.Common.EntityValidation;
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;
        [Required]
        [MinLength(TypeMinLength)]
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!; 
        [Required]
        [MinLength(AuthorMinLength)]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;
        [Required]
        public DateTime PublishedOn { get; set; }
    }
}