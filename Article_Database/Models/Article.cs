using Article_Step_1.BindingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Article_Database.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }

        public string Subject { get; set; }

        public DateTime DateCreate { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}
