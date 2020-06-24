using Article_DAL.BindingModel;
using Article_DAL.Interface;
using Article_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_Database.Implements
{
    public class ReportLogic : IReport
    {
        private readonly IAuthor author;

        public List<ReportViewModel> GetAuthors(ReportBindingModel model)
        {
            var list = new List<ReportViewModel>();
            var authors = author.GetList();
            foreach (var author in authors)
            {

                var record = new ReportViewModel
                {
                    Title = model.Title,
                    AuthorFIO = author.AuthorFIO,
                    Job = author.Job,
                    DateCreate = model.DateCreate
                };
                list.Add(record);
            }
            return list;
        }
        public void SaveAuthorArticles(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список авторов по статьям",
            });
        }
    }
}
