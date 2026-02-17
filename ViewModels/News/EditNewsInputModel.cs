namespace SoftUni_Exam.ViewModels.News
{
    public class EditNewsInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}