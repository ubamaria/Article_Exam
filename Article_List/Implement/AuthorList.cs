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
    public class AuthorList : IAuthor
    {
        private DataListSingleton source;

        public AuthorList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<AuthorViewModel> GetList()
        {
            List<AuthorViewModel> authors = source.Authors.Select(rec => new AuthorViewModel
            {
                Id = rec.Id,
                AuthorFIO = rec.AuthorFIO,
                Email = rec.Email,
                DateBirth = rec.DateBirth,
                Job = rec.Job,
                ArticleId = rec.ArticleId
            })
             .ToList();
            return authors;
        }

        public AuthorViewModel GetElement(int id)
        {
            Author author = source.Authors.FirstOrDefault(rec => rec.Id == id);
            if (author != null)
            {
                return new AuthorViewModel
                {
                    Id = author.Id,
                    AuthorFIO = author.AuthorFIO,
                    Email = author.Email,
                    DateBirth = author.DateBirth,
                    Job = author.Job,
                    ArticleId = author.ArticleId
                };
            }
            throw new Exception("Автор не найден");
        }

        public void AddElement(AuthorBindingModel authors)
        {
            Author element = source.Authors.FirstOrDefault(rec => rec.AuthorFIO == authors.AuthorFIO);
            if (element != null)
            {
                throw new Exception("Уже есть такой автор");
            }
            int maxId = source.Authors.Count > 0 ? source.Authors.Max(rec => rec.Id) : 0;
            source.Authors.Add(new Author
            {
                Id = maxId + 1,
                AuthorFIO = authors.AuthorFIO,
                DateBirth = authors.DateBirth,
                Email = authors.Email,
                Job = authors.Job,
                ArticleId = authors.Id
            });
        }

        public void UpdElement(AuthorBindingModel authors)
        {
            Author element = source.Authors.FirstOrDefault(rec => rec.AuthorFIO == authors.AuthorFIO &&
            rec.Email == authors.Email && rec.DateBirth == authors.DateBirth && rec.Job == authors.Job
            && rec.ArticleId == authors.ArticleId);
            if (element != null)
            {
                throw new Exception("Уже есть такой автор");
            }
            element = source.Authors.FirstOrDefault(rec => rec.Id == authors.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.AuthorFIO = authors.AuthorFIO;
            element.Email = authors.Email;
            element.DateBirth = authors.DateBirth;
            element.Job = authors.Job;
            element.ArticleId = authors.ArticleId;
        }

        public void DelElement(int id)
        {
            Author author = source.Authors.FirstOrDefault(rec => rec.Id == id);
            if (author != null)
            {
                source.Authors.Remove(author);
            }
            else
            {
                throw new Exception("Элемент не найден");

            }
        }
    }
}
