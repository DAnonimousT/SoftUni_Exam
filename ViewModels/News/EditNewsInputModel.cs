namespace SoftUni_Exam.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation;
    public class EditNewsInputModel
    {
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
    }
}