using deepcheesebacon.SourceCode.MessageSystem.Forms;
using deepcheesebacon.SourceCode.MessageSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deepcheesebacon.SourceCode.ApprovalSystem.Forms
{
    public partial class RealNameChatRobbyForm : Form
    {
        public RealNameChatRobbyForm()
        {
            InitializeComponent();
            LoadChatList();

        }

        List<ChatRoom> chatRooms;
        ChatRoom tempChatRoom;
        bool isFirst = true;

        async Task LoadChatList()
        {
            await Task.Delay(1000); //  1초 지연

            // ChatRooms를 비동기적으로 받아옴
            chatRooms = await ApiManager.GetChatSecretRoomsAsync();

            listBoxMessageList.Items.Clear();

            // 받아온 채팅방들에 대한 처리
            if (chatRooms != null)
            {
                foreach (var chatRoom in chatRooms)
                {
                    Console.WriteLine($"Chat room retrieved with ID: {chatRoom.RoomId} name: {chatRoom.Name}");

                    listBoxMessageList.Items.Add(chatRoom);
                }
            }
            else
            {
                Console.WriteLine("Failed to retrieve chat rooms.");
            }
        }

        private async Task CreateButtonClick()
        {
            if (textBoxRoomName.Texts != null && !textBoxRoomName.Texts.Equals(""))
            {
                tempChatRoom = await ApiManager.CreateChatSecretRoomAsync(textBoxRoomName.Texts);

                LoadChatList();
                textBoxRoomName.ClearText();
                MessageBox.Show("채팅방 생성 완료");
            }
            else
            {
                MessageBox.Show("생성할 채팅방 이름을 입력해주세요.");
            }
        }

        private void listBoxMessageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMessageList.SelectedIndex != -1)
            {
                realtimeChatDetailForm form = new realtimeChatDetailForm(((ChatRoom)listBoxMessageList.SelectedItem).RoomId, LoginedUserInfo.loginedUserInfo.email);
                form.ShowDialog();
            }
        }

        private void buttonCreateChatRoom_Click(object sender, EventArgs e)
        {
            CreateButtonClick();
        }
    }
}
