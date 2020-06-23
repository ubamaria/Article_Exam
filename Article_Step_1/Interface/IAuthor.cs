using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_DAL.Interface
{
    public interface IAuthor
    {
        List<AuthorViewModel> GetList();

        AuthorViewModel GetElement(int id);

        void AddElement(AuthorBindingModel model);

        void UpdElement(AuthorBindingModel model);

        void DelElement(int id);
    }
}
