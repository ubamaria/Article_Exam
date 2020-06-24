using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_DAL.Interface
{
    public interface IArticle
    {
        List<ArticleViewModel> Read(ArticleBindingModel model);
        void CreateOrUpdate(ArticleBindingModel model);
        void Delete(ArticleBindingModel model);
    }
}
