using Article_DAL.Interface;
using Article_Step_1.BindingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Article_Exam
{
    public partial class FormArticle : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IArticle article;
        private int? id;
        public FormArticle(IArticle article)
        {
            InitializeComponent();
            this.article = article;
        }

        private void FormArticle_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = article.Read(new ArticleBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBox1.Text = view.Title;
                        textBox2.Text = view.Subject;
                        dateTimePicker1.Value = view.DateCreate;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Заполните тематику", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    article.CreateOrUpdate(new ArticleBindingModel()
                    {
                        Id = id.Value,
                        Title = textBox1.Text,
                        Subject = textBox2.Text,
                        DateCreate = dateTimePicker1.Value
                    });
                }
                else
                {
                    article.CreateOrUpdate(new ArticleBindingModel()
                    {
                        Title = textBox1.Text,
                        Subject = textBox2.Text,
                        DateCreate = dateTimePicker1.Value
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
