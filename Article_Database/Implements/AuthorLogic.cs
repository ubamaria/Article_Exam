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
    public class AuthorLogic : IAuthor
    {
        public List<AuthorViewModel> GetList()
        {
            using (var context = new ArticleDatabase())
            {
                return context.Authors
                .ToList()
               .Select(rec => new AuthorViewModel
               {
                   Id = rec.Id,
                   AuthorFIO = rec.AuthorFIO,
                   ArticleId = rec.ArticleId,
                   Email = rec.Email,
                   DateBirth = rec.DateBirth,
                   Job = rec.Job,
               })
            .ToList();
            }
        }
        public AuthorViewModel GetElement(int id)
        {
            using (var context = new ArticleDatabase())
            {
                var elem = context.Authors.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    return new AuthorViewModel
                    {
                        Id = elem.Id,
                        AuthorFIO = elem.AuthorFIO,
                        Email = elem.Email,
                        DateBirth = elem.DateBirth,
                        Job = elem.Job,
                        ArticleId = elem.ArticleId,

                    };
                }
                throw new Exception("Элемент не найден");
            }
        }
        public void AddElement(AuthorBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                var elem = context.Authors.FirstOrDefault(x => x.AuthorFIO == model.AuthorFIO);
                if (elem != null)
                {
                    throw new Exception("Уже есть автор с таким именем");
                }
                var author = new Author();
                context.Authors.Add(author);
                author.AuthorFIO = model.AuthorFIO;
                author.Email = model.Email;
                author.DateBirth = model.DateBirth;
                author.Job = model.Job;
                author.ArticleId = model.ArticleId;
                context.SaveChanges();
            }
        }
        public void UpdElement(AuthorBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                var elem = context.Authors.FirstOrDefault(x => x.AuthorFIO == model.AuthorFIO && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть автор с таким именем");
                }
                var elemToUpdate = context.Authors.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.AuthorFIO = model.AuthorFIO;
                    elemToUpdate.Email = model.Email;
                    elemToUpdate.DateBirth = model.DateBirth;
                    elemToUpdate.Job = model.Job;
                    elemToUpdate.ArticleId = model.ArticleId;
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
                var elem = context.Authors.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Authors.Remove(elem);
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
