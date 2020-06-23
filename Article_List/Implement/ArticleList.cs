using Article_DAL.Interface;
using Article_List.Models;
using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_List.Implement
{
    public class ArticleList : IArticle
    {
        private DataListSingleton source;

        public ArticleList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ArticleViewModel> GetList()
        {
            List<ArticleViewModel> articles = new List<ArticleViewModel>();
            for (int i = 0; i < source.Articles.Count; ++i)
            {
                List<AuthorViewModel> authors = new List<AuthorViewModel>();
                for (int j = 0; j < source.Authors.Count; j++)
                {
                    if (source.Authors[j].ArticleId == source.Articles[i].Id)
                    {
                        authors.Add(new AuthorViewModel
                        {
                            Id = source.Authors[j].Id,
                            AuthorFIO = source.Authors[j].AuthorFIO,
                            Email = source.Authors[j].Email,
                            DateBirth = source.Authors[j].DateBirth,
                            Job = source.Authors[j].Job,
                            ArticleId = source.Authors[j].ArticleId
                        });
                    }
                }
                articles.Add(new ArticleViewModel
                {
                    Id = source.Articles[i].Id,
                    Title = source.Articles[i].Title,
                    Subject = source.Articles[i].Subject,
                    DateCreate = source.Articles[i].DateCreate,
                    Authors = authors
                });
            }
            return articles;
        }

        public ArticleViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Articles.Count; ++i)
            {
                List<AuthorViewModel> authors = new List<AuthorViewModel>();
                for (int j = 0; j < source.Authors.Count; j++)
                {
                    if (source.Authors[j].ArticleId == source.Articles[i].Id)
                    {
                        authors.Add(new AuthorViewModel
                        {
                            Id = source.Authors[j].Id,
                            AuthorFIO = source.Authors[j].AuthorFIO,
                            Email = source.Authors[j].Email,
                            DateBirth = source.Authors[j].DateBirth,
                            Job = source.Authors[j].Job,
                            ArticleId = source.Authors[j].ArticleId
                        });
                    }
                }
                if (id == source.Articles[i].Id)
                {
                    return new ArticleViewModel
                    {
                        Id = source.Articles[i].Id,
                        Title = source.Articles[i].Title,
                        Subject = source.Articles[i].Subject,
                        DateCreate = source.Articles[i].DateCreate,
                        Authors = authors
                    };
                }
            }
            throw new Exception("Статья не найдена");
        }

        public void AddElement(ArticleBindingModel article)
        {
            int maxId = 0;
            for (int i = 0; i < source.Articles.Count; i++)
            {
                if (source.Articles[i].Id > maxId)
                {
                    maxId = source.Articles[i].Id;
                }
                if (source.Articles[i].Title == article.Title)
                {
                    throw new Exception("Уже есть такая статья");
                }
            }
            source.Articles.Add(new Article
            {
                Id = maxId + 1,
                Title = article.Title,
                Subject = article.Subject,
                DateCreate = article.DateCreate
            });

            int maxAId = 0;
            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (source.Authors[i].Id == maxAId)
                {
                    maxAId = source.Authors[i].Id;
                }
            }
            for (int i = 0; i < source.Authors.Count; i++)
            {
                source.Authors.Add(new Author
                {
                    Id = maxAId + 1,
                    AuthorFIO = source.Authors[i].AuthorFIO,
                    DateBirth = source.Authors[i].DateBirth,
                    Job = source.Authors[i].Job,
                    Email = source.Authors[i].Job,
                    ArticleId = maxId + 1,
                    Article = source.Authors[i].Article
                });
            }
        }

        public void UpdElement(ArticleBindingModel article)
        {
            int index = -1;
            for (int i = 0; i < source.Articles.Count; i++)
            {
                if (source.Articles[i].Id == article.Id)
                {
                    index = i;
                }
                if (source.Articles[i].Title == article.Title &&
                    source.Articles[i].Subject == article.Subject &&
                    source.Articles[i].DateCreate == article.DateCreate &&
                    source.Articles[i].Id != article.Id)
                {
                    throw new Exception("Уже есть такая статья");
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            source.Articles[index].Title = article.Title;
            source.Articles[index].Subject = article.Subject;
            source.Articles[index].DateCreate = article.DateCreate;

            int maxAId = 0;
            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (source.Authors[i].Id == maxAId)
                {
                    maxAId = source.Authors[i].Id;
                }
            }
            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (article.Authors[i].ArticleId == article.Id)
                {
                    for (int j = 0; j < source.Authors.Count; j++)
                    {
                        if (source.Authors[i].Id != article.Authors[j].Id)
                        {
                            source.Authors.RemoveAt(i--);
                        }
                    }
                }
            }

            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (article.Authors[i].Id == 0)
                {
                    source.Authors.Add(new Author
                    {
                        Id = maxAId + 1,
                        AuthorFIO = article.Authors[i].AuthorFIO,
                        DateBirth = article.Authors[i].DateBirth,
                        Email = article.Authors[i].Email,
                        Job = article.Authors[i].Job,
                        ArticleId = article.Id
                    });
                }
            }
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Authors.Count; i++)
            {
                if (source.Authors[i].ArticleId == id)
                {
                    source.Authors.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Articles.Count; i++)
            {
                if (source.Articles[i].Id == id)
                {
                    source.Articles.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("элемнет не найден");
        }
    }
}
