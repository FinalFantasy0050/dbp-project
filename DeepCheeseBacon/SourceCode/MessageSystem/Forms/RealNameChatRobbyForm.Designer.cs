namespace deepcheesebacon.SourceCode.ApprovalSystem.Forms
{
    partial class RealNameChatRobbyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            customGroupBox2 = new Customizing.CustomGroupBox();
            textBoxRoomName = new Customizing.CustomTextBox();
            buttonCreateChatRoom = new Customizing.CustomButtonStyle();
            listBoxMessageList = new ListBox();
            customGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // customGroupBox2
            // 
            customGroupBox2.BackColor = Color.Transparent;
            customGroupBox2.Controls.Add(textBoxRoomName);
            customGroupBox2.Controls.Add(buttonCreateChatRoom);
            customGroupBox2.Controls.Add(listBoxMessageList);
            customGroupBox2.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            customGroupBox2.Location = new Point(62, 19);
            customGroupBox2.Name = "customGroupBox2";
            customGroupBox2.Radious = 25;
            customGroupBox2.Size = new Size(677, 412);
            customGroupBox2.TabIndex = 31;
            customGroupBox2.TabStop = false;
            customGroupBox2.Text = "실시간 채팅방";
            customGroupBox2.TitleBackColor = Color.FromArgb(94, 159, 242);
            customGroupBox2.TitleFont = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            customGroupBox2.TitleForeColor = Color.White;
            customGroupBox2.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60;
            // 
            // textBoxRoomName
            // 
            textBoxRoomName.BackColor = SystemColors.Window;
            textBoxRoomName.BorderColor = Color.FromArgb(94, 159, 242);
            textBoxRoomName.BorderFocusColor = Color.FromArgb(4, 96, 217);
            textBoxRoomName.BorderRadius = 0;
            textBoxRoomName.BorderSize = 3;
            textBoxRoomName.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxRoomName.ForeColor = Color.DimGray;
            textBoxRoomName.Location = new Point(16, 378);
            textBoxRoomName.Margin = new Padding(2);
            textBoxRoomName.Multiline = false;
            textBoxRoomName.Name = "textBoxRoomName";
            textBoxRoomName.Padding = new Padding(8, 5, 8, 5);
            textBoxRoomName.PasswordChar = false;
            textBoxRoomName.PlaceholderColor = Color.DarkGray;
            textBoxRoomName.PlaceholderText = "채팅방 이름을 정해주세요!";
            textBoxRoomName.Size = new Size(234, 28);
            textBoxRoomName.TabIndex = 32;
            textBoxRoomName.Texts = "";
            textBoxRoomName.UnderlinedStyle = true;
            // 
            // buttonCreateChatRoom
            // 
            buttonCreateChatRoom.BackColor = Color.FromArgb(94, 159, 242);
            buttonCreateChatRoom.BackgroundColor = Color.FromArgb(94, 159, 242);
            buttonCreateChatRoom.BorderColor = Color.PaleVioletRed;
            buttonCreateChatRoom.BorderRadius = 20;
            buttonCreateChatRoom.BorderSize = 0;
            buttonCreateChatRoom.FlatStyle = FlatStyle.Flat;
            buttonCreateChatRoom.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCreateChatRoom.ForeColor = Color.White;
            buttonCreateChatRoom.Location = new Point(558, 380);
            buttonCreateChatRoom.Name = "buttonCreateChatRoom";
            buttonCreateChatRoom.Size = new Size(104, 26);
            buttonCreateChatRoom.TabIndex = 3;
            buttonCreateChatRoom.Text = "채팅방 생성";
            buttonCreateChatRoom.TextColor = Color.White;
            buttonCreateChatRoom.UseVisualStyleBackColor = false;
            buttonCreateChatRoom.Click += buttonCreateChatRoom_Click;
            // 
            // listBoxMessageList
            // 
            listBoxMessageList.FormattingEnabled = true;
            listBoxMessageList.ItemHeight = 15;
            listBoxMessageList.Location = new Point(16, 40);
            listBoxMessageList.Name = "listBoxMessageList";
            listBoxMessageList.Size = new Size(646, 334);
            listBoxMessageList.TabIndex = 0;
            listBoxMessageList.SelectedIndexChanged += listBoxMessageList_SelectedIndexChanged;
            // 
            // RealNameChatRobbyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customGroupBox2);
            Name = "RealNameChatRobbyForm";
            Text = "RealNameChatRobbyForm";
            customGroupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Customizing.CustomGroupBox customGroupBox2;
        private Customizing.CustomTextBox textBoxRoomName;
        private Customizing.CustomButtonStyle buttonCreateChatRoom;
        private ListBox listBoxMessageList;
    }
}