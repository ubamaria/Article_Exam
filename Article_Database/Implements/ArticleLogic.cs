using Article_DAL.Interface;
using Article_Database.Models;
using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Article_Database.Implements
{
    public class ArticleLogic : IArticle
    {
        public void CreateOrUpdate(ArticleBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                Article element = context.Articles.FirstOrDefault(rec =>
               rec.Title == model.Title && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть статья с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Articles.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Article();
                    context.Articles.Add(element);
                }
                element.Title = model.Title;
                element.Subject = model.Subject;
                element.DateCreate = model.DateCreate;
                context.SaveChanges();
                if (model.Id.HasValue)
                {
                    var articleAuthors = context.ArticleAuthors.Where(rec
                   => rec.ArticleId == model.Id.Value).ToList();
                }
                // добавили новые
                foreach (var pc in model.ArticleAuthors)
                {
                    context.ArticleAuthors.Add(new ArticleAuthor
                    {
                       ArticleId = element.Id,
                        AuthorId = pc.Id
                    });
                    context.SaveChanges();
                }
            }
        }
        public void Delete(ArticleBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                Article element = context.Articles.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Articles.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<ArticleViewModel> Read(ArticleBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                return context.Articles
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new ArticleViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    Subject = rec.Subject,
                    DateCreate = rec.DateCreate
                })
                .ToList();
            }
        }
    }
}
