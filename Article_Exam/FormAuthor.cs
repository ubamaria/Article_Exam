using Article_DAL.Interface;
using Article_Step_1.BindingModel;
using Article_Step_1.ViewModel;
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
    public partial class FormAuthor : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IAuthor author;

        private readonly IArticle article;

        private int? id;
        public FormAuthor(IAuthor author, IArticle article)
        {
            InitializeComponent();
            this.author = author;
            this.article = article;
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
            List<ArticleViewModel> list = article.GetList();
            if (list != null)
            {
                comboBox1.DisplayMember = "Title";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = list;
            }
            if (id.HasValue)
            {
                try
                {

                    var view = author.GetElement(id.Value);
                    if (view != null)
                    {
                        textBox1.Text = view.AuthorFIO;
                        textBox2.Text = view.Email;
                        dateTimePicker1.Value = view.DateBirth;
                        textBox3.Text = view.Job;

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
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите статью", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    author.UpdElement(new AuthorBindingModel()
                    {
                        Id = id.Value,
                        AuthorFIO = textBox1.Text,
                        Email = textBox2.Text,
                        Job = textBox3.Text,
                        DateBirth = dateTimePicker1.Value,
                        ArticleId = Convert.ToInt32(comboBox1.SelectedValue)
                    });
                }
                else
                {
                    author.AddElement(new AuthorBindingModel()
                    {
                        AuthorFIO = textBox1.Text,
                        Email = textBox2.Text,
                        Job = textBox3.Text,
                        DateBirth = dateTimePicker1.Value,
                        ArticleId = Convert.ToInt32(comboBox1.SelectedValue)
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
