using Article_DAL.BindingModel;
using Article_DAL.HelperModels;
using Article_DAL.Interface;
using Article_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Article_DAL.BusinessLogics
{
    public class ReportLogic 
    {
        private readonly IAuthor author;
        private readonly IArticle article;
        public ReportLogic(IAuthor author, IArticle article)
        {
            this.author = author;
            this.article = article;
        }
        public List<ReportArticleAuthorViewModel> GetArticleAuthors()
        {
            var authors = author.Read(null);
            var list = new List<ReportArticleAuthorViewModel>();
            foreach (var author in authors)
            {
                foreach (var ds in author.ArticleAuthors)
                {

                    var record = new ReportArticleAuthorViewModel
                    {
                        ArticleName = author.Title,
                        AuthorName = author.AuthorFIO,
                        //Title = author.Title,
                        //AuthorFIO = author.AuthorFIO,
                        //Job = author.Job,
                        //DateCreate = author.DateCreate
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        //{
        //    var list = orderLogic
        //    .Read(new OrderBindingModel
        //    {
        //        DateFrom = model.DateFrom,
        //        DateTo = model.DateTo
        //    })
        //    .GroupBy(rec => rec.DateCreate.Date)
        //    .OrderBy(recG => recG.Key)
        //    .ToList();

        //    return list;
        //}
        public void SaveAuthorArticles(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список авторов по статьям",
                ArticleAuthors = GetArticleAuthors()
            });
        }
    }
}
