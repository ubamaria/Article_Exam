using Article_Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Article_Database
{
    public class ArticleDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BUNOAQN\SQLEXPRESS;Initial Catalog=ArticleDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Article> Articles { set; get; }
        public virtual DbSet<Author> Authors { set; get; }
        //public virtual DbSet<ArticleAuthor> ArticleAuthors { set; get; }

    }
}
