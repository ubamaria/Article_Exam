using Article_DAL.BindingModel;
using Article_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_DAL.Interface
{
    public interface IReport
    {
        void SaveAuthorArticles(ReportBindingModel model);

        List<ReportViewModel> GetAuthors(ReportBindingModel model);
    }
}
