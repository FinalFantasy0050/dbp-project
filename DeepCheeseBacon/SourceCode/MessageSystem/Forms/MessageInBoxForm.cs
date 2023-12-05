using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace deepcheesebacon.SourceCode.MessageSystem.Forms
{
    public partial class MessageInBoxForm : Form
    {

        DBManager db;
        List<Message> messages;
        public MessageInBoxForm()
        {
            InitializeComponent();
            messages = new List<Message>();
            db = DBManager.GetInstance();
            SetMessageListBox();
        }

        private void SetMessageListBox()
        {
            messages = db.GetMessagesByUserId(LoginedUserInfo.loginedUserInfo.userId);
            foreach (Message message in messages)
            {
                listBoxMessage.Items.Add(message);
            }

        }

        private void SearchByTitle()
        {
            if (textBoxEmail.Texts.IsNullOrEmpty())
            {
                MessageBox.Show("검색할 이메일을 입력해주세요.");
            }
            else
            {
                User user = db.GetUserByEmail(textBoxEmail.Texts);
                int searchingId;
                if (user != null)
                {
                    searchingId = user.UserId;
                }
                else
                {
                    MessageBox.Show("검색하신 이메일을 가진 유저를 찾을 수 없습니다.");
                    return;
                }

                listBoxMessage.Items.Clear();

                foreach (Message message in messages)
                {
                    if (message.senderId.Equals(searchingId))
                    {
                        listBoxMessage.Items.Add(message);
                    }
                }

                MessageBox.Show("검색 성공하였습니다!");
            }
        }

        private void buttonSearchByContent_Click(object sender, EventArgs e)
        {

            if (textBoxContent.Texts.IsNullOrEmpty() && !textBoxEmail.Texts.IsNullOrEmpty() && textBoxTitle.Texts.IsNullOrEmpty())
            {
                SearchByTitle();
            }
            else if (!textBoxContent.Texts.IsNullOrEmpty() && textBoxEmail.Texts.IsNullOrEmpty() && textBoxTitle.Texts.IsNullOrEmpty())
            {
                listBoxMessage.Items.Clear();

                foreach (Message message in messages)
                {
                    if (message.content.Contains(textBoxContent.Texts))
                    {
                        listBoxMessage.Items.Add(message);
                    }
                }
                MessageBox.Show("검색 성공하였습니다!");
            }
            else if (textBoxContent.Texts.IsNullOrEmpty() && textBoxEmail.Texts.IsNullOrEmpty() && !textBoxTitle.Texts.IsNullOrEmpty())
            {
                listBoxMessage.Items.Clear();

                foreach (Message message in messages)
                {
                    if(message.title != null)
                    {
                        if (message.title.Contains(textBoxTitle.Texts))
                        {
                            listBoxMessage.Items.Add(message);
                        }
                    }
                    
                }
                MessageBox.Show("검색 성공하였습니다!");
            }
            else
            {
                MessageBox.Show("하나의 텍스트를 입력하여 주십시오.");
            }
        }
    }
}
