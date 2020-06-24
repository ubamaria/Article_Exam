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
    public class AuthorLogic : IAuthor
    {
        public void CreateOrUpdate(AuthorBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                Author element = context.Authors.FirstOrDefault(rec =>
               rec.AuthorFIO == model.AuthorFIO && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть автор с таким именем");
                }
                if (model.Id.HasValue)
                {
                    element = context.Authors.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Author();
                    context.Authors.Add(element);
                }
                element.AuthorFIO = model.AuthorFIO;
                element.Email = model.Email;
                element.DateBirth = model.DateBirth;
                element.Job = model.Job;
                context.SaveChanges();
            }
        }
        public void Delete(AuthorBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                Author element = context.Authors.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Authors.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<AuthorViewModel> Read(AuthorBindingModel model)
        {
            using (var context = new ArticleDatabase())
            {
                return context.Authors
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new AuthorViewModel
                {
                    Id = rec.Id,
                    AuthorFIO = rec.AuthorFIO,
                    Email = rec.Email,
                    DateBirth = rec.DateBirth,
                    Job = rec.Job
                })
                .ToList();
            }
        }
    }
}
