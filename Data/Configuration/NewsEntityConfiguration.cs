using SoftUni_Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftUni_Exam.Data.Configuration
{
    public class NewsEntityConfiguration : IEntityTypeConfiguration<News>
    {
        private static readonly News[] news = 
        {
            new News
            {
                Id = 1,
                Title = "SoftUni Exam Announced!",
                Content = "The next SoftUni exam will take place in March 2026. Prepare well!",
                Type = "Announcement",
                Author = "Admin",
                PublishedOn = new DateTime(2026, 2, 10)
            },
            new News
            {
                Id = 2,
                Title = "Competition Results Released",
                Content = "Results for the Spring Coding Challenge are now available.",
                Type = "Results",
                Author = "Competition Committee",
                PublishedOn = new DateTime(2026, 3, 20)
            }
        };
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasData(news);
        }
    }
}