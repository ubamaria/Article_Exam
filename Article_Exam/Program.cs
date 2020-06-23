using Article_DAL.Interface;
using Article_Database;
using Article_Database.Implements;
using Article_List.Implement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace Article_Exam
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormArticles>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IArticle, ArticleLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAuthor, AuthorLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<DbContext, ArticleDatabase>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
