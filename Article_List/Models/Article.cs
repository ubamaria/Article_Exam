using System;
using System.Collections.Generic;
using System.Text;

namespace Article_List.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
