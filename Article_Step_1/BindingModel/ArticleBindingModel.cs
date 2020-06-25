using System;
using System.Collections.Generic;
using System.Text;

namespace Article_Step_1.BindingModel
{
    public class ArticleBindingModel
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public DateTime DateCreate { get; set; }
        public List<AuthorBindingModel> Authors { get; set; }
    }
}
