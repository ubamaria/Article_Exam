using Article_DAL.Interface;
using Article_List.Models;
using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
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
            List<AuthorViewModel> authors = new List<AuthorViewModel>();
            for (int i = 0; i < source.Authors.Count; i++)
            {
                authors.Add(new AuthorViewModel
                {
                    Id = source.Authors[i].Id,
                    AuthorFIO = source.Authors[i].AuthorFIO,
                    Email = source.Authors[i].Email,
                    DateBirth = source.Authors[i].DateBirth,
                    Job = source.Authors[i].Job,
                    ArticleId = source.Authors[i].ArticleId
                });
            }
            return authors;
        }

        public AuthorViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Authors.Count; ++i)
            {
                if (id == source.Authors[i].Id)
                {
                    return new AuthorViewModel
                    {
                        Id = source.Authors[i].Id,
                        AuthorFIO = source.Authors[i].AuthorFIO,
                        Email = source.Authors[i].Email,
                        DateBirth = source.Authors[i].DateBirth,
                        Job = source.Authors[i].Job,
                        ArticleId = source.Authors[i].ArticleId
                    };
                }
            }
            throw new Exception("Статья не найдена");
        }

        public void AddElement(AuthorBindingModel authors)
        {
            int maxId = 0;
            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (source.Authors[i].Id > maxId)
                {
                    maxId = source.Authors[i].Id;
                }
                if (source.Authors[i].AuthorFIO == authors.AuthorFIO)
                {
                    throw new Exception("Уже есть такой автор");
                }
            }
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
            int index = -1;
            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (source.Authors[i].Id == authors.Id)
                {
                    index = i;
                }
                if (source.Authors[i].AuthorFIO == authors.AuthorFIO &&
                    source.Authors[i].Email == authors.Email &&
                    source.Authors[i].DateBirth == authors.DateBirth &&
                    source.Authors[i].Job == authors.Job &&
                    source.Authors[i].ArticleId == authors.ArticleId &&
                    source.Authors[i].Id == authors.Id)
                {
                    throw new Exception("Уже есть такой автор");
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            source.Authors[index].AuthorFIO = authors.AuthorFIO;
            source.Authors[index].Email = authors.Email;
            source.Authors[index].DateBirth = authors.DateBirth;
            source.Authors[index].Job = authors.Job;
            source.Authors[index].ArticleId = authors.ArticleId;

        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (source.Authors[i].Id == id)
                {
                    source.Authors.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("элемнет не найден");
        }
    }
}
