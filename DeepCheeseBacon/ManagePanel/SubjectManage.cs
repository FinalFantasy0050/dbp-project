using deepcheesebacon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepcheesebacon
{

    public partial class SubjectManage : UserControl
    {
        private DBManager dbManager;

        // 크기 10인 배열 선언
        private string[] department = new string[10];
        int nextIndex = 0;
        string pre_grade = null;
        string pre_dep = null;

        public SubjectManage()
        {
            InitializeComponent();
            dbManager = DBManager.GetInstance();

            DataSet dataset = dbManager.ViewTable();
            dataGridView1.DataSource = dataset.Tables[0];

        }

        private int GetIndex()
        {
            // 현재 입력되어 있는 부서 코드의 젤 큰 수를 읽어와서 ++하고 저장
            nextIndex = dbManager.Department_IdMaxCheck();
            return ++nextIndex;
        }

        // 과목 등록버튼 
        private void departmentBtn_Click(object sender, EventArgs e)
        {
            string first = gradeText.Text;
            int second = 0;
            int third = GetIndex();

            string grade = gradeText.Text;
            string dep = departmentText.Text;

            bool depExists = dbManager.DepartCheck(grade, dep);


            if (depExists)
            {
                MessageBox.Show("이미 존재하는 값입니다.");
                return;
            }
            else
            {
                nextIndex = GetIndex();

                if (nextIndex < department.Length)
                {
                    department[nextIndex] = dep;

                    // third 변수에 새로 들어간 인덱스 저장
                    third = nextIndex;
                }

            }
            string dep_id = $"{first}{second}{third}";
            dbManager.DepartInsert(dep_id, grade, dep);

            gradeText.Clear();
            departmentText.Clear();

            DataSet dataset = dbManager.ViewTable();
            dataGridView1.DataSource = dataset.Tables[0];
        }

        // 과목 수정버튼
        private void modifyBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];

            string id = Convert.ToString(row.Cells[0].Value);
            string grade = gradeText.Text;
            string dep = departmentText.Text;



            bool depExists = dbManager.DepartCheck(grade, dep);

            // db에서 텍스트박스에 있는 학년, 과목과 같은 값을 찾게 되면
            if (depExists)
            {
                MessageBox.Show("이미 존재하는 값입니다.");
                return;
            }
            // 못 찾으면 수정가능
            else
            {
                string first = gradeText.Text;
                int second = 0;
                int third = dbManager.Department_IdCheck(pre_grade, pre_dep);

                string dep_id = $"{first}{second}{third}";
                dbManager.DepartModify(id, dep_id, grade, dep);

            }

            DataSet dataset = dbManager.ViewTable();
            dataGridView1.DataSource = dataset.Tables[0];
        }

        // 과목 삭제 버튼
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];

            string grade = gradeText.Text;
            string dep = departmentText.Text;

            dbManager.DepartDelete(grade, dep);

            gradeText.Clear();
            departmentText.Clear();

            DataSet dataset = dbManager.ViewTable();
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow;
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            pre_grade = row.Cells[2].Value.ToString();
            pre_dep = row.Cells[3].Value.ToString();
            gradeText.Text = row.Cells[2].Value.ToString();
            departmentText.Text = row.Cells[3].Value.ToString();
        }



        private void SubjectManage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}