using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Article_Database.Models
{
    public class Author
    {
        public int Id { get; set; }
        //public int ArticleId { get; set; }

        [Required] public string AuthorFIO { get; set; }

        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

        public string Job { get; set; }
        [ForeignKey("AuthorId")]
        public virtual List<ArticleAuthor> ArticleAuthors { get; set; }
    }
}
