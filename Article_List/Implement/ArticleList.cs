using Article_DAL.Interface;
using Article_List.Models;
using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Article_List.Implement
{
    public class ArticleList 
    {
        private DataListSingleton source;

        public ArticleList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ArticleViewModel> GetList()
        {
            List<ArticleViewModel> articles = source.Articles.Select(rec => new ArticleViewModel
            {
                Id = rec.Id,
                Title = rec.Title,
                Subject = rec.Subject,
                DateCreate = rec.DateCreate,
            })
            .ToList();
            return articles;
        }

        public ArticleViewModel GetElement(int id)
        {
            Article article = source.Articles.FirstOrDefault(rec => rec.Id == id);
            if (article != null)
            {
                return new ArticleViewModel
                {
                    Id = article.Id,
                    Title = article.Title,
                    DateCreate = article.DateCreate,
                    Subject = article.Subject
                };
            }
            throw new Exception("Статья не найдена");
        }

        public void AddElement(ArticleBindingModel article)
        {
            Article element = source.Articles.FirstOrDefault(rec => rec.Title == article.Title);
            if (element != null)
            {
                throw new Exception("Уже есть такая статья");
            }
            int maxId = source.Articles.Count > 0 ? source.Articles.Max(rec => rec.Id) : 0;
            source.Articles.Add(new Article
            {
                Id = maxId + 1,
                Title = article.Title,
                Subject = article.Subject,
                DateCreate = article.DateCreate
            });
        }

        public void UpdElement(ArticleBindingModel article)
        {
            Article element = source.Articles.FirstOrDefault(rec => rec.Title == article.Title &&
            rec.Subject == article.Subject && rec.DateCreate == article.DateCreate);
            if (element != null)
            {
                throw new Exception("Уже есть такая статья");
            }
            element = source.Articles.FirstOrDefault(rec => rec.Id == article.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Title = article.Title;
            element.Subject = article.Subject;
            element.DateCreate = article.DateCreate;
        }
        public void DelElement(int id)
        {
            Article element = source.Articles.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Articles.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
