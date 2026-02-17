namespace SoftUni_Exam.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SoftUni_Exam.Data;
    using SoftUni_Exam.Data.Models;
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
        public IActionResult Details(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            News? news = dbContext.News
                .AsNoTracking()
                .FirstOrDefault(n => n.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            DetailsNewsViewModel viewModel = new DetailsNewsViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Type = news.Type,
                Author = news.Author,
                PublishedOn = news.PublishedOn
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddNewsInputModel());
        }
        [HttpPost]
        public IActionResult Add(AddNewsInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            News news = new News()
            {
                Title = input.Title,
                Content = input.Content,
                Type = input.Type,
                Author = input.Author,
                PublishedOn = input.PublishedOn
            };

            dbContext.News.Add(news);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(All));
        } 

        private IEnumerable<News> News()
        {
            return this.dbContext.News
                .AsNoTracking()
                .OrderBy(g => g.Title)
                .ToArray();
        }
        
    }
}