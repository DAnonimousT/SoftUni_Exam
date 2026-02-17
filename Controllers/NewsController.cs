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
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            News? news = dbContext.News.FirstOrDefault(n => n.Id == id);

            if (news == null)
            {
                return NotFound();
            }
            EditNewsInputModel editModel = new EditNewsInputModel
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Type = news.Type,
            };
            return View(editModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditNewsInputModel editModel)
        {
            
            if (id <= 0)
            {
                return BadRequest();
            }

            News? news = dbContext.News.FirstOrDefault(n => n.Id == id);

            if (news == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            try
            {
                news.Id = editModel.Id;
                news.Title = editModel.Title;
                news.Content = editModel.Content;
                news.Type = editModel.Type;
                
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Details), new {id});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);                
                ModelState.AddModelError(string.Empty, "Something went wrong while editing the game! Please try again later.");

                return View(editModel);
            }

        }
    }
}