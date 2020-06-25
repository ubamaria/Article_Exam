using Article_DAL.ViewModel;
using Article_Step_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_DAL.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<AuthorViewModel> Authors { get; set; }

    }
}
