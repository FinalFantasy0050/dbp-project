using deepcheesebacon.LoginSystem.Models;
using deepcheesebacon.SourceCode.ApprovalSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace deepcheesebacon
{
    public partial class LoginForm : Form
    {
        DBManager dbManager;

        public LoginForm()
        {
            dbManager = DBManager.GetInstance();
            LoginData loginData = dbManager.GetLoginData();
            if (loginData != null && loginData.isAutoLoad)
            {
                checkBoxAutoLogin.Checked = loginData.isAutoLoad;
                textBoxEmail.Texts = loginData.email;
                textBoxPassword.Texts = loginData.password;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User originUser = dbManager.GetUserByEmail(textBoxEmail.Texts);

                string hashedPassword = ComputeSHA256Hash(textBoxPassword.Texts);
                Console.WriteLine("비밀번호: " + hashedPassword);


                if (originUser != null)
                {
                    if (textBoxPassword.Texts == originUser.Password)
                    {
                        LoginedUserInfo myInfo = LoginedUserInfo.GetMyInfo();
                        myInfo.email = originUser.Email;
                        myInfo.userId = originUser.UserId;
                        myInfo.role = originUser.UserRole;

                        MessageBox.Show("로그인에 성공하였습니다");
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("로그인에 실패하였습니다");
                        Console.WriteLine("비밀번호가 일치하지 않습니다");
                    }
                }
                else
                {
                    MessageBox.Show("사용자를 찾을 수 없습니다");
                    Console.WriteLine("사용자를 찾을 수 없습니다");
                }
            }
            catch (Exception ex)
            {
                // 가능한 구체적인 예외 종류를 기록하고 처리
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }

        private void checkBoxAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(checkBoxAutoLogin.Checked)
            {
                dbManager.SetAutoLogin(new LoginData
                {
                    isAutoLoad = checkBoxAutoLogin.Checked,
                    email = textBoxEmail.Texts,
                    password = textBoxPassword.Texts,
                });
            }
        }

        private string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // 입력 문자열을 바이트 배열로 변환
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // 해시 계산
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // 바이트 배열을 문자열로 변환하여 반환
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // 각 바이트를 16진수 문자열로 변환
                }

                return builder.ToString();
            }
        }
    }
}
