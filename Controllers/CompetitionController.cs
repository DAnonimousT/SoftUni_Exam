using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUni_Exam.Data;
using SoftUni_Exam.ViewModels.Competition;

namespace SoftUni_Exam.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ImpulsDbContext dbContext;

        public CompetitionController(ImpulsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var competitions = dbContext.Competitions
                .OrderByDescending(c => c.StartDate)
                .Select(c => new IndexCompetitionsViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                })
                .ToArray();

            return View(competitions);
        }
    }
}