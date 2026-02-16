using SoftUni_Exam.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftUni_Exam.Data.Configuration
{
    public class CompetitionEntityConfiguration : IEntityTypeConfiguration<Competitions>
    {
        private static readonly Competitions[] competitions =
        {
            new Competitions
            {
                Id = 1,
                Name = "Spring Coding Challenge",
                Description = "A competition for students to solve algorithmic problems.",
                Location = "Sofia, Bulgaria",
                StartDate = new DateTime(2026, 3, 15),
                EndDate = new DateTime(2026, 3, 16)
            },
            new Competitions
            {
                Id = 2,
                Name = "AI Hackathon",
                Description = "Teams compete to build the best AI solution.",
                Location = "Plovdiv, Bulgaria",
                StartDate = new DateTime(2026, 5, 10),
                EndDate = new DateTime(2026, 5, 12)
            }
        };

        public void Configure(EntityTypeBuilder<Competitions> builder)
        {
            builder.HasData(competitions);
        }
    }

}
