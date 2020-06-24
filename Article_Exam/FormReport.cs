using Article_DAL.BusinessLogics;
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

        private void FormReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            ReportDataSource source = new ReportDataSource("DataSetOrders",
                dataSource);
            reportViewer.LocalReport.DataSources.Add(source);

            reportViewer.RefreshReport();
        }             
        catch (Exception ex)             
            {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);             
}
}
}
