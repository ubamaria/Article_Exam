﻿using Article_Step_1.BindingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article_Step_1.ViewModel
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }

        public string AuthorFIO { get; set; }

        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

        public string Job { get; set; }
        public List<AuthorBindingModel> ArticleAuthors { get; set; }
        public string Title { get; set; }
    }
}
