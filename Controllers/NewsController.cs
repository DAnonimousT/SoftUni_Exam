namespace SoftUni_Exam.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SoftUni_Exam.Data;
    using SoftUni_Exam.ViewModels.News;
    public class NewsController : Controller
    {
        private readonly ImpulsDbContext dbContext;

        public NewsController(ImpulsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult All()
        {
            IEnumerable<AllNewsViewModel> news = dbContext.News
                .OrderByDescending(n => n.PublishedOn)
                .Select(n => new AllNewsViewModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Type = n.Type,
                    Author = n.Author,
                    PublishedOn = n.PublishedOn
                })
                .ToArray();
            return View(news);
        }
    }
}