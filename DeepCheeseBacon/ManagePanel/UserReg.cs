using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepcheesebacon
{

    public partial class UserReg : UserControl
    {
        private DBManager dbManager;

        public enum Role
        {
            원장, // 0
            강사, // 1
            보조강사 // 2
        }

        public UserReg()
        {
            InitializeComponent();
            dbManager = DBManager.GetInstance();

            LoadComboBox();
        }
       

        // combobox에 department 테이블의 department_name을 로드
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

      
        // 등록버튼 누르면 db에 정보 저장
        private void regBtn_Click(object sender, EventArgs e)
        {
            string role = roleText.Text;
            string email = emailText.Text;
            string pw = HashPassWord(pwText.Text);
            string name = nameText.Text;
            string gender = genderText.Text;
            string pnum = pnumText.Text;
            string addr = addrText.Text;
            string date = dateText.Text;
            string depid = comboBox1.Text; // 201, 102
            int id = dbManager.GetDepId(depid);
            int resultNum = -1; // 초기 값 설정

            // 입력한 텍스트박스 확인 후
            if (Enum.TryParse(role, out Role result))
            {
                switch (result)
                {
                    case Role.원장:
                        resultNum = 0;
                        break;
                    case Role.강사:
                        resultNum = 1;
                        break;
                    case Role.보조강사:
                        resultNum = 2;
                        break;
                    default:
                        break;

                }
            }
            // 직급 부분에 숫자로 저장
            if (resultNum != -1)  // 유효한 enum 값일 경우 db에 저장
            {
                dbManager.InsertInfo(resultNum, email, pw, name, gender, pnum, addr, id, date);
            }


            roleText.Text = "직급";
            roleText.ForeColor = Color.Silver;

            emailText.Text = "이메일";
            emailText.ForeColor = Color.Silver;

            pwText.Text = "비밀번호";
            pwText.ForeColor = Color.Silver;

            nameText.Text = "이름";
            nameText.ForeColor = Color.Silver;

            genderText.Text = "성별";
            genderText.ForeColor = Color.Silver;

            pnumText.Text = "전화번호";
            pnumText.ForeColor = Color.Silver;

            addrText.Text = "주소";
            addrText.ForeColor = Color.Silver;

            comboBox1.Text = "담당과목";
            comboBox1.ForeColor = Color.Silver;

            dateText.Text = "생년월일";
            dateText.ForeColor = Color.Silver;

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


        private void comboBox1_Enter(object sender, EventArgs e)
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

        private void UserReg_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
