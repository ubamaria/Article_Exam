using System;
using System.Collections.Generic;
using System.Text;

namespace Article_Step_1.BindingModel
{
    public class AuthorBindingModel
    {
        public int? Id { get; set; }
        public int ArticleId { get; set; }

        public string AuthorFIO { get; set; }

        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

        public string Job { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
