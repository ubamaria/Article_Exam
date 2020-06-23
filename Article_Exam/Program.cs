using Article_DAL.Interface;
using Article_List.Implement;
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

            currentContainer.RegisterType<IArticle, ArticleList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAuthor, AuthorList>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
