namespace SoftUni_Exam.ViewModels.Home
{
    using SoftUni_Exam.ViewModels.News;
    using SoftUni_Exam.ViewModels.Competition;

    public class HomePageViewModel
    {
        public IEnumerable<AllNewsViewModel> LatestNews { get; set; } 
            = new List<AllNewsViewModel>();

        public IEnumerable<IndexCompetitionsViewModel> LatestCompetitions { get; set; } 
            = new List<IndexCompetitionsViewModel>();
    }
}