using Article_DAL.BindingModel;
using Article_DAL.HelperModels;
using Article_DAL.Interface;
using Article_DAL.ViewModel;
using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
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
        public List<AuthorViewModel> GetAuthors(ReportBindingModel model)
        {
            var authors = author.Read(new AuthorBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var list = new List<AuthorViewModel>();
            foreach (var author in authors)
            {
                    var record = new AuthorViewModel
                    {
                        AuthorFIO = author.AuthorFIO,
                        Email = author.Email,
                        DateBirth = author.DateBirth,
                        Job = author.Job,
                        Title = author.Title,
                    };
                    list.Add(record);
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
               Authors = GetAuthors(model)
            });
        }
    }
}
