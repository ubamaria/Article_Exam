using System;
using System.Collections.Generic;
using System.Text;

namespace Article_List.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }

        public string AuthorFIO { get; set; }

        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

        public string Job { get; set; }
        public Article Article { get; set; }
    }
}
