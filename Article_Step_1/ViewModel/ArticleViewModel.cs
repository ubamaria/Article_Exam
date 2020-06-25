using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Article_Step_1.ViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название заголовка")]

        public string Title { get; set; }
        [DisplayName("категория")]
        public string Subject { get; set; }
        [DisplayName("дата создания")]
        public DateTime DateCreate { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
    }
}