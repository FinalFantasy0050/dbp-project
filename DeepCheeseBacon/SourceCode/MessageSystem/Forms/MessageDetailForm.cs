using deepcheesebacon;
using deepcheesebacon.SourceCode.ApprovalSystem.Models;
using deepcheesebacon.SourceCode.MessageSystem.Models;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;

namespace deepcheesebacon
{
    public partial class MessageDetailForm : Form
    {
        DBManager dbManager;
        LoginedUserInfo myinfo;
        string opponentUserEmail;
        int opponentUserId;

        public MessageDetailForm(string opponentUserEmail)
        {
            InitializeComponent();
            dbManager = DBManager.GetInstance();
            myinfo = LoginedUserInfo.GetMyInfo();
            this.opponentUserEmail = opponentUserEmail;
            opponentUserId = ((User)dbManager.GetUserByEmail(opponentUserEmail)).UserId;
            Console.WriteLine("otherUserId and email: " + opponentUserId + opponentUserEmail);
            LoadMessage();
            AcceptButton = buttonSendMessage;
        }

        private void LoadMessage()
        {

            List<Message> messageList = dbManager.GetMessagesById(myinfo.userId, opponentUserId);

            listBoxChatBox.Items.Clear();


            foreach (Message message in messageList)
            {
                string displayMessage;
                string checkMessage = null;
                if (message.isChecked)
                {
                    checkMessage = "확인함";
                }
                else
                {
                    checkMessage = "확인안함";
                }

                if (message.senderId == myinfo.userId)
                {
                    displayMessage = $"나: {message.content}    {checkMessage}";
                    int spacesCount = Math.Max(0, 50 - displayMessage.Length); // 길이가 음수가 되지 않도록 Math.Max 사용
                    listBoxChatBox.Items.Add(new String(' ', spacesCount) + displayMessage);
                }
                else
                {
                    displayMessage = $"상대: {message.content}    {checkMessage}";
                    listBoxChatBox.Items.Add(displayMessage);
                }

            }

            textBoxInputMessage.Clear();
            listBoxChatBox.SelectedIndex = listBoxChatBox.Items.Count - 1;

        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (textBoxInputMessage.Text.IsNullOrEmpty())
            {
                MessageBox.Show("보낼 메시지를 입력해주세요");
                return;
            }
            if (textBoxTitle.Text.IsNullOrEmpty())
            {
                MessageBox.Show("제목을 입력해주세요");
                return;
            }

            dbManager.SaveMessage(new Message
            {
                senderId = myinfo.userId,
                receiverId = opponentUserId,
                content = textBoxInputMessage.Text,
                title = textBoxTitle.Text,
            });
            LoadMessage();


        }

        // 클라이언트에게 쪽지 알림을 보내는 메서드
        public void NotifyNewMessage(string userId, string message)
        {
            //Clients.User(userId).newMessageNotification(message);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadMessage();
        }

        private void textBoxInputMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
