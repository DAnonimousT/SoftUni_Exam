namespace SoftUni_Exam.ViewModels.News
{
    public class AllNewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Type { get; set; } = null!; 
        public string Author { get; set; } = null!;
        public DateTime PublishedOn { get; set; }
    }
}