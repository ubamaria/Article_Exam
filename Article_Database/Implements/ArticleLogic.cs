using Article_DAL.Interface;
using Article_List.Models;
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
        public List<ArticleViewModel> GetList()
        {
            using (var context = new ArticleDatabase())
            {
                return context.Articles
                .ToList()
               .Select(rec => new ArticleViewModel
               {
                   Id = rec.Id,
                   Title = rec.Title,
                   Subject = rec.Subject,
                   DateCreate = rec.DateCreate,
               })
            .ToList();
            }
        }
        public ArticleViewModel GetElement(int id)
        {
            using (var context = new ArticleDatabase())
            {
                var elem = context.Articles.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    return new ArticleViewModel
                    {
                        Id = elem.Id,
                        Title = elem.Title,
                        Subject = elem.Subject,
                        DateCreate = elem.DateCreate,
                    };
                }
                throw new Exception("Элемент не найден");
            }
        }
        public void AddElement(ArticleBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                var elem = context.Articles.FirstOrDefault(x => x.Title == model.Title);
                if (elem != null)
                {
                    throw new Exception("Уже есть статья с таким названием");
                }
                var article = new Article();
                context.Articles.Add(article);
                article.Title = model.Title;
                article.Subject = model.Subject;
                article.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void UpdElement(ArticleBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                var elem = context.Articles.FirstOrDefault(x => x.Title == model.Title && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть статья с таким названием");
                }
                var elemToUpdate = context.Articles.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.Title = model.Title;
                    elemToUpdate.Subject = model.Subject;
                    elemToUpdate.DateCreate = model.DateCreate;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void DelElement(int id)
        {
            using (var context = new ArticleDatabase())
            {
                var elem = context.Articles.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Articles.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
    }
}
