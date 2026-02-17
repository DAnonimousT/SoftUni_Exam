namespace SoftUni_Exam.ViewModels.News
{
    public class DeleteNewsInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
    }
}