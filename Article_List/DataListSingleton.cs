using Article_List.Models;
using System;
using System.Collections.Generic;

namespace Article_List
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Article> Articles { get; set; }

        public List<Author> Authors { get; set; }

        public static DataListSingleton GetInstance()
        {
            instance = new DataListSingleton();
            return instance;
        }

        private DataListSingleton()
        {
            Articles = new List<Article>();
            Authors = new List<Author>();
        }
    }
}
