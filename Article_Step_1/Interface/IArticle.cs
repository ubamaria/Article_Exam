using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_DAL.Interface
{
    public interface IArticle
    {
        List<ArticleViewModel> GetList();

        ArticleViewModel GetElement(int id);

        void AddElement(ArticleBindingModel model);

        void UpdElement(ArticleBindingModel model);

        void DelElement(int id);
    }
}
