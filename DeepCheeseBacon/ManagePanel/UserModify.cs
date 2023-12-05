using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Common;
using System.Runtime.InteropServices;


namespace deepcheesebacon
{
    public partial class UserModify : UserControl
    {
        UserManage userManage = new UserManage();
        private DBManager dbManager;
        public UserModify(string id)
        {
            InitializeComponent();
            dbManager = DBManager.GetInstance();

            LoadComboBox();

            //emailText.Text = id;
            EmailLoad(id);
            emailText.ReadOnly = true;
            PwLoad(id);
            NameLoad(id);
            DateLoad(id);
            GenderLoad(id);
            RoleLoad(id);
            DepLoad(id);
            PnumLoad(id);
            AddrLoad(id);
        }

        private void LoadComboBox()
        {
            comboBox1.Items.Clear();

            List<string> departmentList = new List<string>();
            departmentList = dbManager.GetDepartment();

            if (departmentList != null && departmentList.Count > 0)
            {
                comboBox1.Items.AddRange(departmentList.ToArray());
            }
        }

        // 비밀번호 암호화 함수
        private string HashPassWord(string pw)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pw));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }

        }

     
        private void modifyBtn_Click(object sender, EventArgs e)
        {
            string email = emailText.Text;
            string pw = HashPassWord(pwText.Text);
            string name = nameText.Text;
            string gender = genderText.Text;
            string pnum = pnumText.Text;
            string addr = addrText.Text;
            string depid = comboBox1.Text;
            int id = dbManager.GetDepId(depid);
            string date = dateText.Text;
            int role = 0;

            if (roleText.Text == "원장")
            {
                role = 0;
            }
            else if (roleText.Text == "강사")
            {
                role = 1;
            }
            else if (roleText.Text == "보조강사")
            {
                role = 2;
            }

            dbManager.UserModify(role, email, pw, name, gender, pnum, addr, id, date);

            this.Controls.Clear();
            this.Controls.Add(userManage);
        }

        private void EmailLoad(string id)
        {
            string email = dbManager.Email(id);
            emailText.Text = email;

        }
        private void PwLoad(string id)
        {
            string result = dbManager.Pw(id);
            pwText.Text = result;
        }

        private void NameLoad(string id)
        {
            string name = dbManager.Name(id);
            nameText.Text = name;
        }
        private void DateLoad(string id)
        {
            string date = dbManager.Date(id);
            dateText.Text = date;
        }
        private void GenderLoad(string id)
        {
            string gender = dbManager.Gender(id);
            genderText.Text = gender;
        }
        private void RoleLoad(string id)
        {
            string role = dbManager.Role(id);
            roleText.Text = role;

        }
        private void DepLoad(string id)
        {
            string dep = dbManager.Dep(id);
            comboBox1.Text = dep;
        }
        private void PnumLoad(string id)
        {
            string pnum = dbManager.Pnum(id);
            pnumText.Text = pnum;
        }
        private void AddrLoad(string id)
        {
            string addr = dbManager.Addr(id);
            addrText.Text = addr;
        }

        private void emailText_Enter(object sender, EventArgs e)
        {
            if (emailText.Text == "이메일")
            {
                emailText.Text = "";
                emailText.ForeColor = Color.Black;
            }
        }

        private void pwText_Enter(object sender, EventArgs e)
        {
            if (pwText.Text == "비밀번호")
            {
                pwText.Text = "";
                pwText.ForeColor = Color.Black;
            }
        }

        private void nameText_Enter(object sender, EventArgs e)
        {
            if (nameText.Text == "이름")
            {
                nameText.Text = "";
                nameText.ForeColor = Color.Black;
            }
        }

        private void dateText_Enter(object sender, EventArgs e)
        {
            if (dateText.Text == "생년월일")
            {
                dateText.Text = "";
                dateText.ForeColor = Color.Black;
            }
        }

        private void genderText_Enter(object sender, EventArgs e)
        {
            if (genderText.Text == "성별")
            {
                genderText.Text = "";
                genderText.ForeColor = Color.Black;
            }
        }

        private void roleText_Enter(object sender, EventArgs e)
        {
            if (roleText.Text == "직급")
            {
                roleText.Text = "";
                roleText.ForeColor = Color.Black;
            }
        }

        private void depText_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "담당과목")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }

        private void pnumText_Enter(object sender, EventArgs e)
        {
            if (pnumText.Text == "전화번호")
            {
                pnumText.Text = "";
                pnumText.ForeColor = Color.Black;
            }
        }

        private void addrText_Enter(object sender, EventArgs e)
        {
            if (addrText.Text == "주소")
            {
                addrText.Text = "";
                addrText.ForeColor = Color.Black;
            }
        }

        private void addrText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
