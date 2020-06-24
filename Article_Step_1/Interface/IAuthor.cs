using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_DAL.Interface
{
    public interface IAuthor
    {
        List<AuthorViewModel> Read(AuthorBindingModel model);
        void CreateOrUpdate(AuthorBindingModel model);
        void Delete(AuthorBindingModel model);
    }
}
