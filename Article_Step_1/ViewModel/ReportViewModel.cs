using System;
using System.Collections.Generic;
using System.Text;

namespace Article_DAL.ViewModel
{
    public class ReportViewModel
    {
        public string Title { get; set; }

        public DateTime DateCreate { get; set; }

        public string AuthorFIO { get; set; }

        public DateTime DateBirth { get; set; }

        public string Job { get; set; }
    }
}
