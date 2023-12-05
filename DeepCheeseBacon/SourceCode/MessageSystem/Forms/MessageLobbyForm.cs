using deepcheesebacon.SourceCode.ApprovalSystem.Models;
using deepcheesebacon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using deepcheesebacon.SourceCode.MessageSystem.Forms;
using deepcheesebacon.SourceCode.ApprovalSystem.Forms;

namespace deepcheesebacon
{
    partial class MessageLobbyForm : Form
    {
        MessageService messageService;
        DBManager dBManager;
        Dictionary<int, User> userDitionary;
        public MessageLobbyForm()
        {

            InitializeComponent();

            Console.WriteLine("MessageLobbyFrom 실행");

            messageService = new MessageService();

            LoadChattingList();
        }

        private void LoadChattingList()
        {
            List<string> chattingList = messageService.GetChattingList();

            listBoxMessageList.Items.Clear();
            if (chattingList != null && chattingList.Count > 0)
            {
                foreach (string email in chattingList)
                {
                    listBoxMessageList.Items.Add(email);
                }
            }


        }

        private void listBoxMessageList_Click(object sender, EventArgs e)
        {
            if (listBoxMessageList.SelectedIndex > -1) // 대화목록에서 선택된 값이 있다면
            {
                MessageDetailForm messageDetailForm = new MessageDetailForm(listBoxMessageList.SelectedItem.ToString());
                messageDetailForm.ShowDialog();
            }
        }

        private void buttonRealTimeChat_Click(object sender, EventArgs e)
        {
            realtimeChatRobby form = new realtimeChatRobby();
            form.ShowDialog();
        }

        private void refreshbutton_click(object sender, EventArgs e)
        {
            LoadChattingList();
        }

        private void customButtonStyle1_Click(object sender, EventArgs e)
        {
            MessageInBoxForm form = new MessageInBoxForm();
            form.ShowDialog();
        }

        private void buttonRealNameChat_Click(object sender, EventArgs e)
        {
            RealNameChatRobbyForm form = new RealNameChatRobbyForm();
            form.ShowDialog();
        }
    }
}
