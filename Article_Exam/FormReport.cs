using Article_DAL.BindingModel;
using Article_DAL.BusinessLogics;
using Microsoft.Reporting.WinForms;
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
    public partial class FormReport : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        public FormReport(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = logic.GetAuthors(new ReportBindingModel { DateFrom = dateTimePicker1.Value.Date, DateTo = dateTimePicker2.Value.Date });
                ReportDataSource source = new ReportDataSource("DataSet1", dataSource);
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveAuthorArticles(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = dateTimePicker1.Value.Date,
                            DateTo = dateTimePicker2.Value.Date,
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
