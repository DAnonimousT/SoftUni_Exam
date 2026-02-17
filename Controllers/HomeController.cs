using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SoftUni_Exam.Data;
using SoftUni_Exam.Models;
using SoftUni_Exam.ViewModels.Home;
using SoftUni_Exam.ViewModels.News;
using SoftUni_Exam.ViewModels.Competition;

namespace SoftUni_Exam.Controllers;

public class HomeController : Controller
{
    private readonly ImpulsDbContext dbContext;

    public HomeController(ImpulsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IActionResult Index()
    {
        HomePageViewModel model = new HomePageViewModel
        {
            LatestNews = dbContext.News
                .OrderByDescending(n => n.PublishedOn)
                .Take(5)
                .Select(n => new AllNewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Type = n.Type,
                    Author = n.Author,
                    PublishedOn = n.PublishedOn
                })
                .ToArray(),

            LatestCompetitions = dbContext.Competitions
                .OrderByDescending(c => c.StartDate)
                .Take(5)
                .Select(c => new IndexCompetitionsViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                })
                .ToArray()
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
