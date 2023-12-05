using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace deepcheesebacon
{
    public partial class Salary : UserControl
    {
        string selected;
        private DBManager dbManager;
        public Salary()
        {
            InitializeComponent();
            dbManager = DBManager.GetInstance();
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void prt_btn_Click(object sender, EventArgs e)
        {
            DataSet dataset = dbManager.ViewTableSalary(selected);
            payView.DataSource = dataset.Tables[0];
        }

        private void SelectMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = SelectMonth.SelectedItem.ToString();
        }
    }
}
